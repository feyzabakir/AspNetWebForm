namespace CRM1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KULLANICILAR")]
    public partial class KULLANICILAR
    {
        [Key]
        public int KUL_ID { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

        public DateTime? CDATE { get; set; }

        [StringLength(50)]
        public string USERN { get; set; }

        [StringLength(50)]
        public string PASSW { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string CSM { get; set; }
    }
}
