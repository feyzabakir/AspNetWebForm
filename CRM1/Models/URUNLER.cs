namespace CRM1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("URUNLER")]
    public partial class URUNLER
    {
        [Key]
        public int URN_ID { get; set; }

    
        public string UNAME { get; set; }


        public string CODE { get; set; }

        public decimal? FIYAT { get; set; }


        public string BRM_ADI { get; set; }

        public DateTime? CDATE { get; set; }

        public string FPATH { get; set; }
    }
   
}
