using System;
using System.Collections.Generic;

namespace FileService
{
    public interface IFileService
    {
        void GetFile(Action<string, Exception> callback);
        void GetData(Action<IEnumerable<string>, Exception> callback, string pathFile);
        void SaveFile(Action<Exception> callback, IEnumerable<string> data, string nameFile);
        void OpenFolder(Action<Exception> callback, string pathFolder);
        void ClearFolder(Action<Exception> callback, string pathFolder);
    }
}