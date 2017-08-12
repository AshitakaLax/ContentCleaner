using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text.RegularExpressions;
using MediaToolkit.Model;

namespace ContentCleaner.MediaManager
{
  /// <summary>
  /// This is a single segment of Media
  /// </summary>
  public class MediaSegment
  {
    /// <summary>
    /// Creates a Segment of the Media
    /// </summary>
    public MediaSegment(MediaFile wavFile, List<string> subtitleLines, TimeSpan startingPoint, TimeSpan duration, int index)
    {
      this.WaveFile = wavFile;
      this.SubtitleLines = subtitleLines;
      this.Offset = startingPoint;
      this.Duration = duration;
      this.Index = index;
      this.WavTextLines = new List<string>();
    }

    public MediaFile WaveFile { get; set; }

    /// <summary>
    /// The duration of the Media Segment
    /// </summary>
    public TimeSpan Duration { get; set; }

    /// <summary>
    /// The offset from the beginning of the File
    /// </summary>
    public TimeSpan Offset { get; set; }

    /// <summary>
    /// The Index of the media segment in the file
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// The string lines associated with the Media
    /// </summary>
    public List<string> SubtitleLines { get; set; }

    /// <summary>
    /// The string lines associated with the Media
    /// </summary>
    public List<string> WavTextLines { get; set; }

    public void ConvertWavFileToText()
    {
      using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US")))
      {
        // Create the grammar
        Choices subTitleText = new Choices();
        subTitleText.Add("secret");
        foreach (string subtitleLine in this.SubtitleLines)
        {
          subTitleText.Add(GetWords(subtitleLine));
        }
        SemanticResultKey srkComType = new SemanticResultKey("comtype", subTitleText.ToGrammarBuilder());

        GrammarBuilder builder = new GrammarBuilder();
        builder.Culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
        builder.AppendDictation();
        Grammar buildGrammar = new Grammar(builder);
        //Grammar subTitleGrammar = new Grammar(subTitleText.ToGrammarBuilder());
        //Grammar subTitleGrammar = new Grammar(new DictationGrammar());

        recognizer.LoadGrammar(buildGrammar);
        recognizer.SetInputToWaveFile(this.WaveFile.Filename);
        RecognitionResult result = recognizer.Recognize(TimeSpan.FromSeconds(5));

        List<string> resultWords = new List<string>();
        foreach (RecognizedWordUnit word in result.Words)
        {
          resultWords.Add(word.Text);
        }
      }
    }
    
    static string[] GetWords(string input)
    {
      MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");

      var words = from m in matches.Cast<Match>()
                  where !string.IsNullOrEmpty(m.Value)
                  select TrimSuffix(m.Value);

      return words.ToArray();
    }

    static string TrimSuffix(string word)
    {
      int apostropheLocation = word.IndexOf('\'');
      if (apostropheLocation != -1)
      {
        word = word.Substring(0, apostropheLocation);
      }

      return word;
    }
  }
}
