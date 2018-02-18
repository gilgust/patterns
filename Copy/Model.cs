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
        private string _path;
        private string _targetPath;

        private Thread _readerThread;
        private Thread _writerThread;
        private readonly Queue<byte[]> _queueBytes;
        //private bool _readyForCopy;
        private double _progress;

        

        public Model()
        {
            _queueBytes = new Queue<byte[]>();
            _path = String.Empty;
            _targetPath = String.Empty;
            _progress = 0;
        }

        public double Progress
        {
            get => _progress;
            set
            {
                _progress = value; 
                OnPropertyChanged(nameof(Progress));
            }
        }

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                //ReadinessTest();
                OnPropertyChanged(nameof(Path)); 
            }
        }

        public string TargetPath
        {
            get => _targetPath;
            set
            {
                _targetPath = value;
                //ReadinessTest();
                OnPropertyChanged(nameof(TargetPath)); 
            }
        }

        // here i had tried to make CopyButton not available

        //public bool ReadyForCopy {
        //    get => _readyForCopy;
        //    set
        //    {
        //        _readyForCopy = value;
        //        OnPropertyChanged(nameof(ReadyForCopy));
        //    }
        //}
        //public void ReadinessTest()
        //{
        //    if (!File.Exists(_path) || File.Exists(_targetPath))
        //        _readyForCopy = false;
        //    else
        //    {
        //        _readyForCopy = true;
        //    }
        //}

        public void Copy()
        {
            if(File.Exists(TargetPath) || !File.Exists(Path))
                return;
            _readerThread = new Thread(ReadFile);
            _writerThread = new Thread(WriteFile);

            _readerThread.Start();
            _writerThread.Start();


        }

        private void ReadFile()
        {
            using (FileStream reader = new FileStream(_path, FileMode.Open, FileAccess.Read))
            {
                int bufferSize = 4096;

                while (reader.Position < reader.Length)
                {
                    if (_queueBytes.Count < 256)
                    {
                        var arrayBytes = new byte[bufferSize];
                        reader.Read(arrayBytes, 0, bufferSize);
                        _queueBytes.Enqueue(arrayBytes);
                        Progress += reader.Length / bufferSize;
                    }
                    else
                    {
                        Thread.Sleep(20);
                    }
                }
            }
        }

        private void WriteFile()
        {
            using (FileStream writer = new FileStream(_targetPath, FileMode.Create, FileAccess.Write))
            {
                int bufferSize = 4096;
                var arrayBytes = new byte[bufferSize];
                while (_queueBytes.Count > 0 || _readerThread.IsAlive)
                {
                    if (_queueBytes.Count > 0)
                    {
                        arrayBytes = _queueBytes.Dequeue();
                        if (arrayBytes == null)
                            continue;
                        writer.Write(arrayBytes, 0, bufferSize);
                    }
                    else
                    {
                        Thread.Sleep(20);
                    }
                }

                Progress = 0;
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


