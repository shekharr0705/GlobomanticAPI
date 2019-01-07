using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomatic_API.Repositories
{
    public interface IProposalService
    {
        ProposalModel Add(ProposalModel model);
        ProposalModel Approve(int proposalId);
        IEnumerable<ProposalModel> GetAll(int conferenceId);
        ProposalModel GetById(int proposalId);

    }
}
