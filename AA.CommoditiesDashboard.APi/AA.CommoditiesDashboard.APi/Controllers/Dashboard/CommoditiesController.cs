using AA.CommoditiesDashboard.Application.Modules.Dashboard.RequestHandlers;
using AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AA.CommoditiesDashboard.APi.Controllers.Dashboard
{
    public class CommoditiesController : ControllerBase
    {        
        private readonly GetYearlyPnLRequestHandler _getYearlyPnlRequestHandler;
        private readonly GetCumulativePnLRequestHandler _getCumulativePnLRequestHandler;
        private readonly GetKeyActionsRequestHandler _getKeyActionsRequestHandler;
        private readonly GetYtdPriceTrendsRequestHandler _getYtdPriceTrendsRequestHandler;        
        private readonly GetAllCommoditesRequestHandler _getCommoditesRequestHandler;
        public CommoditiesController(
            GetYearlyPnLRequestHandler yearlyPnlRequestHandler,
            GetCumulativePnLRequestHandler cumulativePnLRequestHandler,
            GetKeyActionsRequestHandler keyActionsRequestHandler,
            GetYtdPriceTrendsRequestHandler getYtdPriceTrendsRequestHandler,
            GetAllCommoditesRequestHandler commoditesRequestHandler
            )
        {
            _getYearlyPnlRequestHandler = yearlyPnlRequestHandler;
            _getCumulativePnLRequestHandler = cumulativePnLRequestHandler;
            _getKeyActionsRequestHandler = keyActionsRequestHandler;            
            _getCommoditesRequestHandler = commoditesRequestHandler;   
            _getYtdPriceTrendsRequestHandler = getYtdPriceTrendsRequestHandler;
        }

        [HttpGet]
        [Route("commodities/keymetrics/pnl-ytd")]
        public async Task<IActionResult> GetYearlyPnl()
        {
            var response = await _getYearlyPnlRequestHandler.Handle(new RequestCommand());
            return new ObjectResult(response);
        }

        [HttpGet]
        [Route("commodities/keymetrics/pnl-cumulative")]
        public async Task<IActionResult> GetCumulativePnL()
        {
            var response = await _getCumulativePnLRequestHandler.Handle(new RequestCommand());
            return new ObjectResult(response);
        }

        [HttpGet]
        [Route("commodities/historical/price-ytd-trends/{year}")]
        public async Task<IActionResult> GetYtdPriceTrends(int year)
        {
            
            var response = await _getYtdPriceTrendsRequestHandler.Handle(new TrendRequestCommand { Year = year});
            return new ObjectResult(response);
        }

        [HttpGet]
        [Route("commodities/historical/keyactions")]
        public async Task<IActionResult> GetKeyActions()
        {
            var response = await _getKeyActionsRequestHandler.Handle(new RequestCommand());
            return new ObjectResult(response);
        }

        [HttpGet]
        [Route("commodities/ListCommodites")]
        public async Task<IActionResult> GetAllCommodites()
        {
            var response = await _getCommoditesRequestHandler.Handle(new RequestCommand());
            return new ObjectResult(response);
        }
       
    }
}
