using System;
using Challenge;
using Challenge.DataContracts;
using ConsoleApp;
using Task = System.Threading.Tasks.Task;
using System.Threading;


// Данное приложение можно запускать под Windows, Linux, Mac.
// Для запуска приложения необходимо скачать и установить .NET 6.
// Скачать можно тут: https://dotnet.microsoft.com/download/dotnet


const string teamSecret = "rgTEuil2k8O2Z8bAAsM4VRugd9RZ3RC/";
if (string.IsNullOrEmpty(teamSecret))
{
    Console.WriteLine("Задай секрет своей команды, чтобы можно было делать запросы от ее имени");
    Console.ReadLine();
}
else
{
    var challengeClient = new ChallengeClient(teamSecret);

    const string challengeId = "projects-course";
    Console.WriteLine($"Нажми ВВОД, чтобы получить информацию о соревновании {challengeId}");
    Console.ReadLine();
    Console.WriteLine("Ожидание...");
    var challenge = await challengeClient.GetChallengeAsync(challengeId);
    Console.WriteLine(challenge.Description);
    Console.WriteLine();
    Console.WriteLine("----------------");
    Console.WriteLine();
    
    

    var utcNow = DateTime.UtcNow;
    string currentRound = null;
    foreach (var round in challenge.Rounds)
    {
        if (round.StartTimestamp < utcNow && utcNow < round.EndTimestamp)
            currentRound = round.Id;
    }
    
    Console.WriteLine("Введите тип задачи");
    var type = Console.ReadLine();
    string taskType = type;
    Console.WriteLine("Введите y, если вы хотите решать принятые задачи");
    Console.WriteLine();
    var toSolveAccepted = Console.ReadLine();
    if (toSolveAccepted == "y")
    {
        var firstTasks = await challengeClient.GetTasksAsync(currentRound, taskType, TaskStatus.Pending, 0, 50);
        for (int i = 0; i < firstTasks.Count; i++)
        {
            var task = firstTasks[i];
            Console.WriteLine($"  Новое задание, статус {task.Status}");
            Console.WriteLine($"  Формулировка: {task.UserHint}");
            Console.WriteLine($"                {task.Question}");
            Console.WriteLine();
            Console.WriteLine("----------------");
            Console.WriteLine();

            var answer = Solver.Solve(task);

            Console.WriteLine($"Нажми ВВОД, чтобы ответить на полученную задачу самым правильным ответом: {answer}");
            Console.ReadLine();
            Console.WriteLine("Ожидание...");
            var updatedTask = await challengeClient.CheckTaskAnswerAsync(task.Id, answer);
            Console.WriteLine($"  Новое задание, статус {updatedTask.Status}");
            Console.WriteLine($"  Формулировка:  {updatedTask.UserHint}");
            Console.WriteLine($"                 {updatedTask.Question}");
            Console.WriteLine($"  Ответ команды: {updatedTask.TeamAnswer}");
            Console.WriteLine();
            if (updatedTask.Status == TaskStatus.Success)
                Console.WriteLine($"Ура! Ответ угадан!");
            else if (updatedTask.Status == TaskStatus.Failed)
                Console.WriteLine($"Похоже ответ не подошел и задачу больше сдать нельзя...");
            Console.WriteLine();
            Console.WriteLine("----------------");
            Console.WriteLine();
        }
    }
    
    Console.WriteLine("Будем решать новые задачи");
    Console.WriteLine("----------------");
    Console.WriteLine();
    Console.WriteLine("Введите количество задач");
    var taskAmount = int.Parse(Console.ReadLine());
    Console.WriteLine("Отправить решение с ручной проверкой адекватности ответов? y\\n");
    var isHandCheck = Console.ReadLine();
    if (isHandCheck == "y")
        await AnswerNTasksWithHandCheck(challengeClient, taskType, currentRound, taskAmount);
    else if (isHandCheck == "n")
        await AnswerNTasksWithoutHandCheck(challengeClient, taskType, currentRound, taskAmount);
    else
        throw new Exception("Если написано ввести y\\n, то надо б**н написать y или n");

    Console.WriteLine($"Нажми ВВОД, чтобы завершить работу программы");
    Console.ReadLine();
}

