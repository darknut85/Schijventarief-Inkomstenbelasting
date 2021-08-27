using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schijventarief_Inkomstenbelasting
{
    class Program
    {
        static void Main(string[] args)
        {
            // parameters
            string name;

            double income;
            double ib;
            double calc;
            double outcome = 0;
            double tar = 0;
            double perc;
            double taxFree;

            int tarive;

            // data
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            while (true)
            {
                try
                {
                    Console.WriteLine("What is your annual income?");
                    income = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception) { Console.WriteLine("Invalid: please try again."); }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("What is your tarive group? 1 to 5");
                    tarive = Convert.ToInt32(Console.ReadLine());
                    if (tarive >= 1 && tarive <= 5) { break; }
                    else { Console.WriteLine("Invalid: please try again."); }
                }
                catch (Exception) { Console.WriteLine("Invalid: please try again."); }
            }

            // math
            double inc = income;

            perc = inc / 100 * 12;
            if (perc > 6704) { perc = 6704; }

            if (tarive == 1) { tar = 419; }
            else if (tarive == 2) { tar = 8799; }
            else if (tarive == 3) { tar = 17179; }
            else if (tarive == 4) { tar = 15503; }
            else if (tarive == 5) { tar = 15503; }

            taxFree = tar + perc;
            inc -= taxFree;

            if (inc > 54000)
            {
                ib = 60;
                calc = inc - 54000;
                outcome += calc / 100 * ib;
                inc = 54000;
            }
            if (inc > 25000)
            {
                ib = 50;
                calc = inc - 25000;
                outcome += calc / 100 * ib;
                inc = 25000;
            }
            if (inc > 8000)
            {
                ib = 37.05;
                calc = inc - 8000;
                outcome += calc / 100 * ib;
                inc = 8000;
            }
            if (inc > 0)
            {
                ib = 35.75;
                calc = inc;
                outcome += calc / 100 * ib;
                inc = 0;
            }

            // conclusion
            Console.WriteLine("Your name is: " + name);
            Console.WriteLine("Your income is: " + income);
            Console.WriteLine("Your tarive group is: " + tarive);
            Console.WriteLine("Taxfree: " + taxFree);
            Console.WriteLine("You need to pay: " + outcome);
        }
    }
    // verschuldigde inkomstenbelasting
    // belastbaar inkomen - belastingvrije som = belastbare som

    // berekening belastbare som:
        // eerste 8000: 35,75%
        // 8001 -> 25000: 37,05%
        // 25001 -> 54000: 50%
        // 54001+: 60%

    // belastingvrije som:
        // tariefgroep 1: 419 euro
        // tariefgroep 2: 8799 euro
        // tariefgroep 3: 17179 euro
        // tariefgroep 4: 15503 euro
        // tariefgroep 5: 15503 euro
        // + 12% van belastbaar inkomen met max 6704 euro

    // bepaal verschuldigde belasting
}
