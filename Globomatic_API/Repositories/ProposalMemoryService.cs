using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomatic_API.Repositories
{
    public class ProposalMemoryService : IProposalService
    {
        private readonly List<ProposalModel> proposals = new List<ProposalModel>();
        public ProposalMemoryService()
        {
            proposals.Add(new ProposalModel
                             {
                                    Id =1,ConferenceId=1,
                                    Speaker ="Roland Guijt",
                                    Title ="Understanding ASP.Net Core security"
                             });
            proposals.Add(new ProposalModel
            {
                Id = 2,
                ConferenceId = 2,
                Speaker = "John Reynold",
                Title = "Starting Your Developer Career",
                Approved=true
            });
            proposals.Add(new ProposalModel
            {
                Id = 3,
                ConferenceId = 2,
                Speaker = "Stan Lipens",
                Title = "ASP.NET Core TagHelper"
            });
        }
        public ProposalModel Add(ProposalModel model)
        {
            model.Id = proposals.Max(p => p.Id) + 1;
            proposals.Add(model);
            return model;
        }

        public ProposalModel Approve(int proposalId)
        {
            var proposal = proposals.FirstOrDefault(p => p.Id == proposalId);
            proposal.Approved = true;
            return proposal;
        }

        public IEnumerable<ProposalModel> GetAll(int conferenceId)
        {
            return proposals.Where(p => p.ConferenceId == conferenceId).AsEnumerable();
        }

        public ProposalModel GetById(int proposalId)
        {
            return proposals.FirstOrDefault(_p => _p.Id == proposalId);
        }
    }
}
