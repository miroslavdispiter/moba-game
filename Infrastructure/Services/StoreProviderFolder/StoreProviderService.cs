using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.StoreProviderFolder
{
    // Formal apstraction
    public class StoreProviderService : IStoreProvider
    {
        private readonly Store _chosenStore;

        public StoreProviderService(Store chosenStore)
        {
            _chosenStore = chosenStore;
        }

        public Store GetStore() => _chosenStore;
    }
}
