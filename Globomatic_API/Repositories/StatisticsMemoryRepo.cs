using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomatic_API.Repositories
{
    public class StatisticsMemoryRepo : IStatisticsRepo
    {
        private readonly IConferenceService _conferenceService;
        public StatisticsMemoryRepo(IConferenceService conferenceService)
        {
            _conferenceService = conferenceService;
        }
        public StatisticsModel GetStatistics()
        {
            var conferences = _conferenceService.GetAll();
            return new StatisticsModel
            {
                NumberOfAttendees = conferences.Sum(c => c.AttendeeTotal),
                AverageConferenceAttendees = (int)conferences.Average(c => c.AttendeeTotal)
            };
        }
    }
}
