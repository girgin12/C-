using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace sinavize.Controllers
{
    public class sinavController : ApiController
    {
        uygulamaEntities _ent = new uygulamaEntities();

        [HttpGet]
        public List<kayit> TumkullanicilariGoster()
        {
            return _ent.kayits.ToList();
        }
        [HttpGet]
        public List<kayit> KullaniciAra(string kelime)
        {
            return _ent.kayits.Where(p => p.adi.Contains(kelime) || p.soyadi.Contains(kelime) || p.telefon.Contains(kelime)).ToList();
        }
        [HttpGet]
        public kayit kullanicigetirIDyeGore(int KullaniciID)
        {
            return _ent.kayits.Find(KullaniciID);
        }

        [HttpGet]
        public bool kullanicisil(int kullaniciID)
        {
            try
            {
                kayit k = _ent.kayits.Find(kullaniciID);
                if (k != null)

                {
                    _ent.kayits.Remove(k);
                    _ent.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
         }
               [HttpGet]

               public List<kayit> kullanicisil2(int kullaniciID)
               {
                try
                {
                    kayit k = _ent.kayits.Find(kullaniciID);
                    if (k != null)

                    {
                        _ent.kayits.Remove(k);
                        _ent.SaveChanges();

                    }
                    return TumkullanicilariGoster();
                }
                catch (Exception)
                {
                    return null;
                }

            }

              [HttpPost]
              public bool KullaniciEkle(kayit veri)
                 {
            try
            {

                _ent.kayits.Add(veri);
                _ent.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
                   

                   }


        [HttpPost]
        public List<kayit> KullaniciEkle2(kayit veri)
        {
            try
            {

                _ent.kayits.Add(veri);
                _ent.SaveChanges();
                return TumkullanicilariGoster();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public bool KullaniciGuncelle( kayit yeni)
        {
            try
            {
                kayit eski = _ent.kayits.Find(yeni.kullaniciID);
                eski.adi = yeni.adi;
                eski.soyadi = yeni.soyadi;
                eski.mail = yeni.mail;
                eski.telefon = yeni.telefon;
                _ent.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
    }
