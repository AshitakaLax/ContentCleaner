using System;
using System.Collections.Generic;
using System.IO;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using SubtitlesParser.Classes;
using SubtitlesParser.Classes.Parsers;

namespace ContentCleaner.MediaManager
{
  /// <summary>
  /// This will split the Media into segments that line up with the subtitle content.
  /// </summary>
  public class MediaSplitter
  {
    /// <summary>
    /// Takes a file and splits it into multiple files 
    /// </summary>
    /// <param name="contentFile"></param>
    public MediaSplitter(MediaFile contentFile, string srtSubtitleFile, int startEndBuffer)
    {
      this.OriginalContent = contentFile;
      this.SrtSubtitleFile = srtSubtitleFile;
      this.StartEndBuffer = startEndBuffer;
      this.Segments = new List<MediaSegment>();
    }

    /// <summary>
    /// The original Content to be split
    /// </summary>
    public MediaFile OriginalContent { get; set; }

    /// <summary>
    /// The Time in seconds before and after to scan for matching text
    /// </summary>
    public int StartEndBuffer { get; set; }

    /// <summary>
    /// List of segments to make up the whole media file
    /// </summary>
    public List<MediaSegment> Segments { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string SrtSubtitleFile { get; set; }

    /// <summary>
    /// Splits the original Media content into the Segments
    /// </summary>
    public void SplitIntoSegments()
    {
      SrtParser parser = new SrtParser();
      List<SubtitleItem> subtitles;
      using (FileStream stream = File.OpenRead(this.SrtSubtitleFile))
      {
        subtitles = parser.ParseStream(stream,System.Text.Encoding.UTF8);
        string originalFilenameWithoutExtension = Path.Combine(Path.GetDirectoryName(this.OriginalContent.Filename), Path.GetFileNameWithoutExtension(this.OriginalContent.Filename));

        foreach (SubtitleItem item in subtitles)
        {
          int itemIndex = subtitles.IndexOf(item);
          string outputWavFile = originalFilenameWithoutExtension + itemIndex + ".wav";

          // based on the Item Create a new media file for use
          using (Engine engine = new Engine())
          {
            ConversionOptions opts = new ConversionOptions();
            int durationMilliseconds = item.EndTime - item.StartTime;
            opts.CutMedia(TimeSpan.FromMilliseconds(item.StartTime), TimeSpan.FromMilliseconds(durationMilliseconds));
            MediaFile outputFile = new MediaFile(outputWavFile);
            engine.Convert(this.OriginalContent, outputFile, opts);

            MediaSegment segment = new MediaSegment(outputFile, item.Lines, TimeSpan.FromMilliseconds(item.StartTime), TimeSpan.FromMilliseconds(durationMilliseconds), itemIndex);
            segment.ConvertWavFileToText();
            this.Segments.Add(segment);
          } 
        }
      }
    }

    /// <summary>
    /// Stitches the 
    /// </summary>
    public MediaFile StitchTogether()
    {
      return null;
    }

    private MediaSegment CreateSegment(SubtitleItem subTitle)
    {
      return null;
    }
  }
}
