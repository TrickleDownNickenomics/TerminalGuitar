namespace MusicTheoryLibrary;

public class Key(KeyValuePair<int, string> key)
{
    private bool _useFlats = true;
    public Key(KeyValuePair<int, string> key, Mode mode) : this(key)
    {
        Mode = mode;
    }

    public Key(KeyValuePair<int, string> key, Mode mode, bool useFlats) : this(key)
    {
        Mode = mode;
        _useFlats = useFlats;
    }
    public string Root { get; } = key.Value;

    public bool UseFlats { get { return _useFlats; } set { _useFlats = value; } }

    public Mode Mode { get; set; } = Mode.Ionian;

    public List<string> Scale { get { return GetScale(Mode); } }

    public Dictionary<Mode, List<string>> AllScales
    {
        get
        {
            var allScales = new Dictionary<Mode, List<string>>
            {
                { Mode.Ionian, GetScale(Mode.Ionian) },
                { Mode.Aeolian, GetScale(Mode.Aeolian) },
                { Mode.Dorian, GetScale(Mode.Dorian) },
                { Mode.Phrygian, GetScale(Mode.Phrygian) },
                { Mode.Lydian, GetScale(Mode.Lydian) },
                { Mode.Mixolydian, GetScale(Mode.Mixolydian) },
                { Mode.Locrian, GetScale(Mode.Locrian) }
            };
            return allScales;
        }
    }

    private static readonly char[] steps = ['W', 'W', 'H', 'W', 'W', 'W', 'H', 'W', 'W', 'H', 'W', 'W', 'W'];

    private static readonly char[] ionian = steps[0..6];
    private static readonly char[] dorian = steps[1..7];
    private static readonly char[] phrygian = steps[2..8];
    private static readonly char[] lydian = steps[3..9];
    private static readonly char[] mixolydian = steps[4..10];
    private static readonly char[] aeolian = steps[5..11];
    private static readonly char[] locrian = steps[6..12];



    private List<string> GetScale(Mode mode)
    {
        var result = new List<string>();
        switch (mode)
        {
            case Mode.Ionian:
                result = GenerateScale(ionian);
                break;
            case Mode.Aeolian:
                result = GenerateScale(aeolian);
                break;
            case Mode.Dorian:
                result = GenerateScale(dorian);
                break;
            case Mode.Phrygian:
                result = GenerateScale(phrygian);
                break;
            case Mode.Lydian:
                result = GenerateScale(lydian);
                break;
            case Mode.Mixolydian:
                result = GenerateScale(mixolydian);
                break;
            case Mode.Locrian:
                result = GenerateScale(locrian);
                break;
        }
        return result;
    }

    private List<string> GenerateScale(char[] steps)
    {
        var scale = new List<string>();
        var root = Root;
        var notes = _useFlats ? Notes.FlatNotes : Notes.SharpNotes;

        if (!notes.ContainsValue(root))
        {
            int rootIndex = FindRootIndex(root);
            root = notes[rootIndex];
        }

        int semitone = notes.Where(x => x.Value == root).First().Key;
        scale.Add(notes[semitone]);

        foreach (var step in steps)
        {
            if (step == 'W')
            {
                semitone = (semitone + 2) % 12;
                scale.Add(notes[semitone]);
            }
            else
            {
                semitone = (semitone + 1) % 12;
                scale.Add(notes[semitone]);
            }
        }

        return scale;
    }

    private int FindRootIndex(string root)
    {
        bool notUseFlats = !_useFlats;
        var notes = notUseFlats ? Notes.FlatNotes : Notes.SharpNotes;
        int rootIndex = notes.Where(x => x.Value == root).First().Key;
        return rootIndex;
    }
}