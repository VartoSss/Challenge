using Challenge;
using Challenge.DataContracts;
using System;
using System.Text;

namespace ConsoleApp;

public class Solver
{
    public static string Solve(TaskResponse taskResponse)
    {
        if (taskResponse.TypeId == "starter")
        {
            return SolveStarter(taskResponse);
        }
        else if (taskResponse.TypeId == "cypher")
        {
            return SolveCypher(taskResponse);
        }
        else
        {
            Environment.Exit(0);
            return "0";
        }
    }

    public static string SolveStarter(TaskResponse taskResponse)
    {
        var taskFormulation = taskResponse.Question;
        return "42";
    }

    public static string SolveCypher(TaskResponse taskResponse)
    {
        var task = taskResponse.Question;
        var splittedTask = task.Split(new[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
        if (splittedTask[0] == "reversed" && splittedTask.Length == 2)
        {
            var result = new StringBuilder();
            for (int i = splittedTask[1].Length - 1; i >= 0; i--)
                result.Append(splittedTask[1][i]);
            return result.ToString();
        }
        else
        {
            throw new Exception("AAAAAA TASK GOT HARDER");
        }
        
    }
}
