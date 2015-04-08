using Dishes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dishes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get the entry of the user
            string input = Console.ReadLine();
            //Split it in arrays so the business class can work with
            string[] inputs = input.Split(',');
            string[] dishes = new string[inputs.Count() - 1];

            //Get only the numbers(dishes) from the user's entry to send to business class
            inputs.ToList().CopyTo(1, dishes, 0, inputs.Count() - 1);

            try
            {
                //Here we try to instanciate the class by Activator so we can
                //Instanciate the right class that users want with less code
                string strNamesapace = "Dishes.Classes." + inputs[0].ToLower();
                Type t = Type.GetType(strNamesapace);
                baseDishes b = (baseDishes)Activator.CreateInstance(t);

                //Write the right dishes
                Console.Write(b.getDishes(dishes));
            }
            catch(ArgumentNullException)
            {
                //If the Activator could not instanciate the class, show
                //Error to the user
                Console.Write("error");
            }

            //Stop the application so user can see the result
            Console.Read();
        }
    }
}
