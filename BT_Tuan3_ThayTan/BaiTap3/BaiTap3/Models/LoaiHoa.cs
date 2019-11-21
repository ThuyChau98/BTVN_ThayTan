using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTap3.Models
{
    public class LoaiHoa
    {
        [PrimaryKey, AutoIncrement]
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }

    }
}
