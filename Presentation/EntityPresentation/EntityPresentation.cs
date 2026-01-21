
using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.EntityPresentation
{
    public class EntityPresentation
    {
        private readonly IGenerateEntity _generateEntityService;

        public EntityPresentation(IGenerateEntity generateEntityService) 
        { 
            _generateEntityService = generateEntityService;
        }

        public List<Entity> EnterNumOfEntities()
        {
            Console.WriteLine("\nNumber of entities in the game: ");
            int numberOfEntities = int.Parse(Console.ReadLine() ?? "");

            List<Entity> entitiesSpawned = _generateEntityService.GenerateEntities(numberOfEntities);

            Console.WriteLine($"--- {numberOfEntities} entities spawned! ---");

            return entitiesSpawned;
        }
    }
}
