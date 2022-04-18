using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace apikatman.Controllers
{
    public class FirmalarController:ApiController
    {
        muratvidanjorEntities _ent = new muratvidanjorEntities();
        [HttpGet]

        public List<FirmaTip> TumFirmalariGetir()
        {
            return _ent.Firmalars.Select(p => new FirmaTip() {
               
                FirmaID= p.FirmaID,
                Firmaadi = p.Firmaadi,
                Firmamail = p.Firmamail,
                Firmatel = p.Firmatel,
                Aracadi = p.Araclar.Aracadi,
                Soforadi = p.Soforler.Soforadi,
              
                 
             

            }).ToList();
        }

        [HttpPost]
        public List<FirmaTip> FirmaEkle(FirmaTip firmaverisi)
        {

            try
            {
                Firmalar f = new Firmalar();
                f.AracID = firmaverisi.AracID;
                f.Firmaadi = firmaverisi.Firmaadi;
                f.FirmaID = firmaverisi.FirmaID;
                f.Firmamail = firmaverisi.Firmamail;
                f.Firmatel = firmaverisi.Firmatel;
                f.SoforID = firmaverisi.SoforID;
                _ent.Firmalars.Add(f);
                _ent.SaveChanges();
                return TumFirmalariGetir();
            }
            catch (Exception)
            {
                return null;
                
            }

          
        }

    }

    public class FirmaTip
    {

        public int FirmaID { get; set; }
        public int AracID { get; set; }
        public int SoforID { get; set; }
        public string Firmaadi { get; set; }
        public string Firmatel { get; set; }
        public string Firmamail { get; set; }

        public virtual Araclar Araclar { get; set; }
        public virtual Soforler Soforler { get; set; }
        public string Aracadi { get;  set; }
        public string Soforadi { get; set; }
    }
}