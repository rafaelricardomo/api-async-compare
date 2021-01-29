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
    public class BreakfastAsyncController : ControllerBase
    {
        

        private readonly ILogger<BreakfastAsyncController> _logger;
        private readonly BreakfastAsyncService _breakFastAsyncService;

        public BreakfastAsyncController(ILogger<BreakfastAsyncController> logger, BreakfastAsyncService breakFastAsyncService)
        {
            _logger = logger;
            _breakFastAsyncService = breakFastAsyncService;
        }

        [HttpPost]
        public async Task<ActionResult<List<string>>> StartASync()
        {            
            return Ok(await _breakFastAsyncService.Start());
        }
    }
}
