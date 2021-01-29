using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncCompare.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AsyncCompare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreakfastSyncController : ControllerBase
    {
        

        private readonly ILogger<BreakfastSyncController> _logger;
        private readonly BreakFastSyncService _breakFastSyncService;

        public BreakfastSyncController(ILogger<BreakfastSyncController> logger, BreakFastSyncService breakFastSyncService)
        {
            _logger = logger;
            _breakFastSyncService = breakFastSyncService;
        }

        [HttpPost]
        public ActionResult<List<string>> StartSync()
        {            
            return Ok(_breakFastSyncService.Start());
        }
    }
}
