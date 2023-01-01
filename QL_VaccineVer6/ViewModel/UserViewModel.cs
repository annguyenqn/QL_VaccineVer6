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
    public class UserViewModel : BaseViewModel
    {
        private ObservableCollection<Model.User> _List;
        public ObservableCollection<Model.User> List { get => _List; set { _List = value; OnPropertyChanged(); } }


        private ObservableCollection<Model.UserRole> _UserRole;
        public ObservableCollection<Model.UserRole> UserRole { get => _UserRole; set { _UserRole = value; OnPropertyChanged(); } }
        private Model.User _SelectedItem;
        public Model.User SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.HoTen;
                    UserName = SelectedItem.UserName;
                    SelectedUserRole = SelectedItem.UserRole;
                }
            }
        }
        private Model.UserRole _SelectedUserRole;
        public Model.UserRole SelectedUserRole
        {
            get => _SelectedUserRole;
            set
            {
                _SelectedUserRole = value;
                OnPropertyChanged();
            }
        }
        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public UserViewModel()
        {
            List = new ObservableCollection<Model.User>(DataProvider.Ins.DB.Users);
            UserRole = new ObservableCollection<Model.UserRole>(DataProvider.Ins.DB.UserRoles);
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedUserRole == null)
                    return false;
                return true;

            }, (p) =>
            {
                var Object = new Model.User() { HoTen = DisplayName, IdRole = SelectedUserRole.IdRole ,UserName = UserName };

                DataProvider.Ins.DB.Users.Add(Object);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Object);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedUserRole == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Users.Where(x => x.IdUser == SelectedItem.IdUser);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Object = DataProvider.Ins.DB.Users.Where(x => x.IdUser == SelectedItem.IdUser).SingleOrDefault();
               
                Object.IdRole = SelectedUserRole.IdRole;
                Object.UserName = UserName;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.HoTen = DisplayName;
            });
        }

    }

}
