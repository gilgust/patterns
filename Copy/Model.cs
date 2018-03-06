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
    class Model : INotifyPropertyChanged
    {
        private string _sourcePath;
        private string _targetPath;
        private Task _copyTask;
        private Progress<int> _progress;
        private int _progressCount;
        private readonly int _bufferSize;
        private object _lockObj;

        public Model()
        {
            _sourcePath = String.Empty;
            _targetPath = String.Empty;
            _bufferSize = 4096;
            _progress = new Progress<int>(procent => Progress = procent);
            _lockObj = new object();
        }


        #region Property 

        public int Progress
        {
            get => _progressCount;
            set
            {
                if (_progressCount != value)
                {
                    _progressCount = value;
                    OnPropertyChanged(nameof(Progress));
                }
            }
        }

        public string SourcePath
        {
            get => _sourcePath;
            set
            {
                if (_sourcePath != value)
                {
                    _sourcePath = value;
                    OnPropertyChanged(nameof(SourcePath));
                }
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
        #endregion

        public void Copy()
        {
            if (!File.Exists(TargetPath) && File.Exists(SourcePath))
            {
                _copyTask = Task.Run(() => CopyFile());
            }
            if (Directory.Exists(TargetPath) && Directory.Exists(SourcePath))
            {
                if (string.Equals(SourcePath, TargetPath))
                    TargetPath += "_copy";
                _copyTask = Task.Run(() => CopyFolder(SourcePath, TargetPath));
            }
        }

        //method for copy only one file
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

        //method for copy folder
        private void CopyFolder(string sourceDirectory, string targetDirectory)
        {
            var sourceDirInfo = new DirectoryInfo(sourceDirectory);
            Directory.CreateDirectory(targetDirectory + @"\" + sourceDirInfo.Name);
            var targetDirInfo = new DirectoryInfo(targetDirectory + @"\" + sourceDirInfo.Name);

            var percentOfDirectorySize = GetFolderSize(sourceDirectory) / 100;
            var compleatedProcent = 0;
            int counter = 0;

            var fileArray = sourceDirInfo.GetFiles();
            foreach (var file in fileArray)
            {
                CopyFile(file.FullName, targetDirInfo.FullName + @"\", percentOfDirectorySize, ref compleatedProcent, ref counter);
            }

            var directoryArray = sourceDirInfo.GetDirectories();
            foreach (var directory in directoryArray)
            {
                CopyFolder(directory.FullName, targetDirInfo.FullName, percentOfDirectorySize, ref compleatedProcent, ref counter);
            }
            if (counter == percentOfDirectorySize * 100)
                ((IProgress<int>)_progress).Report(100);
        }

        //method for copy folder in folder
        private void CopyFolder(string sourceDirectory, string targetDirectory, int percentOfDirectorySize, ref int compleatedProcent, ref int counter)
        {
            var sourceDirInfo = new DirectoryInfo(sourceDirectory);
            Directory.CreateDirectory(targetDirectory + @"\" + sourceDirInfo.Name);
            var targetDirInfo = new DirectoryInfo(targetDirectory + @"\" + sourceDirInfo.Name);

            var fileArray = sourceDirInfo.GetFiles();
            foreach (var file in fileArray)
            {
                CopyFile(file.FullName, targetDirInfo.FullName + @"\", percentOfDirectorySize, ref compleatedProcent, ref counter);
            }

            var directoryArray = sourceDirInfo.GetDirectories();
            foreach (var directory in directoryArray)
            {
                CopyFolder(directory.FullName, targetDirInfo.FullName, percentOfDirectorySize, ref compleatedProcent, ref counter);
            }
        }


        //method copy file in folder
        private void CopyFile(string sourceFile, string targetDirecrory, int percentOfDirectorySize, ref int compleatedProcent, ref int counter)
        {
            var sourceInfo = new FileInfo(sourceFile);
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (FileStream writer = new FileStream(targetDirecrory + @"\" + sourceInfo.Name, FileMode.Create, FileAccess.Write))
            {
                while (reader.Position < reader.Length)
                {
                    var arrayBytes = new byte[_bufferSize];
                    reader.Read(arrayBytes, 0, _bufferSize);
                    writer.Write(arrayBytes, 0, _bufferSize);

                    lock (_lockObj)
                    {
                        if (counter > compleatedProcent * percentOfDirectorySize)
                            ((IProgress<int>)_progress).Report(compleatedProcent++);
                    }
                }
            }
        }

        //get number of file in filder
        private int GetFolderSize(string directory)
        {
            var numberOfFiles = Directory.GetFiles(directory).Count();

            foreach (var direct in Directory.GetDirectories(directory))
            {
                numberOfFiles += GetFolderSize(direct);
            }
            return numberOfFiles;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


