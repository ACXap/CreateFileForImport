using System;
using System.Collections.Generic;

namespace FileService
{
    public interface IFileService
    {
        void GetFile(Action<string, Exception> callback);
        void GetData(Action<IEnumerable<string>, Exception> callback, string pathFile);
        void SaveFile(Action<string, Exception> callback);
    }
}