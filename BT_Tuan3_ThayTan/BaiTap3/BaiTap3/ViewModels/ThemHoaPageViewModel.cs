using BaiTap3.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace BaiTap3.ViewModels
{
    public class ThemHoaPageViewModel : ViewModelBase
    {
        private string _tenHoa;
        private int _maLoai;
        private string _moTa;
        private long _donGia;
        private string _hinh;

        public ObservableCollection<string> LoaiHoaList { get; set; }
        public Hoa ParsedHoa { get; set; }
        public string TenHoa
        { 
            get => _tenHoa;
            set => SetProperty(ref _tenHoa, value);
        }
        public int MaLoai 
        { 
            get => _maLoai;
            set => SetProperty(ref _maLoai, value); 
        }
        public string MoTa 
        {
            get => _moTa;
            set => SetProperty(ref _moTa, value);
        }
        public long DonGia 
        { 
            get => _donGia; 
            set => SetProperty(ref _donGia, value); 
        }
        public string Hinh
        { 
            get => _hinh; 
            set => SetProperty(ref _hinh, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            ParsedHoa = (Hoa)parameters["parsedHoa"];
            TenHoa = ParsedHoa.TenHoa;
            MaLoai = ParsedHoa.MaLoai - 1; //vi index cua picker bat dau tu 0, maloai o DB bat dau tu 1
            MoTa = ParsedHoa.MoTa;
            DonGia = ParsedHoa.DonGia;
            Hinh = ParsedHoa.Hinh;
        }

        public ThemHoaPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            ThemHoaCommand = new DelegateCommand(ThemHoaCommandExecute);
            XoaHoaCommand = new DelegateCommand(XoaHoaCommandExecute);

            LoadLoaiHoaList();
        }

        public async void LoadLoaiHoaList()
        {
            LoaiHoaList = new ObservableCollection<string>();
            List<LoaiHoa> list = await App.Database.GetLoaiHoaListAsync();

            foreach (LoaiHoa i in list)
                LoaiHoaList.Add(i.TenLoai);
        }

        #region ThemHoaCommand
        public ICommand ThemHoaCommand { get; set; }
        async void ThemHoaCommandExecute()
        {
            ParsedHoa.TenHoa = TenHoa;
            ParsedHoa.MaLoai = MaLoai + 1; //vi index cua picker bat dau tu 0, maloai o DB bat dau tu 1
            ParsedHoa.MoTa = MoTa;
            ParsedHoa.DonGia = DonGia;
            ParsedHoa.Hinh = Hinh;

            await App.Database.SaveHoaAsync(ParsedHoa);
            await NavigationService.GoBackToRootAsync();
        }
        #endregion

        #region XoaHoaCommand
        public ICommand XoaHoaCommand { get; set; }
        async void XoaHoaCommandExecute()
        {
            await App.Database.DeleteHoaAsync(ParsedHoa);
            await NavigationService.GoBackToRootAsync();
        }
        #endregion
    }
}
