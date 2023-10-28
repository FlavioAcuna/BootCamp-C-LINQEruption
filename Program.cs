using System.Collections.Immutable;

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
//Use LINQ to find the first eruption that is in Chile and print the result.
IEnumerable<Eruption> firstEruptionChile = eruptions.Where(c => c.Location == "Chile").OrderBy(c => c.Year).Take(1);
PrintEach(firstEruptionChile, "Primera erupcion en chile");

//Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
IEnumerable<Eruption> primeraErupcionHawaii = eruptions.Where(c => c.Location == "Hawaiian Is");
if (primeraErupcionHawaii.Count() > 0)
{
    PrintEach(primeraErupcionHawaii, "Primera erupcion en Hawaii");
}
else
{
    Console.WriteLine("No Hawaiian Is Eruption found.");
}

//Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
IEnumerable<Eruption> firsterupnewz = eruptions.Where(c => c.Year > 1900).Where(c => c.Location == "New Zealand");
PrintEach(firsterupnewz, "Primera erupcion en New Zealand despues de 1900");

//Find all eruptions where the volcano's elevation is over 2000m and print them.
IEnumerable<Eruption> allErup2000m = eruptions.Where(c => c.ElevationInMeters > 2000);
PrintEach(allErup2000m, "Erupciones en las que la elevacion del volcan es de mas de 2000m");

//Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
IEnumerable<Eruption> allErupStartL = eruptions.Where(c => c.Volcano.StartsWith("L"));
PrintEach(allErupStartL, $"Erupciones Cuando el nombre del volcan comienza con L, Numero de erupciones: {allErupStartL.Count()}");

//Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
int highElevation = eruptions.Max(c => c.ElevationInMeters);
Console.WriteLine(" ");
Console.WriteLine($"La altura mas alta es de {highElevation}");

//Use the highest elevation variable to find a print the name of the Volcano with that elevation.
IEnumerable<Eruption> highElevationVolcan = eruptions.Where(c => c.ElevationInMeters == highElevation);
PrintEach(highElevationVolcan, $"El volcan con la elevacion mas alta es :");
//Print all Volcano names alphabetically.
IEnumerable<Eruption> alphaBeticallyVolcan = eruptions.OrderBy(c => c.Volcano);
PrintEach(alphaBeticallyVolcan, $"Volcanes ordenados alfabeticamente :");

//Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.F
IEnumerable<Eruption> eruptionsBef1000Alpha = eruptions.Where(c => c.Year > 1000).OrderBy(c => c.Volcano);
PrintEach(eruptionsBef1000Alpha, $"Erupciones despues de 1000 ordenadas alfabeticamente:");


// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
