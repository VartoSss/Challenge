using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ConsoleApp;

public class NewShape
{
    public static string NewShapeSolver(string task)
    {
        var directory = Directory.GetCurrentDirectory();
        var debug = Directory.GetParent(directory).ToString();
        var bin = Directory.GetParent(debug).ToString();
        var project = Directory.GetParent(bin).ToString();
        var h1_1 = Directory.GetParent(project);

        var path = h1_1 + @"\ConsoleApp\shapeConverter.txt";
        var filePath = h1_1 + @"\ConsoleApp\shape.py";

        File.WriteAllText(path, string.Empty);
        File.WriteAllText(path, task);

        var visualisation = new Process();

        visualisation.StartInfo = new ProcessStartInfo(filePath)
        {
            UseShellExecute = true
        };
        visualisation.Start();

        var firstTaskPart = task.Split('|')[0];
        var variants = firstTaskPart.Split('=')[1].Split(',');
        Console.WriteLine("Possible answers:");
        for (var i = 0; i < variants.Length; i++)
        {
            Console.WriteLine($"{variants[i]} - {i + 1}");
        }
        
        var answer = int.Parse(Console.ReadLine());
        return variants[answer - 1];
    }
}
