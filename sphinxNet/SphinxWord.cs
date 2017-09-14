using System;
using System.Collections.Generic;

namespace SphinxNet
{
  
  /// <summary>
  /// Parses a single word of the result
  /// </summary>
  public class SphinxWord
  {
    
    /// <summary>
    /// Parses through the results of the sphinx results, and parses it based on the options
    /// </summary>
    /// <param name="outputString">The output of the program</param>
    /// <param name="options">The options used for the program</param>
    public SphinxWord(string word, double startOffset, double endTimeOffset, double duration)
    {
      this.Word = word;
      // convert duration into timespan
      this.StartingOffset = TimeSpan.FromSeconds(startOffset);
      this.EndingOffset = TimeSpan.FromSeconds(endTimeOffset);
      this.Duration = new TimeSpan((long)(TimeSpan.TicksPerMillisecond * (duration * 1000)));
      //this.Duration = TimeSpan.FromMilliseconds(duration * 1000);
//      this.Duration = TimeSpan.FromSeconds(duration);
    }

    public TimeSpan StartingOffset { get; set; }

    public TimeSpan EndingOffset { get; set; }

    public string Word { get; set; }
    /// <summary>
    /// The exit code of cmusphinx process 
    /// </summary>
    public TimeSpan Duration { get; private set; }

    
  }
}
