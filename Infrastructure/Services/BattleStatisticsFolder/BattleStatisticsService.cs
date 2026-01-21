using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.BattleStatisticsFolder
{
    public class BattleStatisticsService : IBattleStatistics
    {
        public string DisplayStatistics(List<Hero> blueTeam, List<Hero> redTeam, Map map, Store store)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Map: {map.Name}");
            sb.AppendLine($"Total Value Sold: {store.TotalValue}");
            sb.AppendLine("\n--- BLUE TEAM ---");

            foreach (Hero hero in blueTeam)
            {
                sb.AppendLine($"{hero.Name} | HP: {hero.HealthPoints} | ATK: {hero.AttackPower} | Gold: {hero.Gold}");
            }

            sb.AppendLine("\n--- RED TEAM ---");

            foreach (Hero hero in redTeam)
            {
                sb.AppendLine($"{hero.Name} | HP: {hero.HealthPoints} | ATK: {hero.AttackPower} | Gold: {hero.Gold}");
            }
            return sb.ToString();
        }

        public void SaveStatisticsToFile(List<Hero> blueTeam, List<Hero> redTeam, Map map, Store store, string filePath)
        {
            using StreamWriter writer = new StreamWriter(filePath, false);
            writer.WriteLine($"Map: {map.Name}");
            writer.WriteLine($"Total Value Sold: {store.TotalValue}");
            writer.WriteLine("\n--- BLUE TEAM ---");

            foreach (Hero hero in blueTeam)
            {
                writer.WriteLine($"{hero.Name} | HP: {hero.HealthPoints} | ATK: {hero.AttackPower} | Gold: {hero.Gold}");
            }

            writer.WriteLine("\n--- RED TEAM ---");

            foreach (Hero hero in redTeam)
            {
                writer.WriteLine($"{hero.Name} | HP: {hero.HealthPoints} | ATK: {hero.AttackPower} | Gold: {hero.Gold}");
            }
        }
    }
}
