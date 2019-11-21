using BTVNT4.Interface;
using BTVNT4.Models;
using BTVNT4.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BTVNT4.ViewModels
{
  public class LoaihoaViewModel : INotifyPropertyChanged
  {
    private Loaihoa loaihoa;
    public ILoaihoaRepository loaihoaRepository;
    public ICommand AddLoaiHoa { get; private set; }
    public ICommand UpdateLoaiHoa { get; private set; }
    public ICommand DeleteLoaiHoa { get; private set; }
    public LoaihoaViewModel()
    {
      loaihoaRepository = new LoaihoaRepository();
      LoadLoaihoa();
      AddLoaiHoa = new Command(Insert);
      UpdateLoaiHoa = new Command(Update, CanExe);
      DeleteLoaiHoa = new Command(Delete, CanExe);
      loaihoa = new Loaihoa();
    }

    private void Delete(object obj)
    {
      loaihoaRepository.Delete(loaihoa);
      LoadLoaihoa();
    }

    private void Update(object obj)
    {
      loaihoaRepository.Update(loaihoa);
      LoadLoaihoa();
    }

    private bool CanExe(object arg)
    {
      if(loaihoa == null || loaihoa.Maloai == 0)
      {
        return false;
      }
      else
      {
        return true;
      }
    }

    private void Insert(object obj)
    {
      loaihoaRepository.Insert(loaihoa);
      LoadLoaihoa();
    }

    public Loaihoa Loaihoa
    {
      get{ return loaihoa; }
      set
      {
        loaihoa = value;
        RaisePropertyChanged("Loaihoa");
        ((Command)UpdateLoaiHoa).ChangeCanExecute();
      }
    }
    public int Maloai
    {
      get { return loaihoa.Maloai; }
      set { loaihoa.Maloai = value;
        RaisePropertyChanged("Maloai");
      }
    }
    public string Tenloai
    {
      get { return loaihoa.Tenloai; }
      set { loaihoa.Tenloai = value;
        RaisePropertyChanged("Tenloai");
      }
    }
    ObservableCollection<Loaihoa> loaihoalist;
    public ObservableCollection<Loaihoa> Loaihoalist
    {
      get { return loaihoalist; }
      set
      {
        loaihoalist = value;
        RaisePropertyChanged("Loaihoalist");
      }
    }

    public void LoadLoaihoa() 
    {
      Loaihoalist = loaihoaRepository.GetLoaihoas();
    }

    private void RaisePropertyChanged(string v)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(v));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
