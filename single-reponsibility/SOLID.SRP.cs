using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            // Please read overload to known about how to output of string using separator
            return String.Join(Environment.NewLine, entries);
        }
    }
    public class Persistence
    {
        public void SavetoFile(Journal j, string fileName, bool overwrite=false)
        {
            if (overwrite || File.Exists(fileName))
                File.WriteAllText(fileName, j.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);
            var p = new Persistence();
            var fileName = @"C:\temp\journal.txt";

            p.SavetoFile(j, fileName, true);
            Process.Start(fileName);
            Console.ReadLine();
        }
    }
}
