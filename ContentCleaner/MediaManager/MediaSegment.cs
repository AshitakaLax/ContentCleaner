using System;
using System.Collections.Generic;

namespace ContentCleaner.MediaManager
{
  /// <summary>
  /// This is a single segment of Media
  /// </summary>
  public class MediaSegment
  {
    private string FilePath;
    /// <summary>
    /// Creates a Segment of the Media
    /// </summary>
    public MediaSegment(string file)
    {
      FilePath = file;
    }

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
    public List<string> Lines { get; set; }

  }
}
