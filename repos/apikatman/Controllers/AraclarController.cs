using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace apikatman.Controllers
{
    public class AraclarController:ApiController
    {
        muratvidanjorEntities _ent = new muratvidanjorEntities();
        [HttpGet]


        public List<AracTip> TumAraclariGetir()
        {
            return _ent.Araclars.Select(p => new AracTip() {

                AracID = p.AracID,
                Aracadi = p.Aracadi,
                Aracmodel = p.Aracmodel,
                Aracsayisi = p.Aracsayisi,
                Aracıkullanan = p.Aracıkullanan,
                Aractipi = p.Aractipi

            }).ToList();
        }

        [HttpPost]

        public Boolean AracEkle(AracTip yeniarac)
        {
            try
            {
                Araclar a = new Araclar();
                a.Aracsayisi = yeniarac.Aracsayisi;
                a.Aracadi = yeniarac.Aracadi;
                a.Aracmodel = yeniarac.Aracmodel;
                a.Aractipi = yeniarac.Aractipi;
            a.Aracıkullanan = yeniarac.Aracıkullanan;

                _ent.Araclars.Add(a);
                _ent.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

         
              
            
        }

    }


    public class AracTip
    {

        public int AracID { get; set; }
        public string Aracmodel { get; set; }
        public string Aracadi { get; set; }
        public string Aractipi { get; set; }
        public string Aracıkullanan { get; set; }
        public Nullable<int> SoforID { get; set; }
        public string Aracsayisi { get; set; }
    }
}