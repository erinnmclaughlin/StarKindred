using Microsoft.EntityFrameworkCore;
using StarKindred.API.Database;
using StarKindred.API.Database.Models;

string[] monthNames = { "", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

Db? sourceDb = null;

while (sourceDb == null)
{
    Console.WriteLine("Enter DB connection string for SOURCE database.");

    var connectionString = Console.ReadLine()?.Trim() ?? "";

    try
    {
        var optionsBuilder = new DbContextOptionsBuilder<Db>();

        optionsBuilder.UseSqlServer(connectionString);

        sourceDb = new Db(optionsBuilder.Options);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

Adventure? story = null;

while (story == null)
{
    Console.WriteLine("Enter the name of the Story to publish.");

    var storyName = Console.ReadLine()?.Trim() ?? "";

    story = await sourceDb.Adventures
        .Include(a => a.AdventureSteps!)
            .ThenInclude(s => s.Recruit)
        .AsSingleQuery()
        .FirstOrDefaultAsync(s => s.Title == storyName);

    if(story == null)
        Console.WriteLine("Story not found.");
}

Console.WriteLine("Found the following story:");
Console.WriteLine();
Console.WriteLine(story.Title);
Console.WriteLine();
Console.WriteLine(story.Summary);
Console.WriteLine();
Console.WriteLine($"Released {monthNames[story.ReleaseMonth]} {story.ReleaseYear}");

Console.WriteLine();
Console.WriteLine("If this is not correct, Ctrl+C now.");
Console.WriteLine();

Db? publishDb = null;

while (publishDb == null)
{
    Console.WriteLine("Enter DB connection string to PUBLISH to.");

    var connectionString = Console.ReadLine()?.Trim() ?? "";

    try
    {
        var optionsBuilder = new DbContextOptionsBuilder<Db>();

        optionsBuilder.UseSqlServer(connectionString);

        publishDb = new Db(optionsBuilder.Options);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

Console.WriteLine("Publishing...");

publishDb.Adventures.Add(story);

await publishDb.SaveChangesAsync();

Console.WriteLine("Done!");
