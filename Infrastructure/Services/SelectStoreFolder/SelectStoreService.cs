using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.SelectStoreFolder
{
    public class SelectStoreService : ISelectStore
    {
        private readonly IStoreRepository _storeRepository;

        public SelectStoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public Store? SelectStoreById(int id)
        {
            Store? store = _storeRepository.Stores().FirstOrDefault(s => s.Id == id);

            if (store == null)
            {
                return null;
            }

            return store;
        }
    }
}
