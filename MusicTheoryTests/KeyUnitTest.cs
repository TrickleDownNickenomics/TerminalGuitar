using MusicTheoryLibrary;

namespace MusicTheoryTests;

[TestClass]
public class KeyUnitTest
{
    private static List<string> cIonian = ["C", "D", "E", "F", "G", "A", "B"];
    private static List<string> cDorian = ["C", "D", "D#", "F", "G", "A", "A#"];
    private static List<string> cPhrygian = ["C", "C#", "D#", "F", "G", "G#", "A#"];
    private static List<string> cLydian = ["C", "D", "E", "F#", "G", "A", "B"];
    private static List<string> cMixolydian = ["C", "D", "E", "F", "G", "A", "A#"];
    private static List<string> cAeolian = ["C", "D", "D#", "F", "G", "G#", "A#"];
    private static List<string> cLocrian = ["C", "C#", "D#", "F", "F#", "G#", "A#"];

    [TestMethod]
    public void GetScale_ReturnsIonianScale()
    {
        var root = Notes.SharpNotes.Where(x => x.Value == "C").First();
        Key key = new(root);
        key.UseFlats = false;
        key.Mode = Mode.Ionian;
        var expected = cIonian;
        var actual = key.Scale;
        CollectionAssert.AreEqual(expected, actual, $"{nameof(cIonian)} is not correct");
    }
    [TestMethod]
    public void GetScale_ReturnsDorianScale()
    {
        var root = Notes.SharpNotes.Where(x => x.Value == "C").First();
        Key key = new(root);
        key.UseFlats = false;
        key.Mode = Mode.Dorian;
        var expected = cDorian;
        var actual = key.Scale;
        CollectionAssert.AreEqual(expected, actual, $"{nameof(cDorian)} is not correct");
    }
    [TestMethod]
    public void GetScale_ReturnsPhrygianScale()
    {
        var root = Notes.SharpNotes.Where(x => x.Value == "C").First();
        Key key = new(root, Mode.Phrygian, false);
        //key.UseFlats = false;
        key.Mode = Mode.Phrygian;
        var expected = cPhrygian;
        var actual = key.Scale;
        CollectionAssert.AreEqual(expected, actual, $"{nameof(cPhrygian)} is not correct");
    }
    [TestMethod]
    public void GetScale_ReturnsLydianScale()
    {
        var root = Notes.SharpNotes.Where(x => x.Value == "C").First();
        Key key = new(root);
        key.UseFlats = false;
        key.Mode = Mode.Lydian;
        var expected = cLydian;
        var actual = key.Scale;
        CollectionAssert.AreEqual(expected, actual, $"{nameof(cLydian)} is not correct");
    }
    [TestMethod]
    public void GetScale_ReturnsMixolydianScale()
    {
        var root = Notes.SharpNotes.Where(x => x.Value == "C").First();
        Key key = new(root);
        key.UseFlats = false;
        key.Mode = Mode.Mixolydian;
        var expected = cMixolydian;
        var actual = key.Scale;
        CollectionAssert.AreEqual(expected, actual, $"{nameof(cMixolydian)} is not correct");
    }
    [TestMethod]
    public void GetScale_ReturnsAeolianScale()
    {
        var root = Notes.SharpNotes.Where(x => x.Value == "C").First();
        Key key = new(root);
        key.UseFlats = false;
        key.Mode = Mode.Aeolian;
        var expected = cAeolian;
        var actual = key.Scale;
        CollectionAssert.AreEqual(expected, actual, $"{nameof(cAeolian)} is not correct");
    }
    [TestMethod]
    public void GetScale_ReturnsLocrianScale()
    {
        var root = Notes.SharpNotes.Where(x => x.Value == "C").First();
        Key key = new(root);
        key.UseFlats = false;
        key.Mode = Mode.Locrian;
        var expected = cLocrian;
        var actual = key.Scale;
        CollectionAssert.AreEqual(expected, actual, $"{nameof(cLocrian)} is not correct");
    }
}
