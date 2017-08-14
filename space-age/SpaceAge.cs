using System;

public class SpaceAge
{
    long _ageInSeconds;

    public SpaceAge(long seconds)
    {
        _ageInSeconds = seconds;
    }

    public double OnMercury() => Math.Round(OnEarth(false) / 0.2408467d, 2);
    public double OnVenus() => Math.Round(OnEarth(false) / 0.61519726d, 2);
    public double OnEarth() => OnEarth(true);
    public double OnMars() => Math.Round(OnEarth(false) / 1.8808158d, 2);
    public double OnJupiter() => Math.Round(OnEarth(false) / 11.862615d, 2);
    public double OnSaturn() => Math.Round(OnEarth(false) / 29.447498d, 2);
    public double OnUranus() => Math.Round(OnEarth(false) / 84.016846d, 2);
    public double OnNeptune() => Math.Round(OnEarth(false) / 164.79132d, 2);

    private double OnEarth(bool round)
    {
        var exact = _ageInSeconds / 31557600d;
        return round ? Math.Round(exact, 2) : exact;
    }
}