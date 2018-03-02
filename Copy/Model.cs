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
        private string _directoryPath;
        private Task _copyTask;
        private Progress<int> _progress;
        private int _progressCount;


        public Model()
        { 
            _sourcePath = String.Empty;
            _targetPath = String.Empty;
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
                OnPropertyChanged(nameof(Path)); 
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

        public string DirectoryPath
        {
            get => _directoryPath;
            set
            {
                _directoryPath = value;
                OnPropertyChanged(nameof(DirectoryPath));
            }
        }

        public void Copy()
        {
            if (File.Exists(TargetPath) || !File.Exists(SourcePath))
                return;
            _copyTask = Task.Run(() => CopyMethod());


        }

        private void CopyMethod()
        {
            using (FileStream reader = new FileStream(_sourcePath, FileMode.Open, FileAccess.Read))
            using (FileStream writer = new FileStream(_targetPath, FileMode.Create, FileAccess.Write))
            {
                var percentOfFileSize = (int)reader.Length / 100;
                var counter = 0;
                var compleatedProcent = 0;
                int bufferSize = 4096;

                while (reader.Position < reader.Length)
                {
                    var arrayBytes = new byte[bufferSize];
                    reader.Read(arrayBytes, 0, bufferSize);
                    writer.Write(arrayBytes, 0, bufferSize);

                    counter += bufferSize;
                    if (counter > compleatedProcent * percentOfFileSize)
                        ((IProgress<int>)_progress).Report(compleatedProcent++);

                    ((IProgress<int>)_progress).Report(100);
                }
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


