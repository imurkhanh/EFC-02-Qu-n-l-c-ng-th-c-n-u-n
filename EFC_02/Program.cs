using EFC_02.IServices;
using EFC_02.Services;

void Main()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.InputEncoding = System.Text.Encoding.UTF8;
    ICongThucService congThucService = new CongThucService();
    IMonAnService monAnService = new MonAnService();

    Console.WriteLine("-----QUẢN LÝ CÔNG THỨC NẤU ĂN (EFC-02)-----");
    Console.WriteLine("1. Hiển thị danh sách công thức nấu ăn");
    Console.WriteLine("2. Tìm kiếm món ăn theo tên nguyên liệu");
    Console.WriteLine("3. Thêm mới món ăn");
    Console.WriteLine("4. Thêm công thức nấu ăn");
    Console.WriteLine("5. Thoát chương trình");

    string choice;
    do
    {
        Console.WriteLine();
        Console.Write("Nhập lựa chọn (1-5): ");
        choice = Console.ReadLine();
        switch(choice)
        {
            case "1":
                congThucService.HienThiCongThucNauAnTheoTenMon_TenNguyenLieu();
                break;
            case "2":
                monAnService.TimKiemMonAnTheoTenNguyenLieu();
                break;
            case "3":
                monAnService.ThemMonAn();
                break;
            case "4":
                congThucService.ThemCongThucNauAn();
                break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ.Vui lòng nhập lại");
                break;
        }

    } while (choice!="5");

}
Main();
