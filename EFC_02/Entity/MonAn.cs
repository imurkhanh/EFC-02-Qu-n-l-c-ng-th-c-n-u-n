using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_02.Entity
{
    public class MonAn
    {
        public int MonAnId { get; set; }
        [Required]
        public string TenMon {  get; set; }
        public string GhiChu {  get; set; }
        public int LoaiMonAnId { get; set; }
        public LoaiMonAn LoaiMonAn { get; set; }
    }
}
