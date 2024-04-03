using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    public class Parki
    {
        public int ID_Parku { get; set; }
        public string Nazwa { get; set; }
        public string Miejsce { get; set; }
        public bool CzyOtwarty { get; set; }
        public RodzajParku Typ { get; set; }
        public int Rozmiar { get; set; }
        public bool CzyInspekcja { get; set; }


        public override string ToString()
        {
            return $"{ID_Parku}, {Nazwa}, {Miejsce}, {CzyOtwarty}, {Typ}, {Rozmiar}, {CzyInspekcja}";
        }
    }

    public enum RodzajParku
    {
        ochronyścisłej,
        czynnej,
        krajobrazowej
    }
}
