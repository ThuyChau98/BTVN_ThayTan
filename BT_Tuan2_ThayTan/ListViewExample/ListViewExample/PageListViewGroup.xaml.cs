using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListViewExample.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace ListViewExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListViewGroup : ContentPage
    {
        public PageListViewGroup()
        {
            InitializeComponent();
            LoaiHoa l = new LoaiHoa();
            lstHoa.ItemsSource = l.listLoaiHoa;
        }
    }
}