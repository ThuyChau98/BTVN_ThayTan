using Prism;
using Prism.Ioc;
using BaiTap3.ViewModels;
using BaiTap3.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using BaiTap3.Services.SQLite;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BaiTap3
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        static Database _database;
        public static Database Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Hoa.db3"));
                }
                return _database;
            }
        }

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>("MainPage");
            containerRegistry.RegisterForNavigation<ThemLoaiHoaPage>("ThemLoaiHoaPage");
            containerRegistry.RegisterForNavigation<HoaListPage>("HoaListPage");
            containerRegistry.RegisterForNavigation<ThemHoaPage>("ThemHoaPage");
        }
    }
}
