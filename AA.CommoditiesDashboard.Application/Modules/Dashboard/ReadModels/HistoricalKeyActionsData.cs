using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.Domain.ReadModels
{
    public class HistoricalKeyActionsData
    {
        public DateTime Date{ get; set; }
        public string Commodity{ get; set; }
        public string Model { get; set; }
        public string Contract { get; set; }
        public decimal Price { get; set; }
        public int Position { get; set; }
        public int NewTradeAction { get; set; }
        public decimal PnlDaily { get; set; }

    }
}
