using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ToDoEntity
    {
        [Key]
        public int ID { get; set; }
        public string Item { get; set; }
        public bool IsDone { get; set; }

    }
}
