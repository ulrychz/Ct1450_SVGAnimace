using System.Drawing;

namespace Ct1450_SVGAnimace.Models
{
    public class Kruh : Tvar
    {
        public Kruh(int pozX, int pozY, Color barva, TypTvaru typTvaru, int polomer) : base(pozX, pozY, barva, typTvaru)
        {
            Polomer = polomer;
        }
        public int Polomer { get; set; }
    }
}
