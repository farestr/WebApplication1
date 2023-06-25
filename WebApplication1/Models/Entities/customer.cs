using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
    public class Customer
    {
        [Key]
        [DisplayName("id:")]
        public int id { get; set; }
        [DisplayName("name")]
        public string name { get; set; }

        [DisplayName("phone")]
        public int phone { get; set; }
  
        public int CityID { get; set; }

        [ForeignKey("CityID")]
        public virtual Cities cities { get; set; }
    }
}
