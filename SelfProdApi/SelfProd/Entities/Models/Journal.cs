using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfProd.Entities.Models
{
    public class Journal
    {
        public int JournalId { get; set; }
        public string Entry { get; set; }
        public DateTime Published { get; set; }
    }
}
