using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class Garden
{
    private static readonly Dictionary<char, Plant> PLANT_MAPPINGS = new Dictionary<char, Plant>
    {
        ['V'] = Plant.Violets,
        ['R'] = Plant.Radishes,
        ['C'] = Plant.Clover,
        ['G'] = Plant.Grass
    };
    
    private static readonly string[] DEFAULT_CHILDREN = new string[]
    {
        "Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"
    };

    private Dictionary<string, List<Plant>> _plantsByChild = new Dictionary<string, List<Plant>>();
    
    public Garden(IEnumerable<string> children, string windowSills)
    {
        var row2Idx = windowSills.IndexOf('\n') + 1;
        var currentIdx = 0;
        foreach (var child in children.OrderBy(c => c))
        {
            _plantsByChild[child] = new List<Plant>();
            if (currentIdx < row2Idx - 1)
            {
                _plantsByChild[child].AddRange(new Plant[]
                {
                    PLANT_MAPPINGS[windowSills[currentIdx]],
                    PLANT_MAPPINGS[windowSills[currentIdx + 1]],
                    PLANT_MAPPINGS[windowSills[row2Idx + currentIdx]],
                    PLANT_MAPPINGS[windowSills[row2Idx + currentIdx + 1]]
                });
            }
            currentIdx+=2;
        }
    }

    public IEnumerable<Plant> GetPlants(string child)
    {
        return _plantsByChild.ContainsKey(child) ? _plantsByChild[child] : Enumerable.Empty<Plant>();
    }

    public static Garden DefaultGarden(string windowSills)
    {
        return new Garden(DEFAULT_CHILDREN, windowSills);
    }
}