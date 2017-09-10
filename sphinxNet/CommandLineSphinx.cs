using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace SphinxNet
{

  public class CommandLineSphinx
  {

    public CommandLineSphinx(string exePath, string workingDir)
    {
      this.PocketSphinxPath = exePath;
      this.WorkingDirectory = workingDir;
      this.ProcessOutput = "";
      this.ProcessDebugLog = "";
    }

    public string PocketSphinxPath { get; set; }

    public string WorkingDirectory { get; set; }

    public string ProcessOutput { get; private set; }

    public string ProcessDebugLog { get; private set; }

    public int ScanAudioFile(string audioFile, string acousticModelFiles, string languageModelInputFile, string pronunciationDictionaryInputFile, SphinxOptions options = null)
    {
      options = options ?? new SphinxOptions();

      // string the arguements together
      StringBuilder arguments = new StringBuilder();
      arguments.Append("/C ");
      arguments.Append(this.PocketSphinxPath);
      arguments.Append(" -infile ");
      arguments.Append(audioFile);
      arguments.Append(" -hmm ");
      arguments.Append(acousticModelFiles);
      arguments.Append(" -lm ");
      arguments.Append(languageModelInputFile);
      arguments.Append(" -dict ");
      arguments.Append(pronunciationDictionaryInputFile);

      // Add keyphrases to the commandline request
      if (options.KeyPhrases.Count > 0)
      {
        arguments.Append(" -keyphrase \"");
        foreach (string phrase in options.KeyPhrases)
        {
          arguments.Append(phrase);
          arguments.Append(" ");
        }

        arguments.Append("\"");
      }

      if (options.KeyPhrasesThreshold != null)
      {
        arguments.Append(" -kws_threshold ");
        arguments.Append(options.KeyPhrasesThreshold);
      }

      if (options.TimeFlag)
      {
        arguments.Append(" -time yes");
      }

      ProcessStartInfo info = new ProcessStartInfo("cmd.exe", arguments.ToString());

      info.UseShellExecute = false;
      info.RedirectStandardOutput = true;
      info.RedirectStandardError = true;
      info.CreateNoWindow = true;

      Process process = new Process();
      process.StartInfo = info;
      process.OutputDataReceived += Process_OutputDataReceived;
      process.ErrorDataReceived += Process_ErrorDataReceived;
      process.Start();
      process.BeginOutputReadLine();
      process.BeginErrorReadLine();
      process.WaitForExit();
      
      return process.ExitCode;
    }
    public SphinxResult Scan(string audioFile, string acousticModelFiles, string languageModelInputFile, string pronunciationDictionaryInputFile, SphinxOptions options = null)
    {
      options = options ?? new SphinxOptions();

      // string the arguements together
      StringBuilder arguments = new StringBuilder();
      arguments.Append("/C ");
      arguments.Append(this.PocketSphinxPath);
      arguments.Append(" -infile ");
      arguments.Append(audioFile);
      arguments.Append(" -hmm ");
      arguments.Append(acousticModelFiles);
      arguments.Append(" -lm ");
      arguments.Append(languageModelInputFile);
      arguments.Append(" -dict ");
      arguments.Append(pronunciationDictionaryInputFile);

      // Add keyphrases to the commandline request
      if (options.KeyPhrases.Count > 0)
      {
        arguments.Append(" -keyphrase \"");
        foreach (string phrase in options.KeyPhrases)
        {
          arguments.Append(phrase);
          arguments.Append(" ");
        }

        arguments.Append("\"");
      }

      if (options.KeyPhrasesThreshold != null)
      {
        arguments.Append(" -kws_threshold ");
        arguments.Append(options.KeyPhrasesThreshold);
      }

      if (options.TimeFlag)
      {
        arguments.Append(" -time yes");
      }

      ProcessStartInfo info = new ProcessStartInfo("cmd.exe", arguments.ToString());

      info.UseShellExecute = false;
      info.RedirectStandardOutput = true;
      info.RedirectStandardError = true;
      info.CreateNoWindow = true;

      Process process = new Process();
      process.StartInfo = info;
      process.OutputDataReceived += Process_OutputDataReceived;
      process.ErrorDataReceived += Process_ErrorDataReceived;
      process.Start();
      process.BeginOutputReadLine();
      process.BeginErrorReadLine();
      process.WaitForExit();
      SphinxResult result = new SphinxResult(this.ProcessOutput, options, process.ExitCode);
      
      return result;
    }

    private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
      if (e.Data != null)
      {
        this.ProcessDebugLog += e.Data;
        Debug.WriteLine(e.Data);
      }
    }

    private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
      if (e.Data != null)
      {
        this.ProcessOutput += e.Data;
        Debug.WriteLine(e.Data);
      }
    }


  }
}
