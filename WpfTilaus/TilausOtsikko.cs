using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTilaus
{
    class TilausOtsikko
    {
        private DateTime tilausPvm;

        public int TilausNumero { get; set; }
        public string AsiakkaanNimi { get; set; }
        public int AsiakasNumero { get; set; }
        public string ToimitusOsoite { get; set; }
        public DateTime TilausPvm {
            get
            {
                return tilausPvm;
            }
            set
            {
                if( value <= DateTime.Today)
                {
                    tilausPvm = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public DateTime ToimitusPvm { get; set; }

    }
}
