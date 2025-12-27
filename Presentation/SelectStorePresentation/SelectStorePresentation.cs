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

        public Store? EnterMapId()
        { 
            // TO-DO
            return new Store();
        }
    }
}
