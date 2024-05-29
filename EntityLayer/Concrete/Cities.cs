using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Cities
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public bool isSelected { get; set; }
    }
}
