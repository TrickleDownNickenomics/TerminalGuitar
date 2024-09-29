using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTheoryLibrary;

public static class Notes
{
    private static Dictionary<int, string> sharpNotes = new Dictionary<int, string>()
    {
        { 0, "A" },
        { 1, "A#" },
        { 2, "B" },
        { 3, "C" },
        { 4, "C#" },
        { 5, "D" },
        { 6, "D#" },
        { 7, "E" },
        { 8, "F" },
        { 9, "F#" },
        { 10, "G" },
        { 11, "G#" }
    };

    private static Dictionary<int, string> flatNotes = new Dictionary<int, string>()
    {
        { 0, "A" },
        { 1, "Bb" },
        { 2, "B" },
        { 3, "C" },
        { 4, "Db" },
        { 5, "D" },
        { 6, "Eb" },
        { 7, "E" },
        { 8, "F" },
        { 9, "Gb" },
        { 10, "G" },
        { 11, "Ab" }
    };

    public static Dictionary<int, string> SharpNotes { get { return sharpNotes; } }

    public static Dictionary<int, string> FlatNotes { get { return flatNotes; } }
}
