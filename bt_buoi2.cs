using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Student> danhSachHocSinh = new List<Student>
        {
            new Student { Id = 1, Name = "An", Age = 16 },
            new Student { Id = 2, Name = "Minh Chau", Age = 17 },
            new Student { Id = 3, Name = "Chi Minh", Age = 15 },
            new Student { Id = 4, Name = "Hao", Age = 18 },
            new Student { Id = 5, Name = "Nhan", Age = 14 }
        };

        // a. in toan bo
        Console.WriteLine("Danh sach toan bo hoc sinhK: ");
        danhSachHocSinh.ForEach(hs => Console.WriteLine($"{hs.Id} - {hs.Name} - {hs.Age}"));

        // b.in 15-18
        Console.WriteLine("\nHoc sinh co tuoi tu 15-18:");
        var locTheoTuoi = danhSachHocSinh.Where(hs => hs.Age >= 15 && hs.Age <= 18);
        foreach (var hocSinh in locTheoTuoi)
        {
            Console.WriteLine($"{hocSinh.Id} - {hocSinh.Name} - {hocSinh.Age}");
        }

        // c.hoc sinh co ten bd bang A
        Console.WriteLine("\nHoc sinh co ten bat dau bang chu 'A':");
        var locTheoTen = danhSachHocSinh.Where(hs => hs.Name.StartsWith("A"));
        foreach (var hocSinh in locTheoTen)
        {
            Console.WriteLine($"{hocSinh.Id} - {hocSinh.Name} - {hocSinh.Age}");
        }

        // d.tong tuoi
        var tongTuoi = danhSachHocSinh.Sum(hs => hs.Age);
        Console.WriteLine($"\nTong tuoi cua tat ca hoc sinh: {tongTuoi}");

        // e.hoc sinh lon tuoi nhat
        var hocSinhLonTuoiNhat = danhSachHocSinh.OrderByDescending(hs => hs.Age).FirstOrDefault();
        Console.WriteLine($"\nHoc sinh co tuoi lon nhat: {hocSinhLonTuoiNhat.Name} - {hocSinhLonTuoiNhat.Age}");

        // f. sap xep theo tuoi tang dan
        Console.WriteLine("\nDanh sach hoc sinh theo tuoi tang dan:");
        var sapXepTheoTuoi = danhSachHocSinh.OrderBy(hs => hs.Age);
        foreach (var hocSinh in sapXepTheoTuoi)
        {
            Console.WriteLine($"{hocSinh.Id} - {hocSinh.Name} - {hocSinh.Age}");
        }
    }
}
