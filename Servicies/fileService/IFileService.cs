using System.IO;

namespace Servicies
{
    public interface IFileService: IAddPath
    {
        Stream FileStream { get; set; }
        string TargetPath { get; set; }

        Stream OpenFileStream();
        void SaveFile();
        void MoveFile();
        void DeleteFile();
        bool IsEmpty();
    }
}
