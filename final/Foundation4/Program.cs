using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    public class Activity
    {
        protected string date;
        protected int lengthInMinutes;

        public Activity(string date, int lengthInMinutes)
        {
            this.date = date;
            this.lengthInMinutes = lengthInMinutes;
        }

        public virtual double GetDistance() { return 0; }
        public virtual double GetSpeed() { return 0; }
        public virtual double GetPace() { return 0; }

        public virtual string GetSummary()
        {
            return $"{date} Activity ({lengthInMinutes} min)";
        }
    }

    public class Running : Activity
    {
        private float distance;

        public Running(string date, int lengthInMinutes, float distance) : base(date, lengthInMinutes)
        {
            this.distance = distance;
        }

        public override double GetDistance()
        {
            return distance;
        }

        public override double GetSpeed()
        {
            return (distance / lengthInMinutes) * 60;
        }

        public override double GetPace()
        {
            return lengthInMinutes / distance;
        }

        public override string GetSummary()
        {
            return $"{date} Running ({lengthInMinutes} min) - Distance: {distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
        }
    }

    public class Cycling : Activity
    {
        private float speed;

        public Cycling(string date, int lengthInMinutes, float speed) : base(date, lengthInMinutes)
        {
            this.speed = speed;
        }

        public override double GetDistance()
        {
            return (speed * lengthInMinutes) / 60;
        }

        public override double GetSpeed()
        {
            return speed;
        }

        public override double GetPace()
        {
            return 60 / speed;
        }

        public override string GetSummary()
        {
            return $"{date} Cycling ({lengthInMinutes} min) - Speed: {speed} mph, Distance: {GetDistance()} miles, Pace: {GetPace()} min/mile";
        }
    }

    public class Swimming : Activity
    {
        private int laps;

        public Swimming(string date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
        {
            this.laps = laps;
        }

        public override double GetDistance()
        {
            return laps * 50 / 1000 * 0.62;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / lengthInMinutes) * 60;
        }

        public override double GetPace()
        {
            return lengthInMinutes / GetDistance();
        }

        public override string GetSummary()
        {
            return $"{date} Swimming ({lengthInMinutes} min) - Laps: {laps}, Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Running running = new Running("2023-06-05", 30, 3.0f);
            Cycling cycling = new Cycling("2023-06-06", 45, 15.0f);
            Swimming swimming = new Swimming("2023-06-07", 60, 20);

            List<Activity> activities = new List<Activity> { running, cycling, swimming };

            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
