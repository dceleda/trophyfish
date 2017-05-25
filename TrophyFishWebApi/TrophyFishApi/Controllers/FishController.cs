using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TrophyFish.Api.ViewModel;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrophyFish.Api.Controllers
{
    [Route("api/[controller]")]
    public class FishController : Controller
    {
        private JsonSerializerSettings _defaultJsonSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            return new JsonResult(new FishVM { Id = 10, Length = "55" }, _defaultJsonSettings);

        }

        [HttpPost()]
        //[Authorize]
        public IActionResult Add([FromBody]FishVM vm)
        {
            if (ModelState.IsValid && vm != null)
            {

                return new JsonResult(vm, _defaultJsonSettings);
            }

            return new StatusCodeResult(500);
        }
    }
}
