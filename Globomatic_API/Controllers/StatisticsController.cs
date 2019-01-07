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
    public class StatisticsController:ControllerBase
    {
        private readonly IStatisticsRepo _statisticsRepo;

        public StatisticsController(IStatisticsRepo statisticsRepo)
        {
            _statisticsRepo = statisticsRepo;
        }
        public StatisticsModel Get()
        {
            return _statisticsRepo.GetStatistics();
        }
    }
}
