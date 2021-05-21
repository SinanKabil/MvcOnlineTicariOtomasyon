using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string KargoAciklama { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string KargoTakipKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string KargoPersonel { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string KargoAlici { get; set; }
        public DateTime KargoTarih { get; set; }
    }
}