using System;

public class Clock
{
    private static readonly int MINUTES_IN_DAY = 24 * 60;
    private int _timeInMinutes = 0;

    public int Hours => _timeInMinutes / 60;
    public int Minutes => _timeInMinutes % 60;
    
    public Clock(int hours)
    {
        AdjustTime(hours, 0);
    }

    public Clock(int hours, int minutes)
    {
        AdjustTime(hours, minutes);
    }

    public Clock Add(int minutesToAdd)
    {
        AdjustTime(0, minutesToAdd);
        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        AdjustTime(0, -minutesToSubtract);
        return this;
    }

    public override string ToString()
    {
        return $"{Hours.ToString("00")}:{Minutes.ToString("00")}";
    }

    public override bool Equals(object obj)
    {
        return obj is Clock && obj.GetHashCode() == GetHashCode();
    }

    public override int GetHashCode()
    {
        return _timeInMinutes;
    }

    private void AdjustTime(int hours, int minutes)
    {
        AdjustTime((60 * hours) + minutes);
    }

    private void AdjustTime(int minutes)
    {
        var actualMinutesToAdjust = minutes % MINUTES_IN_DAY;
        if (actualMinutesToAdjust < 0)
        {
            actualMinutesToAdjust = MINUTES_IN_DAY + actualMinutesToAdjust;
        }
        _timeInMinutes += actualMinutesToAdjust;
        _timeInMinutes %= MINUTES_IN_DAY;
    }
}