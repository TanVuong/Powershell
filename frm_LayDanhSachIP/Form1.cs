﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace frm_LayDanhSachIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string LayIP()
        {
            string IP="";
            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddScript("Get-NetIPAddress | where-object{$_.AddressFamily -eq 'IPv4' -and $_.PrefixOrigin -eq 'Dhcp'} | select IPAddress");
                ps.Invoke();
                Collection<PSObject> psOutput = ps.Invoke();
                foreach(PSObject psOutputItem in psOutput)
                {
                    if (psOutputItem != null)
                    {
                        IP = psOutputItem.ToString();
                        Console.WriteLine(psOutputItem);
                    }                   
                }
            }
            if(string.Compare(IP,"",true)==0)
            {
                MessageBox.Show("Không tìm thấy địa chỉ IP nào!");
            }
            IP = IP.Substring(12, 13);
            return IP;
        }

        public static string TinhSubnet(string s)
        {
            int x = Convert.ToInt32(s.Substring(0, 3));
            if (x > 0 && x <= 126)
            {
                return "255.0.0.0";
            }
            else if (x >= 128 && x <= 191)
            {
                return "255.255.0.0";
            }
            else if (x >= 192 && x <= 223)
            {
                return "255.255.255.0";
            }
            return "";
        }

        public static string ThapPhanSangNhiPhan(int number)
        {
            string a;
            a = Convert.ToString(number, 2);
            if (a.Length < 8)
            {
                int tam = 8 - a.Length;
                for (int i = 1; i <= tam; i++)
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
            for (int i = 0; i < 4; i++)
            {
                r[i] = Convert.ToInt32(lb[i], 2).ToString();
            }
            return r[0] + "." + r[1] + "." + r[2] + "." + r[3];
        }

        public static string Not(string b)
        {
            string nb = "";
            for (int i = 0; i < b.Length; i++)
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
            if (a.Length != b.Length)
            {
                Console.WriteLine("Ban truyen du lieu khong hop le. Hai so phai bang nhau.");
                return "null";
            }

            for (int i = 0; i < a.Length; i++)
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

        public static string TinhBroadcast(string ipv4, string subnet)
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
                sm[i] = Not(sm[i]);
                bc[i] = Or(ip[i], sm[i]);
            }
            return NhiPhanSangThapPhan(bc[0] + "." + bc[1] + "." + bc[2] + "." + bc[3]);
        }

    }
}
