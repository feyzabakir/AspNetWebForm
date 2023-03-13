namespace CRM1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MUSTERILER")]
    public partial class MUSTERILER
    {
        [Key]
        public int CUS_ID { get; set; }

        public DateTime? CDate { get; set; }

        [StringLength(50)]
        public string Unvan { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string SabitTel { get; set; }

        [StringLength(50)]
        public string Adres { get; set; }
    }
}
