using System;

public class BinarySearch
{
    private int[] _values;
    
    public BinarySearch(int[] input)
    {
        _values = input;
    }

    public int Find(int value)
    {
        return _values.Length == 0 ? -1 : FindInRange(0, _values.Length - 1, value);
    }

    private int FindInRange(int rangeStartIdx, int rangeEndIdx, int searchValue)
    {
        int midpointIdx = GetMidpointIndex(rangeStartIdx, rangeEndIdx);
        var midpointValue = _values[midpointIdx];
        var comp = searchValue.CompareTo(midpointValue);

        if (comp == 0)
        {
            return midpointIdx;
        }

        if (midpointIdx == rangeStartIdx)
        {
            return -1;
        }

        if (comp > 0)
        {
            return FindInRange(midpointIdx + 1, rangeEndIdx, searchValue);
        }

        return FindInRange(rangeStartIdx, midpointIdx - 1, searchValue);
    }

    private static int GetMidpointIndex(int rangeStartIdx, int rangeEndIdx)
    {
        if (rangeEndIdx == rangeStartIdx)
        {
            return rangeEndIdx;
        }
        return rangeStartIdx + ((rangeEndIdx + 1 - rangeStartIdx) / 2);
    }
}