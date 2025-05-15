namespace planovacUdalosti
{
    public class Event
    {
        string eventName;
        DateTime eventDate;

        public Event(string name, DateTime date)
        {
            eventName = name;
            eventDate = date;
        }

        public void Print()
        {
            TimeSpan timeToEvent = eventDate - DateTime.Now;
            if (timeToEvent.Days > 0)
            {
                Console.WriteLine($"Event {eventName} with date {eventDate:yyyy-MM-dd} will happen in {timeToEvent.Days} days.");
            }
            else
            {
                Console.WriteLine($"Event {eventName} with date {eventDate:yyyy-MM-dd} happened {-timeToEvent.Days} days ago.");
            }
            
        }
    }
}