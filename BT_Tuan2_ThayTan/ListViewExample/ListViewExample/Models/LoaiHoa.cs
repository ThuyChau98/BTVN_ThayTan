using System;
using System.Collections.Generic;
using System.Text;
namespace ListViewExample.Models
{
    public class LoaiHoa : List<Hoa>
    {
        public string tenLoai { get; set; }
        private LoaiHoa(string ten)
        {
            tenLoai = ten;
        }
        public IList<LoaiHoa> listLoaiHoa { get; set; }
        public LoaiHoa()
        {
            List<LoaiHoa> l = new List<LoaiHoa>
            {
                new LoaiHoa("Hoa cúc")
                {
                    new Hoa{ tenHoa = "Đón xuân", gia = 50000, hinh= "cuc_9.jpg", moTa ="Hoa cúc các màu: trắng, vàng, cam"},
                    new Hoa{ tenHoa = "Hồn nhiên", gia = 60000, hinh= "cuc_2.jpg", moTa ="Hoa cúc vàng, cam, lá măng"},
                    new Hoa{ tenHoa = "Tím thủy chung", gia = 45000, hinh= "cuc_3.jpg", moTa ="Hoa cúc tím"},
                },
                new LoaiHoa("Hoa cưới")
                {
                    new Hoa{ tenHoa = "Dây tơ hồng", gia = 250000, hinh= "cuoi_1.jpg", moTa ="Hoa hồng màu hồng đậm, hoa hồng xanh, các loại lá măng"},
                    new Hoa{ tenHoa = "Cầu thủy tinh", gia = 220000, hinh= "cuoi_2.jpg", moTa ="Hoa hồng và hoa thủy tinh trắng"},
                    new Hoa{ tenHoa = "Duyên thầm", gia = 26000, hinh= "cuoi_3.jpg", moTa ="Hoa cúc trắng, baby, lá măng"},
                }
            };
            listLoaiHoa = l;
        }
    }
}
