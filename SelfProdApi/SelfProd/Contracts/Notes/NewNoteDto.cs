using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfProd.Contracts.Notes
{
    public class NewNoteDto
    {
        public string Text { get; set; }
        public DateTime Published { get; set; }
    }
}
