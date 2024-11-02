using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McERPSystem.Services.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string Name { get; set; }
        public ArticleType Type { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public enum ArticleType
    {
        Screw,
        Plate,
        Instrument,
        Rack,
        Tray,
        StainlessSteelCase,
        Container,
        Filter,
        Label,
        PlasticSecuritySeal,
        Mesh,
        InstrumentHolders,
        SpiralDrill,
        Template,
        Prostheses
    }
}
