﻿using AA.CommoditiesDashboard.Application.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Application.Modules.Dashboard.Interfaces
{
    public interface IGetPriceTrendDataRepository
    {
        Task<List<YtdPriceTrendData>> GetPriceTrendDataAsync(int year);
    }
}
