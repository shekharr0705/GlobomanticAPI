using Globomatic_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomatic_API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ConferenceController:ControllerBase
    {
        private IConferenceService _conferenceService;

        public ConferenceController(IConferenceService conferenceService)
        {
            _conferenceService = conferenceService;
        }
        public IActionResult GetAll()
        {
            var conferences = _conferenceService.GetAll();
            if (!conferences.Any())
                return new NoContentResult();
            return new ObjectResult(conferences);
        }
        [HttpPost]
        public ConferenceModel Add([FromBody]ConferenceModel conference)
        {
            return _conferenceService.Add(conference);
            
        }
    }
}
