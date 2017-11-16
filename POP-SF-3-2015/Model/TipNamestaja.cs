using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_3_2015.Model
{
    public class TipNamestaja
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public TipNamestaja()
        {

        }

        public TipNamestaja(int id, string naziv)
        {
            this.Id = id;
            this.Naziv = naziv;
            
        }
    }
}
