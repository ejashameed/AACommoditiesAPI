using AA.CommoditiesDashboard.Application.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.Interfaces.ReadRepositories
{
    public interface IReadDataRepository
    {
        Task<List<CumulativePnLData>> GetCumulativePnLAsync();

        Task<List<HistoricalKeyActionsData>> GetHistoricalActionsAsync();


        Task<List<YearlyPnLData>> GetYearlyPnLAsync();


       
        
    }
}
