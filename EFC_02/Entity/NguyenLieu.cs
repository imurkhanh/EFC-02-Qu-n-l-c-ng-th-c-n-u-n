using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_02.Entity
{
    public class NguyenLieu
    {
        public int NguyenLieuId { get; set; }
        [Required]
        public string TenNguyenLieu {  get; set; }

    }
}
