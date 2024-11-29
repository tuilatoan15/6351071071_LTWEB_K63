﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB01.Models
{
    public class Giohang
    {
        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QLBANXEGANMAYConnectionString"].ConnectionString;
        private QLBanXeGanMayEntities1 data;

        // Properties
        public int iMaXe { get; set; }
        public string sTenXe { get; set; }
        public string sAnhbia { get; set; }
        public double dDongia { get; set; }
        public int iSoluong { get; set; }
        public double dThanhtien
        {
            get { return iSoluong * dDongia; }
        }

        // Constructor
        public Giohang(int MaXe)
        {
            // Initialize the data context
            data = new QLBanXeGanMayEntities1(connectionString);
            iMaXe = MaXe;
            // Assign the motorcycle information based on MaXe
            var xe = data.XEGANMAYs.SingleOrDefault(x => x.MaXe == MaXe);
            sTenXe = xe.TenXe;
            sAnhbia = xe.Anhbia;
            dDongia = double.Parse(xe.Giaban.ToString());
            iSoluong = 1;
        }
    }
}