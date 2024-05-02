using System.Drawing;

namespace Ct1450_SVGAnimace.Models
{
    public abstract class Tvar
    {
        public Tvar(int pozX, int pozY, Color barva, TypTvaru typTvaru)
        {
            PozX = pozX;
            PozY = pozY;
            Barva = barva;
            TypTvaru = typTvaru;
        }

        public int PozX { get; set; }
        public int PozY { get; set;}
        public Color Barva { get; set; }
        public TypTvaru TypTvaru { get; set; }
    }
}
