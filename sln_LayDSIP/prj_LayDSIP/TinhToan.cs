using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Net.NetworkInformation;

namespace prj_LayDSIP
{
    public class TinhToan
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Nhap so thap phan: ");
            //int t;
            //t = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Chuyen sang nhi phan la : " + ThapPhanSangNhiPhan(t));
            //Console.WriteLine("Not cua nhi phan la :     " + Not(ThapPhanSangNhiPhan(t)));
            //Console.WriteLine("Or cua so vua nhap la:    " + Or("11000000","00000000"));
            //Console.WriteLine("------------------------------------------------------------------------------------");
            //Console.WriteLine("Chuyen sang nhi phan la : " + ThapPhanSangNhiPhan(t));
            //Console.WriteLine("Not cua nhi phan la :     " + Not(ThapPhanSangNhiPhan(t)));
            //Console.WriteLine("And cua so vua nhap la :  " + And(ThapPhanSangNhiPhan(t), Not(ThapPhanSangNhiPhan(t))));
            
            string ip = GetIPAddress();
            string sm = GetSubnet(ip);
            string b = GetBroadcast(ip, sm);
            string fIp = FirstAddress(ip, sm);

            Console.WriteLine("Ip address : " + GetIPAddress());          
            Console.WriteLine("Subnet Mask: " + sm);
            Console.WriteLine("Broadcast : " + b);
            Console.WriteLine("First Address: " + fIp);

            Console.WriteLine("Danh sach dia chi IP");
            foreach(var i in Ping())
            {
                Console.WriteLine(i);
            }            





            Console.ReadLine();
        }
        public static string GetSubnet(string s)
        {
            int x = Convert.ToInt32(s.Substring(0, 3));
            if(x >= 0 && x <= 127)
            {
                return "255.0.0.0";
            }
            else if(x >= 128 && x <= 191)
            {
                return "255.255.0.0";
            }
            else if(x >= 192 && x <= 223)
            {
                return "255.255.255.0";
            }
            return "";
        }

        public static string GetIPAddress()
        {
            IPHostEntry myHost;
            string ip = "";
            myHost = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ipa in myHost.AddressList)
            {
                if (ipa.AddressFamily.ToString() == "InterNetwork")
                {
                    ip = ipa.ToString();
                    //Console.WriteLine(ipa.ToString());
                }
                
            }
            return ip;
        }

        public static string GetBroadcast(string ipv4, string subnet)
        {
            string[] ip = ipv4.Split('.');
            string[] sm = subnet.Split('.');
            string[] bc = new string[4];
            for (int i = 0; i<4; i++)
            {
                ip[i] = ThapPhanSangNhiPhan(Convert.ToInt32(ip[i]));
                sm[i] = ThapPhanSangNhiPhan(Convert.ToInt32(sm[i]));   
            }
            for (int i = 0; i < 4; i++)
            {
                sm[i] = Not(sm[i]);
                bc[i] = Or(ip[i], sm[i]);
            }        
            return NhiPhanSangThapPhan(bc[0]+"."+bc[1]+"."+bc[2]+"."+bc[3]);
        }

        public static string ThapPhanSangNhiPhan(int number)
        {
            string a;
            a = Convert.ToString(number, 2);
            if(a.Length < 8)
            {               
                int tam = 8 - a.Length;
                for(int i=1; i <= tam ; i++)
                {
                    a = "0" + a;
                }
            }
            return a;
        }
        public static string NhiPhanSangThapPhan(string b)
        {
            string[] lb = b.Split('.');
            string[] r = new string[4];
            for (int i=0; i < 4; i++)
            {
                r[i] = Convert.ToInt32(lb[i], 2).ToString();
            }
            return r[0]+"."+r[1]+"."+r[2]+"."+r[3];
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
                    if (Convert.ToInt32(a[i]) == 49)
                    {
                        c = c + "1";
                    }
                    else if (Convert.ToInt32(a[i]) == 48)
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
                if (Convert.ToInt32(a[i]) == Convert.ToInt32(b[i]) && Convert.ToInt32(a[i]) == 49)
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
        public static string FirstAddress(string ipv4, string subnet)
        {
            string[] ip = ipv4.Split('.');
            string[] sm = subnet.Split('.');
            string[] bc = new string[4];
            for (int i = 0; i < 4; i++)
            {
                ip[i] = ThapPhanSangNhiPhan(Convert.ToInt32(ip[i]));
                sm[i] = ThapPhanSangNhiPhan(Convert.ToInt32(sm[i]));
            }
            for (int i = 0; i < 4; i++)
            {
                bc[i] = And(ip[i], sm[i]);
            }
            return NhiPhanSangThapPhan(bc[0] + "." + bc[1] + "." + bc[2] + "." + bc[3]);
        }
        public static List<string> Ping()
        {
            string ip = GetIPAddress();
            string sm = GetSubnet(ip);
            string b = GetBroadcast(ip, sm);
            string f = FirstAddress(ip, sm);
            string[] lf = f.Split('.');
            int[] l = new int[4];
            for(int i =0; i<4; i++)
            {
                l[i] = int.Parse(lf[i]);
            }
            List<string> dsIp = new List<string>();

            //try
            //{
                Ping myPing = new Ping();
                for (int i = l[3]+1; i < 255; i++)
                {
                    string x = l[0] + "." + l[1] + "." + l[2] + "." + i.ToString();
                    PingReply reply = myPing.Send(x, 1000);
                    Console.WriteLine("Dia chi da ping : " + x);
                    if (reply == null)
                    {
                        dsIp.Add(reply.Address.ToString());
                    }
                }
            //}
           // catch
           // {

           // }

            if (dsIp.Count == 0)
            {
                Console.WriteLine("Khong Co dia chi ip nao.");
            }
            return dsIp;
        }
    }
}
