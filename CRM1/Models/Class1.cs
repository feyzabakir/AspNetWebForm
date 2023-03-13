using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM1
{
    [Table("SIPARISLER")]
    public partial class SIPARISLER
    {
        [Key]
        public int SIP_ID { get; set; }
        public int? SPT_ID { get; set; }
        public int? MUS_ID { get; set; }
        public int? URN_ID { get; set; }
        public decimal? MIKTAR { get; set; }
        public decimal? FIYAT { get; set; }
        public string BIRIM { get; set; }
        public decimal? TOPLAM { get; set; }
        public string SIP_NO { get; set; }

    }
}