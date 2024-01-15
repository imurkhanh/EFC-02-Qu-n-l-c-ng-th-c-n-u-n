using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_02.Entity
{
    public class CongThuc
    {
        public int CongThucId { get; set; }
        public int MonAnId { get; set; }
        public MonAn MonAn { get; set; }
        public int NguyenLieuId {  get; set; }
        public NguyenLieu NguyenLieu { get; set; }
        [Required]
        public int SoLuong { get; set; }
        [Required]
        public string DonViTinh {  get; set; }
    }
}
