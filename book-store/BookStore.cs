using System;
using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    private static readonly Dictionary<int, double> BUNDLE_DISCOUNTS_BY_SIZE = new Dictionary<int, double>
    {
        [1] = 0d,
        [2] = .05d,
        [3] = .1d,
        [4] = .2d,
        [5] = .25d
    };
    
    public static double Total(IEnumerable<int> books)
    {
        double total = 0;
        foreach (var bundle in SplitIntoBundles(books, BUNDLE_DISCOUNTS_BY_SIZE.Keys.Max()))
        {
            total += (8d * bundle.Count) * (1d - BUNDLE_DISCOUNTS_BY_SIZE[bundle.Count]);
        }
        return total;
    }

    private static IEnumerable<IList<int>> SplitIntoBundles(IEnumerable<int> books, int maxBundleSize)
    {
        var bookGroups = books.GroupBy(b => b).Select(g => new Queue<int>(g)).ToList();
        while (bookGroups.Count > 0)
        {
            var bundleSize = Math.Min(maxBundleSize, bookGroups.Count);
            var bundle = new int[bundleSize];
            var iOffset = 0;
            for (var i = 0; i < bundleSize; i++)
            {
                var groupIdx = i + iOffset;
                bundle[i] = bookGroups[groupIdx].Dequeue();
                if (bookGroups[groupIdx].Count == 0)
                {
                    bookGroups.RemoveAt(groupIdx);
                    iOffset--;
                }
            }
            yield return bundle;
        }
    }
}