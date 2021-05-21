using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(2)]
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }
        public DateTime FaturaTarih { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(75)]
        public string FaturaVergiDairesi { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string FaturaSaat { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FaturaTeslimEden { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FaturaTeslimAlan { get; set; }
        public decimal FaturaTutar { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}