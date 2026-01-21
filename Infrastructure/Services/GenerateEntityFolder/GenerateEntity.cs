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

        public List<Entity> GenerateEntities(int numOfEnt)
        {
            List<Entity> listOfEntities = new List<Entity>();
            
            // Best in this simulation is like 120-150
            for (int i = 0; i < numOfEnt; i++)
            {
                var entity = new Entity();
                listOfEntities.Add(entity);
            }

            return listOfEntities;
        }
    }
}
