using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_02.Entity
{
    public class LoaiMonAn
    {
        public int LoaiMonAnId {  get; set; }
        [Required]
        public string TenLoai {  get; set; }
        public IList<MonAn> MonAn { get; set; }
    }
}
