using AA.CommoditiesDashboard.Application.Interfaces.ReadRepositories;
using AA.CommoditiesDashboard.Application.Interfaces.Repositories;
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
            GetYtdPriceTrendsRequestHandler ytdPnLTrendsRequestHandler,
            GetAllCommoditesRequestHandler commoditesRequestHandler
            )
        {
            _getYearlyPnlRequestHandler = yearlyPnlRequestHandler;
            _getCumulativePnLRequestHandler = cumulativePnLRequestHandler;
            _getKeyActionsRequestHandler = keyActionsRequestHandler;
            _getYtdPnLTrendsRequestHandler = ytdPnLTrendsRequestHandler;            
            _getCommoditesRequestHandler = commoditesRequestHandler;            
        }

        [HttpGet]
        [Route("commodities/keymetrics/pnl-ytd")]
        public async Task<IActionResult> GetYearlyPnl()
        {
            var response = await _getYearlyPnlRequestHandler.Handle();
            return new ObjectResult(response);
        }

        [HttpGet]
        [Route("commodities/keymetrics/pnl-cumulative")]
        public async Task<IActionResult> GetCumulativePnL()
        {
            var response = await _getCumulativePnLRequestHandler.Handle();
            return new ObjectResult(response);
        }

        [HttpGet]
        [Route("commodities/historical/pnl-ytd-trends")]
        public async Task<IActionResult> GetYtdPnLTrends()
        {
            //var response = new GetYtdPnLTrendsRequestHandler().Handle();
            return Ok();
        }

        [HttpGet]
        [Route("commodities/historical/keyactions")]
        public async Task<IActionResult> GetKeyActions()
        {
            var response = await _getKeyActionsRequestHandler.Handle();
            return new ObjectResult(response);
        }

        [HttpGet]
        [Route("commodities/ListCommodites")]
        public async Task<IActionResult> GetAllCommodites()
        {
            var response = await _getCommoditesRequestHandler.Handle();
            return new ObjectResult(response);
        }
       
    }
}
