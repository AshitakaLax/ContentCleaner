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
    public SphinxResult(string outputString, SphinxOptions options, int exitCode)
    {
      this.OutputString = outputString;
      this.Options = options;
      this.ExitCode = exitCode;
      this.Words = new List<SphinxWord>();

      this.ParseOutput();
    }
    /// <summary>
    /// The exit code of cmusphinx process 
    /// </summary>
    public int ExitCode { get; private set; }

    public string OutputString { get; private set; }
    public SphinxOptions Options{ get; private set; }

    public List<SphinxWord> Words { get; set; }

    public string Text { get; private set; }

    private void ParseOutput()
    {
      int index = this.OutputString.IndexOf("<s>");
      if (index <= 0)
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
        // parse through the <s> to </s> section of
        // note that all strings have 6 digits of precisions after the decimal
        //one two three hello world<s> 0.120 0.200 0.999600one 0.210 0.490 0.532500two 0.500 0.750 0.482013three 0.760 1.260 0.999800<sil> 1.270 1.370 0.508353hello(2) 1.380 1.720 0.516553world 1.730 2.240 1.000000</s> 2.250 2.550 1.000000

        // split the text by space, and use the worlds to determine the time following it
        string remainingText = this.OutputString.Substring(index);
        List<string> listOfWords = new List<string>(this.Text.Split(' '));

        foreach (string word in listOfWords)
        {
          int wordIndex = remainingText.IndexOf(word);
          remainingText = remainingText.Substring(wordIndex);

          if(wordIndex > 0)
          {
            string currentWord = word;

            // check if there are any parenthesis
            remainingText = remainingText.Substring(word.Length).TrimStart(' ');
            if (remainingText[0] == '(')
            {
              remainingText = remainingText.Substring(remainingText.IndexOf(')')+2);
            }

            string startTimeStr = remainingText.Substring(0, remainingText.IndexOf(' '));

            remainingText = remainingText.Substring(startTimeStr.Length).TrimStart(' ');
            string endTimeStr = remainingText.Substring(0, remainingText.IndexOf(' '));

            remainingText = remainingText.Substring(endTimeStr.Length).TrimStart(' ');
            string durationStr = remainingText.Substring(0, remainingText.IndexOf('.')+6);

            double startingTime = Double.Parse(startTimeStr);
            double endTime = Double.Parse(endTimeStr);
            double durationTime = Double.Parse(durationStr);
            this.Words.Add(new SphinxWord(currentWord, startingTime, endTime, durationTime));
          }
        }
      }
    }
  }
}
