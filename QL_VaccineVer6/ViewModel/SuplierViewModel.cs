using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QL_VaccineVer6.Model;

namespace QL_VaccineVer6.ViewModel
{

    public class SuplierViewModel : BaseViewModel
    {
        private ObservableCollection<NhacungCap> _List;
        public ObservableCollection<NhacungCap> List { get => _List; set { _List = value; OnPropertyChanged(); } }    //hiển thị 

        private NhacungCap _SelectedItem;
        public NhacungCap SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.TenNcc;
                    Phone = SelectedItem.Phone;
                    Address = SelectedItem.Adress;
   ;
                }
            }
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }


        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }


        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }


        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }


        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }


        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ICommand  DeleteCommand  { get; set; }
        public ICommand ClearCommand { get; set; }
        public SuplierViewModel()
        {
            List = new ObservableCollection<NhacungCap>(DataProvider.Ins.DB.NhacungCaps);

            ClearCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                DisplayName = "";
                Address = "";
                Phone = "";
                Email = "";
            });


            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var nhacungCap = new NhacungCap() { TenNcc = DisplayName, Phone = Phone, Adress = Address};

                DataProvider.Ins.DB.NhacungCaps.Add(nhacungCap);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(nhacungCap);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.NhacungCaps.Where(x => x.IdNcc == SelectedItem.IdNcc);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Suplier = DataProvider.Ins.DB.NhacungCaps.Where(x => x.IdNcc == SelectedItem.IdNcc).SingleOrDefault();
                Suplier.TenNcc = DisplayName;
                Suplier.Phone = Phone;
                Suplier.Adress = Address;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.TenNcc = DisplayName;
            });
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.NhacungCaps.Where(x => x.IdNcc == SelectedItem.IdNcc);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Object = DataProvider.Ins.DB.NhacungCaps.Where(x => x.IdNcc == SelectedItem.IdNcc).SingleOrDefault();
                DataProvider.Ins.DB.NhacungCaps.Remove(Object);
                DataProvider.Ins.DB.SaveChanges();
                List.Remove(Object);



            });
        }
    }
}
