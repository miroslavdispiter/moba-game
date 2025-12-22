using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.GenerateEntityFolder
{
    public class GenerateEntity : IGenerateEntity
    {
        public GenerateEntity() { }

        public List<Entity> GenerateEntities()
        {
            List<Entity> listOfEntities = new List<Entity>();
            
            // hardcoded 40 entites, because i want every game to generate the same amount entities
            for (int i = 0; i < 40; i++)
            {
                var entity = new Entity();
                listOfEntities.Add(entity);
            }

            return listOfEntities;
        }
    }
}
