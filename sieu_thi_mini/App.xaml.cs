using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace sieu_thi_mini
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public class MaDangNhapService
    {
        private string _maDangNhap;

        public string MaDangNhap
        {
            get { return _maDangNhap; }
            set { _maDangNhap = value; }
        }
    }

    public class MatKhauService
    {
        private string _matKhau;

        public string MatKhau
        {
            get { return _matKhau; }
            set { _matKhau = value; }
        }
    }
    public partial class App : Application
    {
        public static MaDangNhapService MaDangNhapService { get; } = new MaDangNhapService();
        public static MatKhauService MatKhauService { get; } = new MatKhauService();

        public static string ConnectionString = @"Data Source=LAPTOP-8OU0CA2C\SQLEXPRESS;Initial Catalog=QuanLySieuThi;Integrated Security=True; Connect Timeout=3600";
        //ConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLyBanHangNhanh;Integrated Security=True;";


    }
}
