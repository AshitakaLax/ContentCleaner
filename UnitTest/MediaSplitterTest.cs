using System;
using ContentCleaner.MediaManager;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using NUnit.Framework;

namespace UnitTest
{
  /// <summary>
  ///
  /// </summary>
  [TestFixture]
  public class MediaSplitterTest
  {
    [Test]
    public void TestSplitIntoSegments()
    {
      MediaFile mediaFile = new MediaFile("sample/RvB_s1_e04.m4v");

      string subTitleFile = "sample/Psych.2x02.65_Million_Years_Off.srt";
      MediaSplitter splitter = new MediaSplitter(mediaFile, subTitleFile, 0);
      splitter.SplitIntoSegments();
    }
  
  }
}
