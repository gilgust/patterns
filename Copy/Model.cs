using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Copy.Annotations;
using System.Threading;

namespace Copy
{
    class Model: INotifyPropertyChanged
    {
        private string _sourcePath;
        private string _targetPath;  
        private Task _copyTask;
        private Progress<int> _progress;
        private int _progressCount;
        private readonly int _bufferSize;


        public Model()
        { 
            _sourcePath = String.Empty;
            _targetPath = String.Empty;
            _bufferSize = 4096;
            _progress = new Progress<int>(procent => Progress = procent);
        }

        public int Progress
        {
            get => _progressCount;
            set
            {
                _progressCount = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        public string SourcePath
        {
            get => _sourcePath;
            set
            {
                _sourcePath = value; 
                OnPropertyChanged(nameof(SourcePath)); 
            }
        }

        public string TargetPath
        {
            get => _targetPath;
            set
            {
                _targetPath = value; 
                OnPropertyChanged(nameof(TargetPath)); 
            }
        } 
     

        public void Copy()
        {
            if (!File.Exists(TargetPath) && File.Exists(SourcePath))
            {
                _copyTask = Task.Run(() => CopyFile());
            }
            if (Directory.Exists(TargetPath) && Directory.Exists(SourcePath))
            {
                _copyTask = Task.Run(() => CopyFolder(SourcePath, TargetPath));
            }
        }

        private void CopyFile()
        {
            using (FileStream reader = new FileStream(_sourcePath, FileMode.Open, FileAccess.Read))
            using (FileStream writer = new FileStream(_targetPath, FileMode.Create, FileAccess.Write))
            {
                var percentOfFileSize = (int)reader.Length / 100;
                var counter = 0;
                var compleatedProcent = 0;

                while (reader.Position < reader.Length)
                {
                    var arrayBytes = new byte[_bufferSize];
                    reader.Read(arrayBytes, 0, _bufferSize);
                    writer.Write(arrayBytes, 0, _bufferSize);

                    counter += _bufferSize;
                    if (counter > compleatedProcent * percentOfFileSize)
                        ((IProgress<int>)_progress).Report(compleatedProcent++);

                    ((IProgress<int>)_progress).Report(100);
                }
            }
        }

        private void CopyFolder(string sourceDirectory, string targetDirectory)
        { 
            var sourceDirInfo = new DirectoryInfo(sourceDirectory);
            Directory.CreateDirectory(targetDirectory + @"\" + sourceDirInfo.Name);
            var targetDirInfo = new DirectoryInfo(targetDirectory + @"\" + sourceDirInfo.Name);

            var percentOfDirectorySize = GetFolderSize(sourceDirectory) / 100;
            var compleatedProcent = 0;
            long counter = 0;

            var fileArray = sourceDirInfo.GetFiles();
            foreach (var file in fileArray)
            {
                CopyFile(file.FullName, targetDirInfo.FullName + @"\", percentOfDirectorySize, ref compleatedProcent, ref counter);
            }

            var directoryArray = sourceDirInfo.GetDirectories();
            foreach (var directory in directoryArray)
            {
                CopyFolder(directory.FullName, targetDirInfo.FullName);
            }
            ((IProgress<int>)_progress).Report(100);
        }

        private void CopyFile(string sourceFile, string targetDirecrory, long percentOfDirectorySize, ref int compleatedProcent, ref long counter)
        {
            var sourceInfo = new FileInfo(sourceFile);
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (FileStream writer = new FileStream(targetDirecrory + @"\" + sourceInfo.Name, FileMode.Create, FileAccess.Write))
            {


                while (reader.Position < reader.Length)
                {
                    var arrayBytes = new byte[_bufferSize];
                    var checkSize = reader.Read(arrayBytes, 0, _bufferSize);
                    writer.Write(arrayBytes, 0, _bufferSize);

                    if (checkSize < _bufferSize)
                        counter += checkSize;
                    else
                        counter += _bufferSize;

                    if (counter > compleatedProcent * percentOfDirectorySize)
                        ((IProgress<int>)_progress).Report(compleatedProcent++);
                }
            }
        }

        private long GetFolderSize(string directory)
        {
            long directorySize = 0;

            foreach (var file in Directory.GetFiles(directory))
            {
                var fInfo = new FileInfo(file);
                directorySize += fInfo.Length;
            }

            foreach (var direct in Directory.GetDirectories(directory))
            {
                directorySize += GetFolderSize(direct);
            }
            return directorySize;
        }




        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


