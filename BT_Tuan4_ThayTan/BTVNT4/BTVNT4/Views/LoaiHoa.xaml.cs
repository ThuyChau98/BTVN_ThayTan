using BTVNT4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BTVNT4.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class LoaiHoa : ContentPage
  {
    public LoaiHoa()
    {
      InitializeComponent();
      BindingContext = new LoaihoaViewModel();
    }
  }
}