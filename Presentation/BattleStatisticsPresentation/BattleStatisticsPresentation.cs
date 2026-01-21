using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.BattleStatisticsPresentation
{
    public class BattleStatisticsPresentation
    {
        private readonly IBattleStatistics _battleStatisticsService;

        public BattleStatisticsPresentation(IBattleStatistics battleStatisticsService)
        {
            _battleStatisticsService = battleStatisticsService;
        }

        public void ChooseOutputAndShow(List<Hero> blueTeam, List<Hero> redTeam, Map map, Store store)
        {
            Console.WriteLine("\nSelect how to display battle statistics: ");
            Console.WriteLine("1. Console");
            Console.WriteLine("2. Save to text file");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string result = _battleStatisticsService.DisplayStatistics(blueTeam, redTeam, map, store);
                Console.WriteLine(result);
                
            }
            else if (choice == "2")
            {
                string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
                string statsDir = Path.Combine(projectRoot, "Output");

                Directory.CreateDirectory(statsDir);

                string fullPath = Path.Combine(statsDir, $"battle_statistics_{DateTime.Now:yyyyMMdd_HHmm}.txt");

                _battleStatisticsService.SaveStatisticsToFile(blueTeam, redTeam, map, store, fullPath);

                Console.WriteLine($"Battle statistics saved to {fullPath}");
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}
