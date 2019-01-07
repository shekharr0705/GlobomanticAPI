using Shared.Models;

namespace Globomatic_API.Repositories
{
    public interface IStatisticsRepo
    {
        StatisticsModel GetStatistics();
    }
}
