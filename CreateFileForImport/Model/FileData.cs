using GalaSoft.MvvmLight;

namespace CreateFileForImport
{
    public class FileData :ViewModelBase
    {
        public const string PathFilePropertyName = "PathFile";
        public const string CountRecordPropertyName = "CountRecord";
        public const string CountErrorRecordPropertyName = "CountErrorRecord";

        private string _pathFile = string.Empty;
        public string PathFile
        {
            get => _pathFile;
            set => Set(PathFilePropertyName, ref _pathFile, value);
        }

        private int _countRecord = 0;
        public int CountRecord
        {
            get => _countRecord;
            set => Set(CountRecordPropertyName, ref _countRecord, value);
        }

        private int _countErrorRecord = 0;
        public int CountErrorRecord
        {
            get => _countErrorRecord;
            set => Set(CountErrorRecordPropertyName, ref _countErrorRecord, value);
        }
    }
}