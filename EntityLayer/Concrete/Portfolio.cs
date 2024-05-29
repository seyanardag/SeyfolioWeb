using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Portfolio
    {
        [Key]
        public int PortfolioId { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public string SmallImageUrl { get; set; }       
        public string ProjectUrl { get; set; }
        public string ProjectName { get; set; }
        public string Price { get; set; }
        public bool Status { get; set; }       
        public int  CompletionValue { get; set; }
    }
}
