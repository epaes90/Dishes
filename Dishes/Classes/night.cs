using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes.Classes
{
    public class night : baseDishes
    {
        /// <summary>
        /// All the business logic is in the base class, so
        /// the children only must implement some setups
        /// </summary>
        public night()
        {
            canRepeat = 2;
            validEntries = new List<int>() { 1, 2, 3, 4 };
            names = new Dictionary<int, string>()
            {
                {1, "steak"},
                {2, "potato"},
                {3, "wine"},
                {4, "cake"}
            };
        }
    }
}
