using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaToolkit;
using MediaToolkit.Model;
using OSDBnet;

namespace ContentCleaner
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void openInputFileLocation_Click(object sender, EventArgs e)
    {
      OpenFileDialog openDialog = new OpenFileDialog();
      openDialog.Filter = "MP4 (*.mp4|*.mp4|All files (*.*)|*.*";
      if( openDialog.ShowDialog() == DialogResult.OK)
      {
        this.InputFileTextBox.Text = openDialog.FileName;
      }
    }

    private void outputFileButton_Click(object sender, EventArgs e)
    {
      OpenFileDialog openDialog = new OpenFileDialog();
      openDialog.Filter = "MP4 (*.mp4|*.mp4|All files (*.*)|*.*";
      if (openDialog.ShowDialog() == DialogResult.OK)
      {
        this.outputFileTextBox.Text = openDialog.FileName;
      }
    }

    private void FetchButton_Click(object sender, EventArgs e)
    {
      string user = ConfigurationManager.AppSettings["userName"];
      string password = ConfigurationManager.AppSettings["password"];
      string userAgent = ConfigurationManager.AppSettings["TestUserAgent"];
      IAnonymousClient client = Osdb.Login(user, password, "en", userAgent);
      int season = int.Parse(this.seasonTextBox.Text);
      int episode = int.Parse(this.episodeTextBox.Text);
      IList<Subtitle> results = client.SearchSubtitlesFromQuery("en", this.showTextBox.Text, season, episode);

      List<Subtitle> filteredResults = new List<Subtitle>(results.Where((x) => x.LanguageId == "eng"));
      client.DownloadSubtitleToPath(this.outputFileTextBox.Text, filteredResults[0]);

      MediaFile inputFile = new MediaFile(this.InputFileTextBox.Text);
      string tempOutputFile = Path.ChangeExtension(this.InputFileTextBox.Text, "wav");
      MediaFile outputFile = new MediaFile(tempOutputFile);

      using (Engine engine = new Engine())
      {
        engine.Convert(inputFile, outputFile);
      }
    }

    public string FetchSubtitle(string user, string password, string userAgent, string subDirectory, string series, int season, int episode)
    {
      // May want to update to support multiple languages
      IAnonymousClient client = Osdb.Login(user, password, "en", userAgent);
      IList<Subtitle> results = client.SearchSubtitlesFromQuery("en", series, season, episode);

      List<Subtitle> filteredResults = new List<Subtitle>(results.Where((x) => x.LanguageId == "eng"));
      client.DownloadSubtitleToPath(subDirectory, filteredResults[0]);
      string subtitleFile = Path.Combine(subDirectory, filteredResults[0].SubtitleFileName);
      return subtitleFile;
    }
  }
}
