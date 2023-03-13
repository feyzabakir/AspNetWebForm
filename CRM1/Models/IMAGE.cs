using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace CRM1.Models
{
    [Table("IMAGE")]
    public partial class IMAGE
    {
        [Key] 
        public int RESIM_ID { get; set; }


        public string RESIM1 { get; set; }


        public string RESIM2 { get; set; }


        public string RESIM3{ get; set; }

     
    }
}