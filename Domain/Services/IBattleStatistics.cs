using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IBattleStatistics
    {
        public string DisplayStatistics(List<Hero> blueTeam, List<Hero> redTeam, Map map, Store store);
        public void SaveStatisticsToFile(List<Hero> blueTeam, List<Hero> redTeam, Map map, Store store, string filePath);
    }
}
