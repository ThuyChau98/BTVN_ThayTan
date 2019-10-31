using BaiTap3.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace BaiTap3.ViewModels
{
    public class ThemLoaiHoaPageViewModel : ViewModelBase
    {
        private string _tenLoai;

        public string TenLoai 
        { 
            get => _tenLoai; 
            set => SetProperty(ref _tenLoai, value); 
        }

        public ThemLoaiHoaPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            ThemLoaiHoaCommmand = new DelegateCommand(ThemLoaiHoaCommmandExecute);
        }

        #region ThemLoaiHoaCommmand

        public ICommand ThemLoaiHoaCommmand { get; set; }
        async void ThemLoaiHoaCommmandExecute()
        {
            LoaiHoa loaiHoa = new LoaiHoa
            {
                TenLoai = TenLoai
            };
            await App.Database.SaveLoaiHoaAsync(loaiHoa);
            await NavigationService.GoBackAsync();
        }
        #endregion
        
    }
}