static async Task AnswerNTasksWithHandCheck(ChallengeClient challengeClient, string taskType, string currentRound, int taskAmount)
{
    for (var i = 0; i < taskAmount; i++)
    {

        Console.WriteLine($"Нажми ВВОД, чтобы получить задачу типа {taskType} в раунде {currentRound}");
        Console.ReadLine();
        Console.WriteLine("Ожидание...");
        var newTask = await challengeClient.AskNewTaskAsync(currentRound, taskType);
        Console.WriteLine($"  Новое задание, статус {newTask.Status}");
        Console.WriteLine($"  Формулировка: {newTask.UserHint}");
        Console.WriteLine($"                {newTask.Question}");
        Console.WriteLine();
        Console.WriteLine("----------------");
        Console.WriteLine();

        if ((newTask.TypeId == "starter"))
        {
            continue;
        }
        var answer = Solver.Solve(newTask);
        

        Console.WriteLine($"Нажми ВВОД, чтобы ответить на полученную задачу самым правильным ответом: {answer}");
        Console.ReadLine();
        Console.WriteLine("Ожидание...");
        var updatedTask = await challengeClient.CheckTaskAnswerAsync(newTask.Id, answer);
        Console.WriteLine($"  Новое задание, статус {updatedTask.Status}");
        Console.WriteLine($"  Формулировка:  {updatedTask.UserHint}");
        Console.WriteLine($"                 {updatedTask.Question}");
        Console.WriteLine($"  Ответ команды: {updatedTask.TeamAnswer}");
        Console.WriteLine();
        if (updatedTask.Status == TaskStatus.Success)
            Console.WriteLine($"Ура! Ответ угадан!");
        else if (updatedTask.Status == TaskStatus.Failed)
            Console.WriteLine($"Похоже ответ не подошел и задачу больше сдать нельзя...");
        Console.WriteLine();
        Console.WriteLine("----------------");
        Console.WriteLine();
    }
}

static async Task AnswerNTasksWithoutHandCheck(ChallengeClient challengeClient, string taskType, string currentRound, int taskAmount)
{
    for (var i = 0; i < taskAmount; i++)
    {
        var newTask = await challengeClient.AskNewTaskAsync(currentRound, taskType);
        Console.WriteLine($"  Новое задание, статус {newTask.Status}");
        Console.WriteLine($"  Формулировка: {newTask.UserHint}");
        Console.WriteLine($"                {newTask.Question}");
        Console.WriteLine();
        Console.WriteLine("----------------");
        Console.WriteLine();
        if (newTask.TypeId == "starter")
        {
            continue;
        }
        var answer = Solver.Solve(newTask);
        var updatedTask = await challengeClient.CheckTaskAnswerAsync(newTask.Id, answer);
        Console.WriteLine($"  Новое задание, статус {updatedTask.Status}");
        Console.WriteLine($"  Формулировка:  {updatedTask.UserHint}");
        Console.WriteLine($"                 {updatedTask.Question}");
        Console.WriteLine($"  Ответ команды: {updatedTask.TeamAnswer}");
        Console.WriteLine();
        if (updatedTask.Status == TaskStatus.Success)
            Console.WriteLine($"Ура! Ответ угадан!");
        else if (updatedTask.Status == TaskStatus.Failed)
        {
            Console.WriteLine($"Похоже ответ не подошел и задачу больше сдать нельзя...");
            throw new Exception("Ты пр****л 200 баллов");
        }
        Console.WriteLine();
        Console.WriteLine("----------------");
        Console.WriteLine();
        Thread.Sleep(200);
    }
}