using AA.CommiditesDashboard.Infrastructure.Shared.Helpers;
using AA.CommoditiesDashboard.Application.Domain.ReadModels;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommiditesDashboard.Infrastructure.ReadRepositories.Dashboard
{
    public class GetYearlyPnlDataRepository : IGetYearlyPnlDataRepository
    {
        private readonly SqlHelper _sqlHelper;
        public GetYearlyPnlDataRepository(SqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper; 
        }
        public Task<List<YearlyPnLData>> GetYearlyPnLAsync()
        {
            string sql = "SELECT c.Name as Commodity, m.Name as Model, Year(t.Date) as Year, sum(t.PnlDaily) as CumulativeSum " +
                        "FROM CommodityData t, Commodity c, Model m " +
                        "where t.CommodityId = c.Id and c.Id = m.Id and Year(t.Date) >= 2019 Group by Year(t.Date), c.Name, m.Name order by Year(t.Date), c.Name, m.Name";

            return _sqlHelper.RawSqlQuery<YearlyPnLData>(sql);
        }
    }
}
