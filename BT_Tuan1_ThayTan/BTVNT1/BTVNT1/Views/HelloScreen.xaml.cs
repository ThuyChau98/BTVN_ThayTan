using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BTVNT1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelloScreen : ContentPage
    {
        public HelloScreen()
        {
            InitializeComponent();
        }

        private void btnChao(object sender, EventArgs e)
        {
            String Hoten = txtHoten.Text;
            DisplayAlert("Chào", "Chào bạn: " + Hoten, "Thoát");
        }
    }
}