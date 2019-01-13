using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileService
{
    public class FileService : IFileService
    {
        public void GetFile(Action<string, Exception> callback)
        {
            string pathFile = string.Empty;
            Exception error = null;

            OpenFileDialog fd = new OpenFileDialog
            {
                Multiselect = false
            };
            if (fd.ShowDialog() == true)
            {
                pathFile = fd.FileName;
                callback(pathFile, error);
            }
        }

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

        public void SaveFile(Action<Exception> callback, IEnumerable<string> data, string nameFile)
        {
            Exception error = null;

            if(Directory.Exists(Path.GetDirectoryName(Path.GetFullPath(nameFile))))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(File.OpenWrite(nameFile), Encoding.Default))
                    {
                        foreach (var item in data)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    error = ex;
                }
            }
            else
            {
                error = new DirectoryNotFoundException();
            }

            callback(error);
        }

        public void OpenFolder(Action<Exception> callback, string pathFolder)
        {
            throw new NotImplementedException();
        }

        public void ClearFolder(Action<Exception> callback, string pathFolder)
        {
            throw new NotImplementedException();
        }
    }
}