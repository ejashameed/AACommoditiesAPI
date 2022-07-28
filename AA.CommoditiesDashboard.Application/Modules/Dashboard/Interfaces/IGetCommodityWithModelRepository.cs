using AA.CommoditiesDashboard.Application.Modules.Dashboard.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.Modules.Dashboard.Interfaces
{
    public interface IGetCommodityWithModelRepository
    {
        Task<List<CommodityWithModel>> GetAsync();
    }
}
