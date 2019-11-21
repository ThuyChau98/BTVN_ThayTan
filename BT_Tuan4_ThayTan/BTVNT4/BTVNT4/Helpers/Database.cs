using BTVNT4.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTVNT4.Helpers
{
  class Database
  {
    string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
    public Database()
    {
      try
      {
        using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
        {
          connection.CreateTable<Loaihoa>();
          connection.CreateTable<Hoa>();
        }
      }
      catch
      {

      }
    }
    #region "Loai Hoa"
    public List<Loaihoa> GetLoaihoas()
    {
      try
      {
        using(var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
        {
          return connection.Table<Loaihoa>().ToList();
        }
      }
      catch
      {
        return null;
      }
    }
    public Loaihoa GetLoaihoaById(int id)
    {
      try
      {
        using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
        {
          var dsls = from lhs in connection.Table<Loaihoa>().ToList()
                     where lhs.Maloai == id
                     select lhs;
          return dsls.ToList<Loaihoa>().FirstOrDefault();
        }
      }
      catch
      {
        return null;
      }
    }
    public bool InsertLoaihoa(Loaihoa lh)
    {
      try
      {
        using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
        {
          connection.Insert(lh);
          return true;
        }
      }
      catch
      {
        return false;
      }
    }
    public bool UpdateLoaihoa(Loaihoa lh)
    {
      try
      {
        using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
        {
          connection.Update(lh);
          return true;
        }
      }
      catch
      {
        return false;
      }
    }
    public bool DeleteLoaihoa(Loaihoa lh)
    {
      try
      {
        using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
        {
          connection.Delete(lh);
          return true;
        }
      }
      catch
      {
        return false;
      }
    }
    #endregion
  }
}
