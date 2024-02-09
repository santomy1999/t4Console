
// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Xml;
using t4Console;
using t4Console.Models;
using t4Console.Repository;
using t4Console.Controllers;


var dbContext = new CGDBContext();
var fieldRepo = new FieldRepo(dbContext);
var projectHandler = new ProjectHandler();

var layoutGenerator = new LayoutGenerator();
var viewGenerator = new ViewGenerator(dbContext);
var controllerGenerator = new ControllerGenerator(dbContext);
var modelGenerator = new ModelGenerator(dbContext);


/*User input*/

Console.WriteLine("Enter Location:");
string loc = Console.ReadLine();
Console.WriteLine("Enter your Project name:");
string projectName = Console.ReadLine();

/*Project data*/
ProjectData.ProjectName = projectName;
ProjectData.ProjectLocation = loc;

/*Create Project*/
Console.WriteLine("Creating Project");
int result = projectHandler.CreateProject(ProjectData.ProjectName,
    ProjectData.ProjectLocation);
if (result == -1) {

   //Project already exists
    Console.WriteLine("Project already exists in location " + ProjectData.ProjectLocation + "\\" + ProjectData.ProjectName);
    Console.WriteLine("Do you wish to overwrite the project?\n(y/n)");
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    Console.WriteLine("\n");
    // Extract the character from the ConsoleKeyInfo object
    char inputChar = keyInfo.KeyChar;
    if (inputChar != 'y' && inputChar != 'Y')
    {
        Console.WriteLine("Exitting...");
        Environment.Exit(result);
    }
}
else if (result == 0)
{
    Console.WriteLine("Created Project in location " + ProjectData.ProjectLocation + "\\" + ProjectData.ProjectName);

}

/*Generate Layout*/
Console.WriteLine("Generating Layout");
var pages = await fieldRepo.getAllPages();


layoutGenerator.GenerateLayout(pages);
/*Generating Controllers, Views and Models*/
Console.WriteLine("Generating Controllers, Views and Models");
foreach (var page in pages)
{
    Console.WriteLine($"\tGenerating {page.PageIdentifier}Controller...");
    await controllerGenerator.GenerateController(page);
    Console.WriteLine($"\tGenerating {page.PageIdentifier}View...");
    await viewGenerator.GenerateView(page);
    Console.WriteLine($"\tGenerating {page.PageIdentifier}Model...\n");
    await modelGenerator.GenerateModel(page);
}
Console.WriteLine("Code Generation Complete :)");




