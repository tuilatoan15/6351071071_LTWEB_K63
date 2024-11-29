using LAB01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB01.Controllers
{
    public class MotorbikeStoreController : Controller
    {
        // GET: MotorbikeStore
        QLBanXeGanMayEntities1 data;

        public MotorbikeStoreController()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QLBanXeGanMayEntities1"].ConnectionString;
  
            data = new QLBanXeGanMayEntities1(connectionString);
        }
        private List<XEGANMAY> LayXeMoi(int count)
        {
            return data.XEGANMAYs.OrderByDescending(x => x.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var xemoi = LayXeMoi(5);
            return View(xemoi);
        }
        public ActionResult Loaixe()
        {
            var Loaixe = from lx in data.LOAIXEs select lx;
            return PartialView(Loaixe);
        }
        public ActionResult Nhaphanphoi()
        {
            var Nhaphanphoi = from npp in data.NHAPHANPHOIs select npp;
            return PartialView(Nhaphanphoi);
        }
        public ActionResult SPTheoloaixe(int id)
        {
            var xe = from x in data.XEGANMAYs where x.MaXe == id select x;
            return View(xe);
        }
        public ActionResult SPTheoNPP(int id)
        {
            var xe = from x in data.XEGANMAYs where x.MaNPP == id select x;
            return View(xe);
        }
        public ActionResult Details(int id)
        {
            var xe = from x in data.XEGANMAYs
                     where x.MaXe == id
                     select x;
            return View(xe.Single());
        }
    }
}