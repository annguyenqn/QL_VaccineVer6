using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_VaccineVer6.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace QL_VaccineVer6.ViewModel
{
    public class ObjectViewModel : BaseViewModel
    {
        private ObservableCollection<Model.Vaccine> _List;
        public ObservableCollection<Model.Vaccine> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.NhacungCap> _Suplier;
        public ObservableCollection<Model.NhacungCap> Suplier { get => _Suplier; set { _Suplier = value; OnPropertyChanged(); } }

        private Model.Vaccine _SelectedItem;
        public Model.Vaccine SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.TenVac;
       
                    SelectedSuplier = SelectedItem.NhacungCap;
                }
            }
        }


        private Model.NhacungCap _SelectedSuplier;
        public Model.NhacungCap SelectedSuplier
        {
            get => _SelectedSuplier;
            set
            {
                _SelectedSuplier = value;
                OnPropertyChanged();
            }
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }




        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }


        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ObjectViewModel()
        {
            List = new ObservableCollection<Model.Vaccine>(DataProvider.Ins.DB.Vaccines);
            Suplier = new ObservableCollection<Model.NhacungCap>(DataProvider.Ins.DB.NhacungCaps);
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedSuplier == null )
                    return false;
                return true;

            }, (p) =>
            {
                var Object = new Model.Vaccine() { TenVac = DisplayName, IdNcc = SelectedSuplier.IdNcc,  IdVac = Guid.NewGuid().ToString() };

                DataProvider.Ins.DB.Vaccines.Add(Object);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Object);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedSuplier == null )
                    return false;

                var displayList = DataProvider.Ins.DB.Vaccines.Where(x => x.IdVac == SelectedItem.IdVac);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Object = DataProvider.Ins.DB.Vaccines.Where(x => x.IdVac == SelectedItem.IdVac).SingleOrDefault();
                Object.TenVac = DisplayName;
                Object.IdNcc = SelectedSuplier.IdNcc;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.TenVac = DisplayName;
            });
        }
    }
}
