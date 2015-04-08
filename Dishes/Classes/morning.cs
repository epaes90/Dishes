using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes.Classes
{
    public class morning : baseDishes
    {
        /// <summary>
        /// All the business logic is in the base class, so
        /// the children only must implement some setups
        /// </summary>
        public morning()
        {
            canRepeat = 3;
            validEntries = new List<int>() { 1, 2, 3 };
            names = new Dictionary<int, string>()
            {
                {1, "eggs"},
                {2, "toast"},
                {3, "coffee"}
            };
        }

    }
}
