using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileService
{
    public class FileService : IFileService
    {
        public void GetData(Action<IEnumerable<string>, Exception> callback, string pathFile)
        {
            List<string> data = null;
            Exception error = null;

            if (File.Exists(pathFile))
            {
                data = new List<string>();
                try
                {
                    using (StreamReader sr = new StreamReader(File.Open(pathFile, FileMode.Open, FileAccess.Read, FileShare.Read), Encoding.Default))
                    {
                        while (!sr.EndOfStream)
                        {
                            data.Add(sr.ReadLine());
                        }
                    }
                }
                catch (Exception ex)
                {
                    error = ex;
                    data = null;
                }
            }
            else
            {
                error = new FileNotFoundException();
            }

            callback(data, error);
        }

        public void GetFile(Action<string, Exception> callback)
        {
            string pathFile = string.Empty;

            OpenFileDialog fd = new OpenFileDialog
            {
                Multiselect = false
            };
            if (fd.ShowDialog() == true)
            {
                pathFile = fd.FileName;
                callback(pathFile, null);
            }
            else
            {

            }
        }

        public void SaveFile(Action<string, Exception> callback)
        {
            throw new NotImplementedException();
        }
    }
}