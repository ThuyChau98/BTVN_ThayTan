using BaiTap3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3.Services.SQLite
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<LoaiHoa>().Wait();
            _database.CreateTableAsync<Hoa>().Wait();
        }
        #region LoaiHoaQuery
        public Task<List<LoaiHoa>> GetLoaiHoaListAsync()
        {
            return _database.Table<LoaiHoa>().ToListAsync();
        }

        public Task<LoaiHoa> GetLoaiHoaAsync(int maLoai)
        {
            return _database.Table<LoaiHoa>()
                            .Where(i => i.MaLoai == maLoai)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveLoaiHoaAsync(LoaiHoa loaiHoa)
        {
            if (loaiHoa.MaLoai != 0)
            {
                return _database.UpdateAsync(loaiHoa);
            }
            else
            {
                return _database.InsertAsync(loaiHoa);
            }
        }
        #endregion

        #region HoaQuery
        public Task<List<Hoa>> GetHoaListAsync()
        {
            return _database.Table<Hoa>().ToListAsync();
        }

        public Task<Hoa> GetHoaAsync(int maHoa)
        {
            return _database.Table<Hoa>()
                            .Where(i => i.MaHoa == maHoa)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveHoaAsync(Hoa hoa)
        {
            if (hoa.MaHoa != 0)
            {
                return _database.UpdateAsync(hoa);
            }
            else
            {
                return _database.InsertAsync(hoa);
            }
        }

        public Task<int> DeleteHoaAsync(Hoa hoa)
        {
            return _database.DeleteAsync(hoa);
        }
        #endregion
    }
}
