using MusicTheoryLibrary;

var kvp = Notes.FlatNotes.Where(k => k.Value == "C#").FirstOrDefault();
Key key = new Key(kvp, Mode.Aeolian, false);
Console.WriteLine($"{key.Mode} {key.Root}");
foreach(var x in key.Scale)
    Console.WriteLine(x);