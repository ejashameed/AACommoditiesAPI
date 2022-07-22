using AA.CommoditiesDashboard.Application.RequestHandlers.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace AA.CommoditiesDashboard.APi.Controllers.Dashboard
{
    public class ModelsController : ControllerBase
    {
        private readonly GetAllModelsRequestHandler _getAllmodelsRequestHandler;
        public ModelsController(GetAllModelsRequestHandler getAllmodelsRequestHandler)
        {
            _getAllmodelsRequestHandler = getAllmodelsRequestHandler;
        }

        [HttpGet]
        [Route("commodities/ListModels")]
        public async Task<IActionResult> GetAllModels()
        {
            var response = await _getAllmodelsRequestHandler.Handle();
            return Ok(response);
        }
    }
}
