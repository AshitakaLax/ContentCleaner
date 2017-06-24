using System;
using System.IO;
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
      string movieFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "sample", "RvB_s1_e04.m4v");
      string subTitleFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "sample", "RvB_s1_e04.srt");
      MediaFile mediaFile = new MediaFile(movieFile);

      MediaSplitter splitter = new MediaSplitter(mediaFile, subTitleFile, 0);
      splitter.SplitIntoSegments();
    }

    [Test]
    public void TestSomething()
    {
      MediaFile mediaFile = new MediaFile("sample/RvB_s1_e04.m4v");

      string subTitleFile = "sample/RvB_s1_e04.srt";
      MediaSplitter splitter = new MediaSplitter(mediaFile, subTitleFile, 0);
      splitter.SplitIntoSegments();
    }

  }
}
