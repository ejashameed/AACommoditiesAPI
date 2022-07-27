using AA.CommiditesDashboard.Infrastructure.Shared.Helpers;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.Interfaces;
using AA.CommoditiesDashboard.Application.Modules.Dashboard.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommiditesDashboard.Infrastructure.ReadRepositories.Dashboard
{
    public class GetCommodityWithModelRepository: IGetCommodityWithModelRepository
    {
        private readonly SqlHelper _sqlHelper;
        public GetCommodityWithModelRepository(SqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public Task<List<CommodityWithModel>> GetAsync()
        {
            string sql = @"SELECT C.Id AS CommodityId, C.ModelId as ModelId, C.Name as Name, m.Name as Model
                           FROM Commodity C, Model M
                           Where C.ModelId = M.Id";

            return _sqlHelper.RawSqlQuery<CommodityWithModel>(sql);
        }
    }
}
