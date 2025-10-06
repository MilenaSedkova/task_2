static string ProcessData(string DataName)
{
    Thread.Sleep(3000);
    string result = $"Обработка {DataName} завершена за 3 секунды";
    return result;
}
static async Task <string> ProcessDataAsync(string DataName)
{
    await Task.Delay(3000);
    string result = $"Обработка {DataName} завершена за 3 секунды";
    return result;
}
Console.WriteLine("Синхронная обработка");
var syncStart=DateTime.Now;
Console.WriteLine(ProcessData("Файл 1"));
Console.WriteLine(ProcessData("Файл 2"));
Console.WriteLine(ProcessData("Файл 3"));
var syncEnd=DateTime.Now;
Console.WriteLine($"Время, потраченное на синхронную обработку: {(syncEnd-syncStart).TotalSeconds}");

Console.WriteLine("Асинхронная обработка");
var asyncStart=DateTime.Now;
var task = new List<Task<string>>
{
    ProcessDataAsync("Файл 1"),
    ProcessDataAsync("Файл 2"),
    ProcessDataAsync("Файл 3")
};
while (task.Count > 0)
{
    Task<string> finishedTask= await Task.WhenAny(task);
    Console.WriteLine(await finishedTask);
    task.Remove(finishedTask);
}
var asyncFinish=DateTime.Now;
Console.WriteLine($"Время, потраченное на асинхронную разработуку:{(asyncFinish - asyncStart).TotalSeconds}");
