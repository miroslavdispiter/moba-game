using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.SelectStorePresentation
{
    public class SelectStorePresentation
    {
        private readonly ISelectStore _selectStore;

        public SelectStorePresentation(ISelectStore selectStore) 
        { 
            _selectStore = selectStore;
        }

        public Store? EnterStoreId()
        {
            Console.WriteLine("\n--- STORE ---");

            while (true)
            {
                Console.WriteLine("Enter store ID: ");
                int storeId = int.Parse(Console.ReadLine() ?? "");

                Store? selectedStore = _selectStore.SelectStoreById(storeId);

                if (selectedStore == null)
                {
                    Console.WriteLine("Store not found. Try again.");
                }
                else
                {
                    Console.WriteLine($"You selected store: {selectedStore.Id}");
                    return selectedStore;
                }
            }
        }
    }
}
