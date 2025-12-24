using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.SelectMapPresentation
{
    public class SelectMapPresentation
    {
        private readonly ISelectMap _selectMap;
        public SelectMapPresentation(ISelectMap selectMap) 
        {
            _selectMap = selectMap;
        }

        public Map? EnterMap()
        {
            Console.WriteLine("- - - - - MAP - - - - -");

            while (true)
            {
                Console.WriteLine("Enter map name: ");
                string mapName = Console.ReadLine() ?? "";

                var selectedMap = _selectMap.SelectMapByName(mapName.Trim());

                if (selectedMap != null)
                {
                    return selectedMap;
                }

                Console.WriteLine("Map not found. Try again.");
            }
        }
    }
}
