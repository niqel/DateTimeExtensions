using Niqel504.DateTimeExtensions;

// See https://aka.ms/new-console-template for more information

DateTime dateTime = new DateTime();
var rank = dateTime.GetRankTime(new DateTime(1982, 07, 7), DateTime.Now);

Console.WriteLine("Your RankTime");
Console.WriteLine($"Years: {rank.Years}");
Console.WriteLine($"Months: {rank.Months}");
Console.WriteLine($"Days: {rank.Days}");
Console.WriteLine("****************");


