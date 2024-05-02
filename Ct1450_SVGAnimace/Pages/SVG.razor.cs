using Ct1450_SVGAnimace.Models;
using System.Drawing;

namespace Ct1450_SVGAnimace.Pages
{
    public partial class SVG
    {
        public SVG()
        {
            SvgWidth = 1600; 
            SvgHeight = 800;
        }

        public int SvgWidth { get; set; }
        public int SvgHeight { get; set;}
        public int MinRozmer { get; set; } = 20;
        public int MaxRozmer { get; set; } = 80;
        public List<Models.Tvar> SvgTvaryList { get; set; } = new List<Models.Tvar>();

        private Random rnd = new Random();
        private int TypTvaruCount => Enum.GetNames(typeof(Models.TypTvaru)).Length;
        private void PridatTvar()
        {
            Models.TypTvaru typTvaru = (TypTvaru)rnd.Next(TypTvaruCount);
            int stranaA = rnd.Next(MinRozmer, MaxRozmer + 1);
            int pozX = rnd.Next(SvgWidth - stranaA);
            Color barva = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Models.Tvar? tvar = null;
            switch (typTvaru)
            {
                case TypTvaru.Ctverec:
                    tvar = new Models.Ctverec(pozX, rnd.Next(SvgHeight - stranaA), barva, typTvaru, stranaA);
                    break;
                case TypTvaru.Obdelnik:
                    int stranaB = rnd.Next(MinRozmer, MaxRozmer + 1);
                    tvar = new Models.Obdelnik(pozX, rnd.Next(SvgHeight - stranaB), barva, typTvaru, stranaA,stranaB);
                    break;
                case TypTvaru.Kruh:
                    tvar = new Models.Kruh(pozX, rnd.Next(SvgHeight - stranaA), barva, typTvaru, stranaA);
                    break;
            }
            if(tvar != null)
                SvgTvaryList.Add(tvar);

        }
    }
}
