using Challenge.DataContracts;
using System;
namespace ConsoleApp;

public class Solver
{
    public static string Solve(TaskResponse taskResponse)
    {
        if (taskResponse.TypeId == "moment")
        {
            return SolveMoment(taskResponse);
        }
        else
        {
            throw new Exception("I don't know this task type yet");
        }
    }

    public static string SolveMoment(TaskResponse taskResponse)
    {
        var task = taskResponse.Question;
        var SplitTimeDate = task.Split();
        var time = SplitTimeDate[0].Split(":");
        var hour = time[0];
        var minutes = time[1];
        var date = SplitTimeDate[1].Split(".");
        var day = date[0];
        var month = date[1];
        var monthsName = new[] { "января", "февараля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };
        var result = $"{day} {monthsName[int.Parse(month) - 1]} {hour}:{minutes}";
        return result;
    }
}
