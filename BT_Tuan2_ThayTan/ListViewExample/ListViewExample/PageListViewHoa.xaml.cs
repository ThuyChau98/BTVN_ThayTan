using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListViewExample.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViewExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListViewHoa : ContentPage
    {
        ObservableCollection<Hoa> listHoa = new ObservableCollection<Hoa>();
        public PageListViewHoa()
        {
            InitializeComponent();
            listHoa.Add(new Hoa { tenHoa = "Đón xuân", gia = 50000, hinh = "cuc_9.jpg", moTa = "Hoa cúc các màu: Trắng, Vàng, Cam" });
            listHoa.Add(new Hoa { tenHoa = "Hồn nhiên", gia = 60000, hinh = "cuc_2.jpg", moTa = "Hoa cúc vàng, cam, lá măng" });
            listHoa.Add(new Hoa { tenHoa = "Tím chung thủy", gia = 40000, hinh = "cuc_3.jpg", moTa = "Hoa cúc tím" });
            lsvHoa.ItemsSource = listHoa;
        }
    }
}