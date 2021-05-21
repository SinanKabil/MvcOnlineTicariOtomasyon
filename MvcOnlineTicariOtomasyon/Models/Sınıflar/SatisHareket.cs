using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisHareketID { get; set; }
        public DateTime SatisHareketTarih { get; set; }
        public int SatisHareketAdet { get; set; }
        public decimal SatisHareketFiyat { get; set; }
        public decimal SatisHareketToplamTutar { get; set; }
        public int UrunId { get; set; }
        public int PersonelId { get; set; }
        public int CariId { get; set; }
        public virtual Urun Urun { get; set; }
        public virtual Personel Personel { get; set; }
        public virtual Cariler Cariler { get; set; }
    }
}