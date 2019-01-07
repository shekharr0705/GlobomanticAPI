using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomatic_API.Repositories
{
    public interface IConferenceService
    {
        IEnumerable<ConferenceModel> GetAll();
        ConferenceModel GetByid(int id);
        StatisticsModel GetStatistics();
        ConferenceModel Add(ConferenceModel model);
    }
}
