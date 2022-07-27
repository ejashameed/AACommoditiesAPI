using AA.CommoditiesDashboard.Application.Domain;
using AA.CommoditiesDashboard.Application.Shared.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.Shared.Interfaces
{
    public interface ICommodityDataRepository
    {
        Task<List<CommodityData>> GetAsync();

    }
}
