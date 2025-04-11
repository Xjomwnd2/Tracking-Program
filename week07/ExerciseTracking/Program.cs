using System;
using System.Collections.Generic;

// Base Activity class
public abstract class Activity
{
    // Shared attributes
    private DateTime _date;
    private int _minutes;

    // Constructor
    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Getters for private fields
    public DateTime GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Common summary method that uses the virtual methods
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
               $"Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }
}

// Running class derived from Activity
public class Running : Activity
{
    private double _distance;

    // Constructor
    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    // Implementation of abstract methods
    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / _distance;
    }
}

// Cycling class derived from Activity
public class Cycling : Activity
{
    private double _speed;

    // Constructor
    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    // Implementation of abstract methods
    public override double GetDistance()
    {
        return (_speed * GetMinutes()) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}

// Swimming class derived from Activity
public class Swimming : Activity
{
    private int _laps;

    // Constructor
    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    // Implementation of abstract methods
    public override double GetDistance()
    {
        // Distance in miles: laps * 50 / 1000 * 0.62
        return _laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold all activities
        List<Activity> activities = new List<Activity>();

        // Create at least one of each activity type
        DateTime currentDate = DateTime.Now;
        
        // Add a running activity (date, minutes, distance in miles)
        activities.Add(new Running(currentDate, 30, 3.0));
        
        // Add a cycling activity (date, minutes, speed in mph)
        activities.Add(new Cycling(currentDate, 45, 15.0));
        
        // Add a swimming activity (date, minutes, laps)
        activities.Add(new Swimming(currentDate, 20, 10));

        // Display the summary for each activity
        Console.WriteLine("Exercise Tracking Program");
        Console.WriteLine("------------------------");
        
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}