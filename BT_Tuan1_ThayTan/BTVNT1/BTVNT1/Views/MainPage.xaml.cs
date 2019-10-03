using BTVNT1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BTVNT1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnHello(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HelloScreen());
        }

        private void btnSum(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CalculatorSum());
        }

        private void btnStackLayout(object sender, EventArgs e)
        {
            DisplayAlert("Thông báo!", "Giao diện đang được xây dựng!", "Thoát");
        }

        private void btnAbsoluteLayout(object sender, EventArgs e)
        {
            DisplayAlert("Thông báo!", "Giao diện đang được xây dựng!", "Thoát");
        }

        private void btnGridLayout(object sender, EventArgs e)
        {
            DisplayAlert("Thông báo!", "Giao diện đang được xây dựng!", "Thoát");
        }

        private void btnLogin(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Login());
        }

        private void btnFlexLayout(object sender, EventArgs e)
        {
            DisplayAlert("Thông báo!", "Giao diện đang được xây dựng!", "Thoát");
        }

        private void btnScrollView(object sender, EventArgs e)
        {
            DisplayAlert("Thông báo!", "Giao diện đang được xây dựng!", "Thoát");
        }

        private void btnEntry(object sender, EventArgs e)
        {
            DisplayAlert("Thông báo!", "Giao diện đang được xây dựng!", "Thoát");
        }

        private void btnListView(object sender, EventArgs e)
        {
            DisplayAlert("Thông báo!", "Giao diện đang được xây dựng!", "Thoát");
        }

        private void btnCalculator(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Calculator());
        }
    }
}
