using System;
using System.Collections.Generic;

namespace SphinxNet
{
  
  /// <summary>
  /// Parses the result output to make more sense
  /// </summary>
  public class SphinxResult
  {
    
    /// <summary>
    /// Parses through the results of the sphinx results, and parses it based on the options
    /// </summary>
    /// <param name="outputString">The output of the program</param>
    /// <param name="options">The options used for the program</param>
    public SphinxResult(string outputString, SphinxOptions options)
    {
      this.OutputString = outputString;
      this.Options = options;
    }

    public string OutputString { get; set; }
    public SphinxOptions Options{ get; set; }

    public string Text { get; set; }

    private void ParseOutput()
    {
      int index = this.OutputString.IndexOf("<s>");
      if (index > 0)
      {
        this.Text = this.OutputString;
      }
      else
      {
        this.Text = this.OutputString.Substring(0, index);
      }

      // check if we are using the time option
      if (this.Options.TimeFlag)
      {



      }


    }

    
  }
}
