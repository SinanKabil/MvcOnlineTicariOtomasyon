using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string KargoTakipKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string KargoTakipAciklama { get; set; }
        public DateTime KargoTakipTarih { get; set; }
    }
}