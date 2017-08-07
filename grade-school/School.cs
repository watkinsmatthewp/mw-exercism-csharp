using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class School
{
    public Dictionary<int, List<string>> Roster { get; private set; }

    public School()
    {
        Roster = new Dictionary<int, List<string>>();
    }

    public void Add(string studentName, int grade)
    {
        if (!Roster.ContainsKey(grade))
        {
            Roster[grade] = new List<string>();
        }
        Roster[grade].Add(studentName);
        
        // Sort
        Roster[grade] = Roster[grade].OrderBy(s => s).ToList();
    }

    public List<string> Grade(int grade)
    {
        return Roster.ContainsKey(grade) ? Roster[grade] : new List<string>();
    }
}