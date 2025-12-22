
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

        public List<Entity> GenerateEntities()
        {
            Console.WriteLine("\nEntities spawned.");
            return _generateEntityService.GenerateEntities();
        }
    }
}
