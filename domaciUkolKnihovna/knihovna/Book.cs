namespace knihovna
{
    public class Book
    {
        string _title;
        string _author;
        DateTime _publishedDate;
        int _pages;

        public int Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                if (value > 0)
                {
                    _pages = value;
                }
                else
                {
                    throw new Exception("Number of pages have to be more then zero!");
                }
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        public DateTime PublishedDate
        {
            get
            {
                return _publishedDate;
            }
            set
            {
                _publishedDate = value;
            }
        }

        public Book(string title, string author, DateTime publishedDate, int pages)
        {
            Title = title;
            Author = author;
            PublishedDate = publishedDate;
            Pages = pages;
        }

        public void Print()
        {
            Console.WriteLine($"Book: {Title}, Author {Author}, Published: {PublishedDate:d.M.yyyy}, Pages: {Pages}");
        }

    }
}