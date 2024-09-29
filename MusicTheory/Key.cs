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
            var allScales = new Dictionary<Mode, List<string>>();

            foreach(Mode mode in Mode.GetValues(typeof(Mode)))
            {
                allScales.Add(mode, GetScale(mode));
            }
            //var allScales = new Dictionary<Mode, List<string>>
            //{
            //    { Mode.Ionian, GetScale(Mode.Ionian) },
            //    { Mode.Aeolian, GetScale(Mode.Aeolian) },
            //    { Mode.Dorian, GetScale(Mode.Dorian) },
            //    { Mode.Phrygian, GetScale(Mode.Phrygian) },
            //    { Mode.Lydian, GetScale(Mode.Lydian) },
            //    { Mode.Mixolydian, GetScale(Mode.Mixolydian) },
            //    { Mode.Locrian, GetScale(Mode.Locrian) }
            //};
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
                result = GenerateScale(ionian, key.Value);
                break;
            case Mode.Aeolian:
                result = GenerateScale(aeolian, key.Value);
                break;
            case Mode.Dorian:
                result = GenerateScale(dorian, key.Value);
                break;
            case Mode.Phrygian:
                result = GenerateScale(phrygian, key.Value);
                break;
            case Mode.Lydian:
                result = GenerateScale(lydian, key.Value);
                break;
            case Mode.Mixolydian:
                result = GenerateScale(mixolydian, key.Value);
                break;
            case Mode.Locrian:
                result = GenerateScale(locrian, key.Value);
                break;
        }
        return result;
    }

    private List<string> GenerateScale(char[] steps, string root)
    {
        var scale = new List<string>();
        
        var notes = _useFlats ? Notes.FlatNotes : Notes.SharpNotes;

        if (!notes.ContainsValue(root))
        {
            int rootIndex = FindRootIndex(root);
            if(rootIndex < 0)
            {
                throw new ArgumentException("Root not found.", nameof(root));
            }
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
        var notes = !_useFlats ? Notes.FlatNotes : Notes.SharpNotes;
        int rootIndex = -1;
        foreach (var step in notes)
        {
            if(step.Value.Equals(root))
            {
                rootIndex = step.Key;
                break;
            } 
        }
        return rootIndex;
    }
}