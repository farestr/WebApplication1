using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
    public class Cities
    {
        [Key]
        [DisplayName("City: *")]
        public int CityID { get; set; }
        [DisplayName("City Name")]
        public string CityName { get; set; }
    }
}
