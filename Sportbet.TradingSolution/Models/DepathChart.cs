using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportbet.TradingSolution.Models
{
    public class DepthChartData
    {
        public string Position { get; set; }
        public Player Player { get; set; }
        public int? PositionDepth { get; set; }
 
    }
}
