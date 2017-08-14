using System;
using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    static readonly Dictionary<int, double> DISCOUNT_RATES_BY_BUNDLE_SIZE = new Dictionary<int, double>
    {
        [1] = 0d,
        [2] = .05d,
        [3] = .1d,
        [4] = .2d,
        [5] = .25d
    };

    /// <summary>
    /// Calculates the minimum price for the books supplied
    /// </summary>
    /// <param name="books"></param>
    /// <returns></returns>
    public static double Total(IEnumerable<int> books)
    {
        var cart = books
            .GroupBy(b => b)
            .ToDictionary(g => g.Key, g => g.Count());
        return Total(cart, 0);
    }

    private static double Total(Dictionary<int, int> cart, double initialPrice)
    {
        if (cart.Count == 0)
        {
            return initialPrice;
        }
        
        var minPrice = double.MaxValue;
        for (var i = 0; i < cart.Count; i++)
        {
            var bundleSize = i + 1;

            // Assume a bundle of size {bundleSize}. Create a new dictionary of 
            // books representing the removal of these books from the cart
            var nextStep = cart.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            foreach (var bookToRemoveFromNewCart in cart.Keys.Take(bundleSize))
            {
                if (nextStep[bookToRemoveFromNewCart] == 1)
                {
                    nextStep.Remove(bookToRemoveFromNewCart);
                }
                else
                {
                    nextStep[bookToRemoveFromNewCart]--;
                }
            }

            // Calculate the base price given this new bundle we have created
            var nextStepInitialPrice = initialPrice + ((bundleSize) * 8 * (1 - DISCOUNT_RATES_BY_BUNDLE_SIZE[bundleSize]));
            minPrice = Math.Min(minPrice, Total(nextStep, nextStepInitialPrice));
        }

        return minPrice;
    }
}