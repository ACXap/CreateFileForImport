using System;
using DataService;
using FileService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CreateFileForImport
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IFileService _fileService;
        private readonly IDataService _dataService;

        public FileData FileData { get; private set; }

        private RelayCommand _commandSelectFile;
        public RelayCommand CommandSelectFile =>
            _commandSelectFile ?? (_commandSelectFile = new RelayCommand(
                    () => SelectFile()));

        private RelayCommand _commandCheckData;
        public RelayCommand CommandCheckData =>
            _commandCheckData ?? (_commandCheckData = new RelayCommand(
                () => CheckData(),
            () => !string.IsNullOrEmpty(FileData.PathFile)));

        private RelayCommand _commandCreateFiles;
        public RelayCommand CommandCreateFiles =>
            _commandCreateFiles ?? (_commandCreateFiles = new RelayCommand(
                    () => CreateFiles(),
                    () => !string.IsNullOrEmpty(FileData.PathFile) && true));

        private void CreateFiles()
        {
            throw new NotImplementedException();
        }

        private void CheckData()
        {
            throw new NotImplementedException();
        }

        private void SelectFile()
        {
            string pathFile = string.Empty;

            _fileService.GetFile((file, er) =>
            {
                if (er == null)
                {
                    pathFile = file;
                }
            });

            FileData.PathFile = pathFile;
        }

        public MainWindowViewModel()
        {
            FileData = new FileData();

            _fileService = new FileService.FileService();
            _dataService = new DataService.DataService();
        }
    }
}