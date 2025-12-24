using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.SelectMapFolder
{
    public class SelectMapService : ISelectMap
    {
        private readonly IMapRepository _mapRepository;

        public SelectMapService(IMapRepository mapRepository)
        { 
            _mapRepository = mapRepository;
        }

        public Map? SelectMapByName(string name)
        {
            Map? map = _mapRepository.Maps().FirstOrDefault(m => m.Name.Equals(name));

            if (map == null)
            {
                return null;
            }

            return map;
        }
    }
}
