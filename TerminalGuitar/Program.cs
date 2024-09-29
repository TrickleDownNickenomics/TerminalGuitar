using MusicTheoryLibrary;

var kvp = Notes.FlatNotes.Where(k => k.Value.Equals("Db")).Single();
Key key = new Key(kvp, Mode.Aeolian, false);
var modes = key.AllScales;
foreach (var mode in modes)
{
    Console.Write($"{mode.Key}:  ");
    foreach(var note in mode.Value)
    {
        Console.Write($"{note} ");
    }
    Console.WriteLine();
}
Console.ReadKey();