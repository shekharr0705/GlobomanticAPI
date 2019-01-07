using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomatic_API.Repositories
{
    public class ConferenceMemoryService : IConferenceService
    {
        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();
        public ConferenceMemoryService()
        {
            conferences.Add(new ConferenceModel { Id = 1, Name = "NDC", Location = "Oslo" ,AttendeeTotal=100});
            conferences.Add(new ConferenceModel { Id = 2, Name = "IT/DevConnections", Location = "London" ,AttendeeTotal=150});
            conferences.Add(new ConferenceModel { Id = 3, Name = "Re:Invent-2018", Location = "NewYork", AttendeeTotal = 200 });
        }
        public ConferenceModel Add(ConferenceModel model)
        {
            model.Id = conferences.Max(_c => _c.Id) + 1;
            conferences.Add(model);
            return model;
        }

        public IEnumerable<ConferenceModel> GetAll()
        {
            return conferences.AsEnumerable();
        }

        public ConferenceModel GetByid(int id)
        {
            return conferences.FirstOrDefault(_c => _c.Id == id);
        }

        public StatisticsModel GetStatistics()
        {
            return new StatisticsModel
            {
                NumberOfAttendees = conferences.Sum(c => c.AttendeeTotal),
                AverageConferenceAttendees = (int)conferences.Average(c => c.AttendeeTotal)
            };
        }
    }
}
