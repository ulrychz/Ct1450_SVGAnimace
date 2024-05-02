using System.Drawing;

namespace Ct1450_SVGAnimace.Models
{
    public class Ctverec : Tvar
    {
        public Ctverec(int pozX, int pozY, Color barva, TypTvaru typTvaru, int stranaA) : base(pozX, pozY, barva, typTvaru)
        {
            StranaA = stranaA;
        }
        public int StranaA { get; set; }
    }
}
