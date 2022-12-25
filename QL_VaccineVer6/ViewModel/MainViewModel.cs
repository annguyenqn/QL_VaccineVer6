using QL_VaccineVer6.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QL_VaccineVer6.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<TonKho> _TonKhoList;
        public ObservableCollection<TonKho> TonKhoList { get => _TonKhoList; set { _TonKhoList = value; OnPropertyChanged(); } }
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand SuplierCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }

        // mọi thứ xử lý sẽ nằm trong này
        public MainViewModel()
        {

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                Isloaded = true;
                if (p == null)
                    return;
                p.Hide();
                LoginWindown loginWindow = new LoginWindown();
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null)
                    return;
                var loginVM = loginWindow.DataContext as LoginViewModel;

                if (loginVM.IsLogin)
                {
                    p.Show();
                    LoadTonKhoData();
                }
                else
                {
                    p.Close();
                }
            }
              );
            SuplierCommand = new RelayCommand<object>((p) => { return true; }, (p) => { SuplierWindown wd = new SuplierWindown(); wd.ShowDialog(); });
            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CustomerWindown wd = new CustomerWindown(); wd.ShowDialog(); });
            ObjectCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ObjectWindown wd = new ObjectWindown(); wd.ShowDialog(); });
            UserCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UserWindown wd = new UserWindown(); wd.ShowDialog(); });
            InputCommand = new RelayCommand<object>((p) => { return true; }, (p) => { InputWindown wd = new InputWindown(); wd.ShowDialog(); });
            OutputCommand = new RelayCommand<object>((p) => { return true; }, (p) => { OutputWindown wd = new OutputWindown(); wd.ShowDialog(); });
            //kiểm tra có được nhấn không( dựa vào chức vụ) , tạo windown mới và showdialog lên.
            //var a = DataProvider.Ins.DB.BenhNhans.ToList();
        }
        void LoadTonKhoData()
        {
            TonKhoList = new ObservableCollection<TonKho>();

            var objectList = DataProvider.Ins.DB.Vaccines;

            int i = 1;
            foreach (var item in objectList)
            {
                var inputList = DataProvider.Ins.DB.InputIfs.Where(p => p.IdVac == item.IdVac);
                var outputList = DataProvider.Ins.DB.OutputIfs.Where(p => p.IdVac == item.IdVac);

                int sumInput = 0;
                int sumOutput = 0;

                if (inputList != null)
                {
                    sumInput = (int)inputList.Sum(p => p.Soluong);
                }
                if (outputList != null)
                {
                    sumOutput = (int)outputList.Sum(p => p.Soluong);
                }

                TonKho tonkho = new TonKho();
                tonkho.STT = i;
                tonkho.SoLuong = sumInput - sumOutput;
                tonkho.vaccine= item;

                TonKhoList.Add(tonkho);

                i++;
            }

        }
    }
}
