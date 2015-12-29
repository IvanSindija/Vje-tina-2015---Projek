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

        public ActionResult Index()
        {
            KorisnikModel korisnk = new KorisnikModel();
            return View();
        }

        //bude pozvan u trenutcima kad se trba vratiti na glavni izbornik iz partije
        [HttpGet]
        public ActionResult GlavniIzbornik(string korisnik)
        {
            List<Room> sobe = SingletonListaSoba.dohvatiListuSoba();
            ViewData["korisnik"] = korisnik;// nemoj ovo prominiti
            return View(sobe); //omogucava prikaz liste soba u vievu izbornika
        }
        /// <summary>
        /// koristi se za login provjerava dali postoji korisni
        /// </summary>
        /// <returns> view s sobama ili obavjest o krivom loginu</returns>
        [HttpPost]
        public ActionResult GlavniIzbornik(KorisnikModel korisnik)
        {
            //povezi se s bazom
            //provjeri dali postoji u bazi korisnik
            if (korisnik.userName == null || korisnik.userName == String.Empty)//pazi za null vrjednosti sjeba ce te
                return View("~/Views/Home/Index.cshtml");
            if (true)//izvede se ako postoji korisnik
            {
                List<Room> sobe = SingletonListaSoba.dohvatiListuSoba();
                ViewData["korisnik"] = korisnik.userName;// nemoj ovo prominiti
                return View(sobe); //omogucava prikaz liste soba u vievu izbornika
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

        public ActionResult Partija(string imeSobe, string korisnickoIme)
        {
            ViewData["imeSobe"] = imeSobe;
            ViewData["korisnickoIme"] = korisnickoIme;     
            return View();
        }

        public ActionResult Pravila()
        {
            return View();
        }


    }
}