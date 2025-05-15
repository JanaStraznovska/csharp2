using System.Globalization;

namespace planovacUdalosti;

class Program
{
    static List<Event> eventsList = new List<Event>();
    static Dictionary<DateTime, int> eventsDictionary = new Dictionary<DateTime, int>();


    static void Main(string[] args)
    {
        //Tests();
        //return;

        while (true)
        {
            Console.WriteLine("Enter data:");
            string data = Console.ReadLine();
            if (!ProcessData(data))
            {
                return;
            }
        }
    }

    private static void Tests()
    {
        ProcessData("EVENT;Lekce Czechitas;2025-05-17");
        ProcessData("EVENT;Oslava;2025-05-10");
        ProcessData("EVENT;Odevzdat úlohu;2025-04-20");
        ProcessData("EVENT;Vyšetření;2025-05-10");
        ProcessData("LIST");
        ProcessData("STATS");
        ProcessData("END");

        ProcessData("EVENT;Vyšetření,2025-05-10");
        ProcessData("EVENT Vyšetření 2025-05-10");
        ProcessData("TEST");

    }


    private static bool ProcessData(string inputString)
    {
        if (inputString.StartsWith("EVENT"))
        {
            string[] parts = inputString.Split(";");

            //for (int i = 0; i < parts.Length; i++)
            //{
            //    Console.WriteLine($"[{i}] = {parts[i]}");
            //}

            if (parts.Length == 3)
            {
                string dateInputString = parts[2];

                DateTime dateInput = DateTime.ParseExact(dateInputString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                Event newEvent = new Event(parts[1], dateInput);

                eventsList.Add(newEvent);

                if (eventsDictionary.ContainsKey(dateInput))
                {
                    eventsDictionary[dateInput]++;
                }
                else
                {
                    eventsDictionary.Add(dateInput, 1);
                }
            }
            else
            {
                Console.WriteLine("Data error!");
            }
        }

        else if (inputString.StartsWith("LIST"))
        {
            foreach (var e in eventsList)
            {
                e.Print();
            }
        }

        else if (inputString.StartsWith("STATS"))
        {
            foreach (DateTime d in eventsDictionary.Keys)
            {
                Console.WriteLine($"Date: {d:yyyy-MM-dd} Events: {eventsDictionary[d]}");
            }

        }
        else if (inputString.StartsWith("END"))
        {
            return false;
        }
        else
        {
            Console.WriteLine("Command error!");
        }

        return true;

    }

}
