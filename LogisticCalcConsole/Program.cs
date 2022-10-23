using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogisticCalcConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            { 
                var mainModel = new LogisticCalcLib.MainModel("30000", "1000", true);
                Console.WriteLine(mainModel.Price);
                Console.WriteLine(mainModel.RollBack);

                Console.WriteLine(mainModel.PriceForATIWithRate);
                Console.WriteLine(mainModel.PricengForATIWithOutRate);

                Console.WriteLine(mainModel.MaxPriceWithRate);
                Console.WriteLine(mainModel.MaxPriceWithOutRate);

                mainModel.DecreaseBid(1000);

                Console.WriteLine(mainModel.PriceForATIWithRate);
                Console.WriteLine(mainModel.PricengForATIWithOutRate);

                Console.WriteLine(mainModel.MaxPriceWithRate);
                Console.WriteLine(mainModel.MaxPriceWithOutRate);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
