using SimpleDataGrid;
using System.ComponentModel;
using System.Linq;

namespace Client
{
    public sealed class ReferenceDataManager
    {
        private static readonly ReferenceDataManager _instance = new ReferenceDataManager();

        public static ReferenceDataManager Instance
        {
            get { return _instance; }
        }

        public class ReferenceDataItem : INotifyPropertyChanged
        {
            private int _key;

            public int Key
            {
                get { return _key; }
                set
                {
                    if (_key == value)
                        return;

                    _key = value;

                    OnPropertyChanged("Key");
                }
            }

            private string _value;

            public string Value
            {
                get { return _value; }
                set
                {
                    if (_value == value)
                        return;
                    _value = value;
                    OnPropertyChanged("Value");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;

                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        private readonly ObservableCollectionEx<ReferenceDataItem> _baiXes
            = new ObservableCollectionEx<ReferenceDataItem>();

        public void LoadBaiXes()
        {
            var qe = new QueryBuilder.QueryExpression();
            qe.PageIndex = 0;
            var service = new ProtoBufDataService<DTO.RBaiXeDto>();

            var data = service.Get(qe).Items.Select(
                p => new ReferenceDataItem() { Key = p.Ma, Value = p.DiaDiemBaiXe });

            _baiXes.Reset(data);
        }

        public ObservableCollectionEx<ReferenceDataItem> BaiXes(bool forceReload = false)
        {
            if (forceReload)
            {
                LoadBaiXes();
            }
            return _baiXes;
        }
    }
}
