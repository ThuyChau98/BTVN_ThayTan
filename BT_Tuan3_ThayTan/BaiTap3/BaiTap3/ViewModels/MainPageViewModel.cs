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
    public class MainPageViewModel : ViewModelBase
    {
        public static MainPageViewModel Instance { get; set; }

        private List<LoaiHoa> _loaiHoaList;
        private LoaiHoa _loaiHoaSelected;

        public List<LoaiHoa> LoaiHoaList
        {
            get => _loaiHoaList;
            set => SetProperty(ref _loaiHoaList, value);
        }
        public LoaiHoa LoaiHoaSelected
        {
            get => _loaiHoaSelected;
            set => SetProperty(ref _loaiHoaSelected, value);
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Instance = this;

            OnLoaiHoaSelectedCommand = new DelegateCommand(OnLoaiHoaSelectedCommandExecute);
            ThemLoaiHoaCommand = new DelegateCommand(ThemLoaiHoaCommandExecute);
            ThemHoaCommand = new DelegateCommand(ThemHoaCommandExecute);

            LoadLoaiHoaList();
        }

        public async void LoadLoaiHoaList()
        {
            LoaiHoaList = new List<LoaiHoa>();
            LoaiHoaList = await App.Database.GetLoaiHoaListAsync();
        }

        #region OnLoaiHoaSelectedCommand

        public ICommand OnLoaiHoaSelectedCommand { get; set; }

        async void OnLoaiHoaSelectedCommandExecute()
        {
            NavigationParameters loaiHoaPara = new NavigationParameters()
            {
                {
                    "parsedLoaiHoa", LoaiHoaSelected
                }
            };
            await NavigationService.NavigateAsync("HoaListPage", loaiHoaPara);
        }
        #endregion

        #region ThemLoaiHoaCommand

        public ICommand ThemLoaiHoaCommand { get; set; }

        async void ThemLoaiHoaCommandExecute()
        {
            await NavigationService.NavigateAsync("ThemLoaiHoaPage");
        }
        #endregion

        #region ThemHoaCommand

        public ICommand ThemHoaCommand { get; set; }
        async void ThemHoaCommandExecute()
        {
            NavigationParameters hoaPara = new NavigationParameters()
            {
                {
                    "parsedHoa", new Hoa()
                }
            };
            await NavigationService.NavigateAsync("ThemHoaPage", hoaPara);
        }
        
        #endregion
    }
}
