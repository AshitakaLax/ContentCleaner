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
      Assert.AreEqual(2, splitter.Segments.Count);
      Assert.AreEqual(1, splitter.Segments[0].SubtitleLines);
    }

    [Test]
    public void TestSomething()
    {
      MediaFile mediaFile = new MediaFile("sample/RvB_s1_e04.m4v");

      string subTitleFile = "sample/RvB_s1_e04.srt";
      MediaSplitter splitter = new MediaSplitter(mediaFile, subTitleFile, 0);
      splitter.SplitIntoSegments();
    }

    [Test]
    public void TestSplitFile()
    {
      string movieFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "sample", "RvB_s1_e04.m4v");

      MediaFile mediaFile = new MediaFile(movieFile);


      string outputWavFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "sample", "testOutputOne.wav");
      string outputTwoWavFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "sample", "testOutputTwo.wav");
      
      // based on the Item Create a new media file for use
      using (Engine engine = new Engine())
      {
        ConversionOptions opts = new ConversionOptions();
        ConversionOptions secondOpts = new ConversionOptions();
        engine.GetMetadata(mediaFile);

        TimeSpan mediaDuration = mediaFile.Metadata.Duration;
        TimeSpan halfDuration = new TimeSpan(mediaDuration.Ticks / 2);
        opts.CutMedia(TimeSpan.Zero, halfDuration);
        secondOpts.CutMedia(halfDuration, halfDuration);
        MediaFile outputFile = new MediaFile(outputWavFile);
        MediaFile outputTwoFile = new MediaFile(outputTwoWavFile);
        engine.Convert(mediaFile, outputFile, opts);
        engine.Convert(mediaFile, outputTwoFile, secondOpts);

        engine.GetMetadata(outputFile);
        engine.GetMetadata(outputTwoFile);
        Assert.That(halfDuration, Is.EqualTo(outputFile.Metadata.Duration).Within(TimeSpan.FromSeconds(1.0)));
        Assert.That(halfDuration, Is.EqualTo(outputTwoFile.Metadata.Duration).Within(TimeSpan.FromSeconds(1.0)));
      }
    }
  }
}
