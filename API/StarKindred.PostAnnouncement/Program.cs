using StarKindred.PostAnnouncement;
using Microsoft.EntityFrameworkCore;
using StarKindred.API.Database;
using StarKindred.API.Database.Models;

Console.WriteLine("What is the announcement type?");
Console.WriteLine("C. Change Log");
Console.WriteLine("S. Server Issues");

var type = InputHelpers.GetAnnouncementType();

Console.WriteLine("Paste Markdown. Type 'exit' to quit.");

string markdown = "";

do
{
    string line = Console.ReadLine() ?? "";
    
    if (line.Trim().ToLower() == "exit")
        break;

    markdown += line + "\n";
} while (true);

Console.WriteLine("Here's what I got:" + Environment.NewLine);

Console.WriteLine(markdown);

Console.WriteLine();

Console.WriteLine("Paste DB connection string to post this announcement.");

var connectionString = Console.ReadLine()?.Trim() ?? "";

var optionsBuilder = new DbContextOptionsBuilder<Db>();

optionsBuilder.UseSqlServer(connectionString);

var db = new Db(optionsBuilder.Options);

db.Announcements.Add(new Announcement
{
    Type = type,
    Body = markdown
});

db.SaveChanges();

Console.WriteLine("Success!");
