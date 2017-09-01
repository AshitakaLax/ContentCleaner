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

    public int ScanAudioFile(string audioFile, string acousticModelFiles, string languageModelInputFile, string pronunciationDictionaryInputFile)
    {
      // string the arguements together
      string arguments = "-infile " + audioFile + " -hmm " + acousticModelFiles + " -lm " + languageModelInputFile + " -dict " + pronunciationDictionaryInputFile;
      arguments = "/C " + this.PocketSphinxPath + " " + arguments;
      ProcessStartInfo info = new ProcessStartInfo("cmd.exe", arguments);

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
