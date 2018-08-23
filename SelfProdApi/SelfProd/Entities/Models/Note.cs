using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfProd.Entities.Models
{
    public class Note : BaseEntity
    {
        public string Text { get; set; }
        public DateTime Published { get; set; }
    }
}
