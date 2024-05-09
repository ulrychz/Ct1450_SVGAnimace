using Ct1450_SVGAnimace.Models;
using Newtonsoft.Json;
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

        protected override async Task OnInitializedAsync()
        {
            await Nahrat();
        }
        public int SvgWidth { get; set; }
        public int SvgHeight { get; set;}
        public int MinRozmer { get; set; } = 20;
        public int MaxRozmer { get; set; } = 80;
        public int KrokAnimace { get; set; } = 1;
        public bool AnimaceBezi { get; set; } = false;
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
        private void OdebratTvar()
        {
            if (SvgTvaryList.Any())
            {
                SvgTvaryList.RemoveAt(SvgTvaryList.Count - 1);
            }
        }

        private async Task Ulozit()
        {
            string json = JsonConvert.SerializeObject(SvgTvaryList, 
                new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto });

            await localStorage.SetItemAsync("dataTvary", json);
        }

        private async Task Nahrat()
        {
            var json = await localStorage.GetItemAsync<string>("dataTvary");
            if (json != null)
            {
                List<Models.Tvar>? products = JsonConvert.DeserializeObject<List<Models.Tvar>>(json, 
                    new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                if (products != null) 
                    SvgTvaryList.AddRange(products);
            }

        }
        private async Task Smazat(Microsoft.AspNetCore.Components.Web.MouseEventArgs e)
        {
            await localStorage.RemoveItemAsync("dataTvary");
        }

        private async Task PosunTvaru()
        {
            AnimaceBezi = true;
            do 
            {
                foreach (var item in SvgTvaryList)
                {
                    item.Posun(KrokAnimace, SvgWidth, SvgHeight);
                }
                StateHasChanged();
                await Task.Delay(10);
            } while (AnimaceBezi);
        }

        private void PosunZastavit()
        {
            AnimaceBezi = false;
        }
    }
}
