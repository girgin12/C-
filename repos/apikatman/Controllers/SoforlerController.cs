using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace apikatman.Controllers
{
    public class SoforlerController : ApiController
    {
        muratvidanjorEntities _ent = new muratvidanjorEntities();
        [HttpGet]
        public List<SoforTip> TumSoforleriGetir()
        {
            return _ent.Soforlers.Select(p => new SoforTip()
            {
                SoforID = p.SoforID,
                Soforadi = p.Soforadi,
                SoforSoyadi = p.SoforSoyadi,
                Sofortel = p.Sofortel,
                Soformail = p.Soformail,
                Soforehliyet = p.Soforehliyet,
                Soforarac = p.Soforarac
            }).ToList();

        }
        [HttpPost]

        public List<SoforTip> SoforEkle(SoforTip soforverisi)
        {
            try
            {
                Soforler f = new Soforler();
                f.SoforID = soforverisi.SoforID;
                f.Soforadi = soforverisi.Soforadi;
                f.SoforSoyadi = soforverisi.SoforSoyadi;
                f.Soforarac = soforverisi.Soforarac;
                _ent.Soforlers.Add(f);
                _ent.SaveChanges();
                return TumSoforleriGetir();

            }
            catch (Exception)
            {

                return null;
            }
        }
    }

           
         

    public class SoforTip
    {
        public int SoforID { get; set; }
        public string Soforadi { get; set; }
        public string SoforSoyadi { get; set; }
        public string Sofortel { get; set; }
        public string Soformail { get; set; }
        public string Sofortc { get; set; }
        public string Soforehliyet { get; set; }
        public string Soforarac { get; set; }
    }
}