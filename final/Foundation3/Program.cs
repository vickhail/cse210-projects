using System;
using System.Collections.Generic;

namespace EventPlanning
{
    public class Address
    {
        private string street;
        private string city;
        private string stateProvince;
        private string country;

        public Address(string street, string city, string stateProvince, string country)
        {
            this.street = street;
            this.city = city;
            this.stateProvince = stateProvince;
            this.country = country;
        }

        public string GetFullAddress()
        {
            return $"{street}, {city}, {stateProvince}, {country}";
        }
    }

    public class Event
    {
        protected string title;
        protected string description;
        protected string date;
        protected string time;
        protected Address address;

        public Event(string title, string description, string date, string time, Address address)
        {
            this.title = title;
            this.description = description;
            this.date = date;
            this.time = time;
            this.address = address;
        }

        public virtual string GetStandardDetails()
        {
            return $"Title: {title}\nDescription: {description}\nDate: {date}\nTime: {time}\nAddress: {address.GetFullAddress()}";
        }

        public virtual string GetFullDetails()
        {
            return GetStandardDetails();
        }

        public string GetShortDescription()
        {
            return $"Type: {this.GetType().Name}\nTitle: {title}\nDate: {date}";
        }
    }

    public class Lecture : Event
    {
        private string speaker;
        private int capacity;

        public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
            : base(title, description, date, time, address)
        {
            this.speaker = speaker;
            this.capacity = capacity;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nSpeaker: {speaker}\nCapacity: {capacity}";
        }
    }

    public class Reception : Event
    {
        private string rsvpEmail;

        public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
            : base(title, description, date, time, address)
        {
            this.rsvpEmail = rsvpEmail;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nRSVP Email: {rsvpEmail}";
        }
    }

    public class OutdoorGathering : Event
    {
        private string weather;

        public OutdoorGathering(string title, string description, string date, string time, Address address, string weather)
            : base(title, description, date, time, address)
        {
            this.weather = weather;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nWeather: {weather}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
            Address address2 = new Address("456 Elm St", "Othertown", "ON", "Canada");
            Address address3 = new Address("789 Oak St", "Sometown", "TX", "USA");

            Lecture lecture = new Lecture("Lecture on Dreamings", "The Art of Lucid Dreaming: Unlocking the Boundaries of Reality", "2023-06-10", "10:00 AM", address1, "Dr. Smith", 100);
            Reception reception = new Reception("Networking Event", "Meet and greet with industry leaders", "2023-06-15", "6:00 PM", address2, "rsvp@event.com");
            OutdoorGathering outdoorGathering = new OutdoorGathering("Summer Picnic", "Fun in the sun", "2023-06-20", "12:00 PM", address3, "Sunny and warm");

            List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

            foreach (var eventItem in events)
            {
                Console.WriteLine("Standard Details:");
                Console.WriteLine(eventItem.GetStandardDetails());
                Console.WriteLine();

                Console.WriteLine("Full Details:");
                Console.WriteLine(eventItem.GetFullDetails());
                Console.WriteLine();

                Console.WriteLine("Short Description:");
                Console.WriteLine(eventItem.GetShortDescription());
                Console.WriteLine();
            }
        }
    }
}