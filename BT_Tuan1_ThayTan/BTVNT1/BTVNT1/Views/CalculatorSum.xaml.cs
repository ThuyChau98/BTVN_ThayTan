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
    public partial class CalculatorSum : ContentPage
    {
        public CalculatorSum()
        {
            InitializeComponent();
        }

        private void btnSum(object sender, EventArgs e)
        {
            double a, b, sum;
            a = double.Parse(txtSoA.Text);
            b = double.Parse(txtSoB.Text);
            sum = a + b;
            txtTong.Text = sum.ToString();
        }

        private void btnBackHome(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }
    }
}