using EFC_02.Entity;
using EFC_02.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_02.Services
{
    public class MonAnService : IMonAnService
    {
        private readonly AppDbContext dbContext;
        public MonAnService()
        {
            dbContext = new AppDbContext();
        }
        public void ThemMonAn()
        {
            Console.WriteLine("Nhập ID loại món ăn: ");
            int loaiMonAnId = int.Parse(Console.ReadLine());
            var loaiMonAn = dbContext.LoaiMonAn.Find(loaiMonAnId);
            if (loaiMonAn == null)
            {
                Console.WriteLine("Chưa có loại món ăn này");
            }
            else
            {
                Console.WriteLine("Thêm mới món ăn");
                Console.WriteLine("Tên món: ");
                string tenMon = Console.ReadLine();
                Console.WriteLine("Ghi chú: ");
                string ghiChu = Console.ReadLine();
                
                var monAn = new MonAn
                {
                    TenMon = tenMon,
                    GhiChu = ghiChu,
                    LoaiMonAnId = loaiMonAnId,
                };
                dbContext.Add(monAn);
                dbContext.SaveChanges();
                Console.WriteLine("Thêm món ăn thành công");
            }
        }

        public void TimKiemMonAnTheoTenNguyenLieu()
        {
            Console.WriteLine("Nhập tên nguyên liệu:");
            string tenNguyenLieu = Console.ReadLine();
            var monAnList = dbContext.MonAn
                            .Join(dbContext.CongThuc, ma=>ma.MonAnId,ct=>ct.MonAnId, (ma, ct) => new {MonAn = ma, CongThuc = ct})
                            .Join(dbContext.NguyenLieu, ct => ct.CongThuc.NguyenLieuId, nl => nl.NguyenLieuId, (ct, nl) => new {CongThuc=ct,NguyenLieu=nl})
                            .Where(x => x.NguyenLieu.TenNguyenLieu.ToLower() == tenNguyenLieu.ToLower())
                            .Select(x=>x.CongThuc.MonAn.TenMon)
                            .ToList();
            if(monAnList.Count > 0)
            {
                Console.WriteLine($"Danh sách món ăn chứa nguyên liệu {tenNguyenLieu}");
                foreach (var monAn in monAnList)
                {
                    Console.WriteLine($"{monAn}");
                }              
            }
            else 
            {
                Console.WriteLine("Không tìm thấy món có nguyên liệu tương ứng");
            }
        }
    }
}
