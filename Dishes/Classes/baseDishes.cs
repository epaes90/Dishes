using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes.Classes
{
    public abstract class baseDishes
    {
        protected int canRepeat;
        protected List<int> validEntries;
        protected Dictionary<int, string> names;

        /// <summary>
        /// This is the main method of the program, here is all the business logic.
        /// Basically, this method receives the string entry of the user with the dishes
        /// Convert to int so it's easier to work with, and after validates those entries,
        /// send to another method to name the dishes
        /// </summary>
        /// <param name="dishes">The string entry of user</param>
        /// <returns>the dishes named</returns>
        public string getDishes(string[] dishes)
        {
            string result = "";
            List<int> listDishes = new List<int>();
            int repeatCounter = 0;

            //Main Loop
            foreach (string item in dishes)
            {
                int dish;
                bool added = false;

                //Verify if the argument is valid
                if (Int32.TryParse(item, out dish))
                {
                    //Verify if it is a valid argument to the class
                    if (validEntries.Contains(dish))
                    {
                        //Verify if already contain the dish...
                        if (listDishes.Contains(dish))
                        {
                            //...if yes, verify if the dish can repeat
                            if (dish == canRepeat)
                            {
                                repeatCounter++;
                                added = true;
                            }
                        }
                        else
                        {
                            //...if not then add
                            listDishes.Add(dish);
                            added = true;
                        }
                    }
                }
                //If the dish passed through the loop without being added,
                //Something is wrong
                if(added == false)
                {
                    //Add and number to sign there's an error
                    //Choosed MaxValue so it will always be last in sort
                    listDishes.Add(Int32.MaxValue);
                    break;
                }
            }
            //Sort so always the entrée will be first and desserts will be last
            listDishes.Sort();

            //Name the dishes
            result = nameDishes(listDishes, repeatCounter);
            return result;
        }

        /// <summary>
        /// Method responsable to name the dishes after the business logic
        /// </summary>
        /// <param name="listDishes">list of dishes sorted</param>
        /// <param name="repeatCounter">number of times the repeated dish appears</param>
        /// <returns>the dishes named</returns>
        public string nameDishes(List<int> listDishes, int repeatCounter)
        {
            string result = "";

            foreach (int item in listDishes)
            {
                //if it is not the first loop, add comma
                if (result != "")
                {
                    result += ", ";
                }

                //Verify if we have some troubles...
                if (item == Int32.MaxValue)
                {
                    result += "error";
                }
                else
                {
                    ///...if not, name the dish
                    result += names[item];
                }

                //Verify if it is a dish that can repeat and was repeated
                if (item == canRepeat && repeatCounter > 0)
                {
                    result += "(x" + (repeatCounter + 1).ToString() + ")";
                }
            }

            return result;
        }
    }
}
