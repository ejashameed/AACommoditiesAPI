using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.Shared.Domain.Models
{
    public class CommodityData
    {
        [Key]
        public int Id { get; set; }
        public int CommodityId { get; set; }
        public DateTime Date { get; set; }
        public string? Contract { get; set; }
        public decimal Price { get; set; }
        public int Position { get; set; }
        public int NewTradeAction { get; set; }
        public decimal PnlDaily { get; set; }
    }
}
