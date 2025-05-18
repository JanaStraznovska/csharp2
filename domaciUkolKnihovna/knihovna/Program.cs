using System.Globalization;

namespace knihovna;

class Program
{
    static List<Book> listOfBooks = new List<Book>();

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
        ProcessData("ADD;1984;George Orwell;1949-06-08;328");
        ProcessData("ADD;Brave New World;Aldous Huxley;1932-01-01;311");
        ProcessData("ADD;Animal Farm;George Orwell;1945-08-17;112");
        ProcessData("ADD;Harry Potter and the philosophers stone;J.K.Rowling;1997-06-26;285");
        ProcessData("LIST");
        ProcessData("STATS");
        ProcessData("FIND;harry");
        ProcessData("FIND;test");
        ProcessData("FIND;");
        ProcessData("FIND");
        ProcessData("ADD;Animal Farm;George Orwell;18.09.2098;112");
        ProcessData("ADD;Animal Farm;George Orwell;1945-08-17;-34");
        ProcessData("ADD;Animal Farm;George Orwell;1945-08-17;djfdh");
        ProcessData("ADD/Harry Potter and the philosophers stone/J.K.Rowling/1997-06-26/285");
        ProcessData("END");
    }


    private static bool ProcessData(string inputString)
    {
        if (inputString.StartsWith("ADD"))
        {
            string[] parts = inputString.Split(";");

            if (parts.Length == 5)
            {
                string dateInputString = parts[3];

                DateTime dateInput;

                bool dateIsValid = DateTime.TryParseExact(dateInputString,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dateInput);

                if (dateIsValid)
                {
                    string pagesInput = parts[4];
                    bool pagesFromConsoleParseSuccess = int.TryParse(pagesInput, out int pagesFromConsole);
                    Book newEvent = new Book(parts[1], parts[2], dateInput, pagesFromConsole);

                    listOfBooks.Add(newEvent);
                }
                else
                {
                    Console.WriteLine("Invalid date!");
                }

            }
            else
            {
                Console.WriteLine("Data error!");
            }
        }

        else if (inputString.StartsWith("LIST"))
        {
            var sortedBookList = listOfBooks.OrderBy(b => b.PublishDate);

            foreach (var book in sortedBookList)
            {
                book.Print();
            }
        }

        else if (inputString.StartsWith("STATS"))
        {
            double averageOfAllPages = listOfBooks.Average(b => b.Pages);

            Console.WriteLine($"Average numbers of pages: {averageOfAllPages}");

            Console.WriteLine($"Number of books by authors:");

            var listOfAuthors = listOfBooks.GroupBy(b => b.Author);

            foreach (var author in listOfAuthors)
            {
                var booksByAuthors = author.Select(b => b.Author);
                Console.WriteLine($" - {author.Key}: {booksByAuthors.Count()}");
            }

            var NamesOfBooks = listOfBooks.SelectMany(b => b.Title.Split(" ")).Distinct();


            Console.WriteLine($"Number of unique words in book titles: {NamesOfBooks.Count()}");
        }

        else if (inputString.StartsWith("FIND"))
        {
            string[] parts = inputString.Split(";");
            if (parts.Length == 2)
            {
                var keyword = parts[1].ToLower();
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    var resultsOfSearch = listOfBooks.Where(b => b.Title.ToLower().Contains(keyword));

                    Console.WriteLine($"Search result for '{keyword}'");

                    if (resultsOfSearch.Count() > 0)
                    {
                        foreach (var book in resultsOfSearch)
                        {
                            Console.WriteLine($" - {book.Title}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No book found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid keyword!");
                }
            }
            else
            {
                Console.WriteLine("Command error!");
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
