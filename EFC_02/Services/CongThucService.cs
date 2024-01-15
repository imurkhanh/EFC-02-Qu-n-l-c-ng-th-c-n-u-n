using EFC_02.Entity;
using EFC_02.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_02.Services
{
    public class CongThucService : ICongThucService
    {
        private readonly AppDbContext dbContext;
        public CongThucService()
        {
            dbContext = new AppDbContext();
        }
        public void HienThiCongThucNauAnTheoTenMon_TenNguyenLieu()
        {
            Console.WriteLine("Nhập tên món ăn:");
            string tenMonAn = Console.ReadLine();
            var congThucList = dbContext.MonAn
                               .Join(dbContext.CongThuc, ma => ma.MonAnId, ct => ct.MonAnId, (ma, ct) => new { MonAn = ma, CongThuc = ct })
                               .Join(dbContext.NguyenLieu, ct => ct.CongThuc.NguyenLieuId, nl => nl.NguyenLieuId, (ct, nl) => new { CongThuc = ct, NguyenLieu = nl })
                               .Where(x=>x.CongThuc.MonAn.TenMon.ToLower()== tenMonAn.ToLower())
                               .Select(x => new {x.NguyenLieu.TenNguyenLieu, x.CongThuc.CongThuc.SoLuong, x.CongThuc.CongThuc.DonViTinh })
                               .ToList();
            if(congThucList.Count >0 )
            {
                Console.WriteLine("Danh sách công thức nấu ăn:");
                Console.WriteLine($"Tên món: {tenMonAn}");
                foreach (var congThuc in congThucList)
                {
                    Console.WriteLine($"{congThuc.TenNguyenLieu} - {congThuc.SoLuong} - {congThuc.DonViTinh}");
                }    
            }
            else
            {
                Console.WriteLine("Chưa có công thức món ăn cần tìm");
            }    
        }

        public void ThemCongThucNauAn()
        {
            Console.WriteLine("Nhập món ăn ID: ");
            int monAnId = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập nguyên liệu ID: ");
            int nguyenLieuId = int.Parse(Console.ReadLine());
            var monAn = dbContext.MonAn.Find(monAnId);
            if( monAn == null )
            {
                return;
            }    
            var nguyenLieu = dbContext.NguyenLieu.Find(nguyenLieuId);
            if( nguyenLieu == null )
            { 
                return; 
            }
            Console.WriteLine("Thêm công thức nấu ăn");
            Console.WriteLine("Số lượng: ");
            int soLuong = int.Parse(Console.ReadLine());
            Console.WriteLine("Đơn vị tính: ");
            string donViTinh = Console.ReadLine();

            var congThuc = new CongThuc
            {
                MonAnId = monAnId,
                NguyenLieuId = nguyenLieuId,
                SoLuong = soLuong,
                DonViTinh = donViTinh,
            };
            dbContext.Add(congThuc );
            dbContext.SaveChanges();
            Console.WriteLine("Thêm công thức thành công");
        }
    }
}
