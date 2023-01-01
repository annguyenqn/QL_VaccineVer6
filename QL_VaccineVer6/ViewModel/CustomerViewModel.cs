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
    public class CustomerViewModel : BaseViewModel
    {
        private ObservableCollection<Model.BenhNhan> _List;
        public ObservableCollection<Model.BenhNhan> List { get => _List; set { _List = value; OnPropertyChanged(); } }    //hiển thị 

        private ObservableCollection<Model.Vaccine> _Vaccine;
        public ObservableCollection<Model.Vaccine> Vaccine { get => _Vaccine; set { _Vaccine = value; OnPropertyChanged(); } }

        private BenhNhan _SelectedItem;
        public BenhNhan SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.HoTen;
                    Phone = SelectedItem.Phone;
                    Address = SelectedItem.DiaChi;
                    SelectedVaccine = SelectedItem.Vaccine;
                    ContractDate = SelectedItem.NgayTiem;
                    ;
                }
            }
        }
        private Model.Vaccine _SelectedVaccine;
        public Model.Vaccine SelectedVaccine
        {
            get => _SelectedVaccine;
            set
            {
                _SelectedVaccine = value;
                OnPropertyChanged();
            }
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }


        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }


        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }



        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }


        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public CustomerViewModel()
        {
            List = new ObservableCollection<BenhNhan>(DataProvider.Ins.DB.BenhNhans);
            Vaccine = new ObservableCollection<Model.Vaccine>(DataProvider.Ins.DB.Vaccines);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var benhNhan = new Model.BenhNhan() { IdBn = Guid.NewGuid().ToString(), HoTen = DisplayName, Phone = Phone, DiaChi = Address ,NgayTiem = ContractDate , IdVac = SelectedVaccine.IdVac };

                DataProvider.Ins.DB.BenhNhans.Add(benhNhan);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(benhNhan);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.BenhNhans.Where(x => x.IdBn == SelectedItem.IdBn);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Suplier = DataProvider.Ins.DB.BenhNhans.Where(x => x.IdBn == SelectedItem.IdBn).SingleOrDefault();
                Suplier.HoTen = DisplayName;
                Suplier.Phone = Phone;
                Suplier.DiaChi = Address;
                Suplier.IdVac = SelectedVaccine.IdVac;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.HoTen = DisplayName;
            });
        }
    }

}
