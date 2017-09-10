using System;
using System.Collections.Generic;

namespace SphinxNet
{
  
  /// <summary>
  /// EMPTY CLASS DEFINITION
  /// </summary>
  public class SphinxOptions
  {
    public SphinxOptions()
    {
      this.KeyPhrases = new List<string>();
      this.KeyPhrasesThreshold = null;
      this.TimeFlag = false;
    }

    /// <summary>
    /// 
    /// </summary>
    public List<string> KeyPhrases { get; set; }

    /// <summary>
    /// Has to be formatted as 1e-5 or 1e-50
    /// </summary>
    public string KeyPhrasesThreshold { get; set; }

    /// <summary>
    /// Adds the -time flag to the command line
    /// </summary>
    public bool TimeFlag { get; set; }
  }
}
