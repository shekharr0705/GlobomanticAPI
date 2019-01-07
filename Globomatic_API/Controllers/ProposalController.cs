using Globomatic_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Linq;

namespace Globomatic_API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProposalController:ControllerBase
    {
        private readonly IConferenceService _conferenceService;
        private readonly IProposalService _proposalService;

        public ProposalController(IConferenceService conferenceService,IProposalService proposalService)
        {
            _conferenceService = conferenceService;
            _proposalService = proposalService;
        }

        [HttpGet("{conferenceId}")]
        public IActionResult GetAll(int conferenceId)
        {
            var proposals = _proposalService.GetAll(conferenceId);
            if (!proposals.Any())
                return new NoContentResult();
            return new ObjectResult(proposals);
        }

        [HttpGet("id",Name ="GetById")]
        public ProposalModel GetById(int id)
        {
            return _proposalService.GetById(id);

        }


        [HttpPost]
        public IActionResult Add([FromBody]ProposalModel proposal)
        {
            var addedProposal=_proposalService.Add(proposal);
            return CreatedAtRoute("GetById", new { id = addedProposal.Id }, addedProposal);
        }

        [HttpPut("{proposalId}")]
        public IActionResult Approve(int proposalId)
        {
            try
            {
                return new ObjectResult(_proposalService.Approve(proposalId));
            }
            catch (InvalidOperationException)
            {

                return NotFound();
            }
        }
    }
}
