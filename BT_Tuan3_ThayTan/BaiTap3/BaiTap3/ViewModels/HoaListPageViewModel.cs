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
    public class HoaListPageViewModel : ViewModelBase
    {
        private IEnumerable<Hoa> _hoaShowList;
        private Hoa _hoaSelected;
        private LoaiHoa _parsedLoaiHoa;

        public List<Hoa> HoaList { get; set; }
        public IEnumerable<Hoa> HoaShowList
        {
            get => _hoaShowList;
            set => SetProperty(ref _hoaShowList, value);
        }
        public LoaiHoa ParsedLoaiHoa 
        {
            get => _parsedLoaiHoa;
            set => SetProperty(ref _parsedLoaiHoa, value);
        }
        public Hoa HoaSelected
        {
            get => _hoaSelected;
            set => SetProperty(ref _hoaSelected, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            ParsedLoaiHoa = (LoaiHoa)parameters["parsedLoaiHoa"];
            
            if (ParsedLoaiHoa != null)
                LoadHoaList();
        }

        public HoaListPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            OnHoaSelectedCommand = new DelegateCommand(OnHoaSelectedCommandExecute);
        }

        public async void LoadHoaList()
        {
            Title = ParsedLoaiHoa.TenLoai;
            HoaList = new List<Hoa>();
            HoaList = await App.Database.GetHoaListAsync();
            HoaShowList = HoaList.Where(i => i.MaLoai == ParsedLoaiHoa.MaLoai);
        }

        #region OnHoaSelectedCommand
        public ICommand OnHoaSelectedCommand { get; set; }

        async void OnHoaSelectedCommandExecute()
        {
            NavigationParameters hoaPara = new NavigationParameters()
            {
                {
                    "parsedHoa", HoaSelected
                }
            };
            await NavigationService.NavigateAsync("ThemHoaPage", hoaPara);
        }
        #endregion
    }
}
