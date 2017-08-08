using System;
using System.Collections.Generic;
using System.Linq;

// TODO: Boy does this need some comments!!!
public class SaddlePoints
{
  private int[,] _points;
  private int _dimensions;

  public SaddlePoints(int[,] values)
  {
    _points = values;
    _dimensions = (int)Math.Sqrt(_points.Length);
  }

  public IEnumerable<Tuple<int, int>> Calculate()
  {
    var highestRowPoints = new Dictionary<int, List<int>>();
    var lowestColumnPoints = new Dictionary<int, List<int>>();

    for (var r = 0; r < _dimensions; r++)
    {
      highestRowPoints[r] = new List<int>();
      for (var c = 0; c < _dimensions; c++)
      {
        if (r == 0)
        {
          lowestColumnPoints[c] = new List<int>();
        }
        var pointValue = _points[r, c];
        UpdateList(highestRowPoints[r], () => _points[r, highestRowPoints[r][0]], pointValue, c, 1);
        UpdateList(lowestColumnPoints[c], () => _points[lowestColumnPoints[c][0], c], pointValue, r, -1);
      }
    }

    foreach (var highestRowPointSet in highestRowPoints)
    {
      foreach (var highestRowColIdx in highestRowPointSet.Value)
      {
        if (lowestColumnPoints[highestRowColIdx].Contains(highestRowPointSet.Key))
        {
          yield return new Tuple<int, int>(highestRowPointSet.Key, highestRowColIdx);
        }
      }
    }
  }

  private void UpdateList(List<int> extremePoints, Func<int> getExtremePointValue, int value, int idx, int expectedCompare)
  {
    if (extremePoints.Count == 0)
    {
      extremePoints.Add(idx);
    }
    else
    {
      var comp = value.CompareTo(getExtremePointValue());
      if (comp == 0)
      {
        extremePoints.Add(idx);
      }
      else if (comp == expectedCompare)
      {
        extremePoints.Clear();
        extremePoints.Add(idx);
      }
    }
  }
}