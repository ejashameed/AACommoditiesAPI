using AA.CommoditiesDashboard.Application.Domain;
using AA.CommoditiesDashboard.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.Interfaces.Repositories
{
    public interface ICommodityDataRepository
    {
        Task<List<CommodityData>> GetAsync();
       
    }
}
