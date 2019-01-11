using DataService;
using FileService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFileForImport
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IFileService _fileService;
        private readonly IDataService _dataService;

        public FileData FileNewData { get; private set; }
        public FileData FileFromDB { get; private set; }

        private RelayCommand<EnumFileData> _selectFile;
        public RelayCommand<EnumFileData> SelectFile =>
            _selectFile ?? (_selectFile = new RelayCommand<EnumFileData>(
                    f =>
                    {
                        string pathFile = string.Empty;
                        IEnumerable<string> data = null; ;

                        _fileService.GetFile((file, er) =>
                        {
                            if (er == null)
                            {
                                pathFile = file;
                            }
                        });

                        if (string.IsNullOrEmpty(pathFile) || data == null)
                        {
                            return;
                        }

                        _fileService.GetData((d, er) =>
                        {
                            if (er == null)
                            {
                                data = d;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }, pathFile);

                        _dataService.GetDataFromStings((oe, error) =>
                        {

                        }, data);


                        if (f == EnumFileData.FileNewData)
                        {
                            FileNewData.PathFile = pathFile;
                        }
                        else
                        {
                            FileFromDB.PathFile = pathFile;
                        }
                    }));

        public MainWindowViewModel()
        {
            FileNewData = new FileData();
            FileFromDB = new FileData();

            _fileService = new FileService.FileService();
            _dataService = new DataService.DataService();
        }
    }
}