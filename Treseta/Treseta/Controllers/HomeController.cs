using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Treseta.Models;

namespace Treseta.Controllers
{
    public class HomeController : Controller
    {
        static List<Room> sobeZaIgru  =  new List<Room>();
        public ActionResult Index()
        {
            KorisnikModel korisnk = new KorisnikModel();
            return View();
        }
        /// <summary>
        /// koristi se za login provjerava dali postoji korisni
        /// </summary>
        /// <returns> view s sobama ili obavjest o krivom loginu</returns>
        [HttpPost]
        public ActionResult GlavniIzbornik(KorisnikModel korisnik)
        {
            sobeZaIgru.Add(new Room() { imeSobe="prva soba"});
            sobeZaIgru.Add(new Room() { imeSobe = "druga soba" });
            sobeZaIgru.Add(new Room() { imeSobe = "treca soba" });
            //povezi se s bazom
            //provjeri dali postoji u bazi korisnik
            if (korisnik.userName == null || korisnik.userName == String.Empty)//pazi za null vrjednosti sjeba ce te
                return View("~/Views/Home/Index.cshtml");
            if (korisnik.userName.Equals("ja"))//izvede se ako postoji korisnik
            {
                ViewData["korisnik"] = "ovo je test prjenosa";
                return View(sobeZaIgru); //omogucava prikaz liste soba u vievu izbornika
            }
            else
            {
                ViewBag.Massege = 1;//ovaj red bi ko mora biti za pokreniti skriput za upozorito o neuspjelom loginu
                return View("~/Views/Home/Index.cshtml");
            }
        }
        /// <summary>
        /// aktivira se pritiskom na signup u pocetnom zaslonu
        /// </summary>
        /// <returns>vraca view na registraciski obrazac</returns>
        public ActionResult Register()
        {

            return View();
        }

        public ActionResult Partija()
        {
            return View();
        }

        public ActionResult Room(string imeSobe)
        {
            ViewData["imeSobe"] = imeSobe;
            return View();
        }

        public ActionResult Pravila()
        {
            return View();
        }


    }
}