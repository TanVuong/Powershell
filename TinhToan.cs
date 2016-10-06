using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prj_LayDSIP
{
    class TinhToan
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Nhap so thap phan: ");
            int t;
            t = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Chuyen sang nhi phan la : " + ThapPhanSangNhiPhan(t));
            Console.WriteLine("Not cua nhi phan la :     " + Not(ThapPhanSangNhiPhan(t)));
            Console.WriteLine("Or cua so vua nhap la:    " + Or(ThapPhanSangNhiPhan(t), Not(ThapPhanSangNhiPhan(t))));
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Chuyen sang nhi phan la : " + ThapPhanSangNhiPhan(t));
            Console.WriteLine("Not cua nhi phan la :     " + Not(ThapPhanSangNhiPhan(t)));
            Console.WriteLine("And cua so vua nhap la :  " + And(ThapPhanSangNhiPhan(t), Not(ThapPhanSangNhiPhan(t))));

            Console.ReadLine();
        }
        public static string ThapPhanSangNhiPhan(int number)
        {
            string a;
            a = Convert.ToString(number, 2);
            if(a.Length < 15)
            {               
                int tam = 8 - a.Length;
                for(int i=1; i <= tam ; i++)
                {
                    a = "0" + a;
                }
            }
            return a;
        }
        public static string Not(string b)
        {
            string nb = "";
            for(int i=0; i < b.Length; i++)
            {
                if (Convert.ToInt32(b[i]) == 48) // 48 la so 0
                    nb = nb + "1";
                else if (Convert.ToInt32(b[i]) == 49) // 49 la so 1
                    nb = nb + "0";
            }

            return nb;
        }
        public static string Or(string a, string b)
        {
            string c = "";
            if(a.Length != b.Length)
            {
                Console.WriteLine("Ban truyen du lieu khong hop le. Hai so phai bang nhau.");
                return "null";
            }

            for (int i=0; i < a.Length; i++)
            {
                if (Convert.ToInt32(a[i]) == Convert.ToInt32(b[i]))
                {
                    if (Convert.ToInt32(a[i]) == 1)
                    {
                        c = c + "1";
                    }
                    else if (Convert.ToInt32(a[i]) == 0)
                    {
                        c = c + "0";
                    }
                }
                else if (Convert.ToInt32(a[i]) != Convert.ToInt32(b[i]))
                {
                    c = c + "1"; 
                }
            }

            return c;
        }
        public static string And(string a, string b)
        {
            string x = "";
            if (a.Length != b.Length)
            {
                Console.WriteLine("Ban truyen du lieu khong hop le. Hai so phai bang nhau.");
                return "null";
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (Convert.ToInt32(a[i]) == Convert.ToInt32(b[i]) && Convert.ToInt32(a[i]) == 1)
                {
                    x = x + "1";
                }
                else
                {
                    x = x + "0";
                }
            }

            return x;
        }
    }
}
