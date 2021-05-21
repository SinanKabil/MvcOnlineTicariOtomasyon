using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(50)]
        public string MesajGönderen { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string MesajAlıcı { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string MesajKonu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string MesajIcerik { get; set; }
        public DateTime MesajTarih { get; set; }
    }
}