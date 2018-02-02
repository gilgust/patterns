using System;
using System.IO;

namespace Servicies
{
    internal class FileService : IAddPath, IFileService
    {
        private static readonly Lazy<FileService> _lazy = 
            new Lazy<FileService>(()=> new FileService());
        
        private FileService()
        {
            NameFile = null;
            PathToFite = null;
            TargetPath = null;
        }
        
        public Stream FileStream { get; set; }
        public string PathToFite { get; set; }
        public string NameFile { get; set; }
        public string TargetPath { get; set; }


        public static FileService GetInstance()
        {
            return _lazy.Value;
        }
        
        public Stream OpenFileStream()
        {
            
            FileStream = new FileStream(PathToFite, FileMode.Open);
            return FileStream;
        }

        public void SaveFile()
        {
            var sourceFile = Path.Combine(PathToFite, NameFile); 
            var targetFile = Path.Combine(TargetPath, NameFile);
             
            File.Copy(sourceFile, targetFile, true);
        }
        
        public void MoveFile()
        {
            string _sourcePath = Path.Combine(PathToFite, NameFile);
            string _targetPath = Path.Combine(TargetPath, NameFile);

            File.Move(_sourcePath, _targetPath);
        }

        public void DeleteFile()
        {
            try
            {
                File.Delete(PathToFite);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool IsEmpty()
        {
            return (NameFile == null && PathToFite == null);
        }
    }
}
