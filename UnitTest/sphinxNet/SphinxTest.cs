using System;
using System.IO;
using ContentCleaner.MediaManager;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using NUnit.Framework;
using SphinxNet;
namespace UnitTest
{
  /// <summary>
  /// This file is to test the code to make sure that is is working
  /// We are working with unmanaged code, so we have to handle things carefully
  /// </summary>
  [TestFixture]
  public class SphinxTest
  {
    [Test]
    public void TestCreatingVariables()
    {
      // pocketSphinx directory
      string cmuSphinxDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "cmusphinx");
      string pocketSphinxExe = Path.Combine(cmuSphinxDir, "pocketsphinx_continuous.exe");
      string audioFile = Path.Combine(cmuSphinxDir, "test", "data", "goforward.raw");
      string modelFile = Path.Combine(cmuSphinxDir, "model", "en-us", "en-us");
      string languageModelFile = Path.Combine(cmuSphinxDir, "model", "en-us", "en-us.lm.bin");
      string dictionary = Path.Combine(cmuSphinxDir, "model", "en-us", "cmudict-en-us.dict");

      CommandLineSphinx sphinx = new CommandLineSphinx(pocketSphinxExe, cmuSphinxDir);
      int exitCode = sphinx.ScanAudioFile(audioFile, modelFile, languageModelFile, dictionary);

      Assert.AreEqual("go forward ten meters", sphinx.ProcessOutput);
    }

    [Test]
    public void TestWavFile()
    {
      // pocketSphinx directory
      string cmuSphinxDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "cmusphinx");
      string pocketSphinxExe = Path.Combine(cmuSphinxDir, "pocketsphinx_continuous.exe");
      string audioFile = Path.Combine(cmuSphinxDir, "test", "data", "testWav.wav");
      string modelFile = Path.Combine(cmuSphinxDir, "model", "en-us", "en-us");
      string languageModelFile = Path.Combine(cmuSphinxDir, "model", "en-us", "en-us.lm.bin");
      string dictionary = Path.Combine(cmuSphinxDir, "model", "en-us", "cmudict-en-us.dict");

      CommandLineSphinx sphinx = new CommandLineSphinx(pocketSphinxExe, cmuSphinxDir);
      int exitCode = sphinx.ScanAudioFile(audioFile, modelFile, languageModelFile, dictionary);

      Assert.AreEqual("go forward ten meters", sphinx.ProcessOutput);
    }

    [Test]
    public void TestCorrectFormat()
    {
      string movieFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "sample", "RvB_s1_e04.m4v");

      MediaFile mediaFile = new MediaFile(movieFile);

      string outputWavFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "sample", "testOutputOne.Wav");
      string singleChWavFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "sample", "singleChannel.wav");

      // based on the Item Create a new media file for use
      using (Engine engine = new Engine())
      {
        ConversionOptions opts = new ConversionOptions();
        ConversionOptions secondOpts = new ConversionOptions();
        engine.GetMetadata(mediaFile);

        TimeSpan mediaDuration = mediaFile.Metadata.Duration;
        TimeSpan halfDuration = new TimeSpan(mediaDuration.Ticks / 5);
        opts.CutMedia(TimeSpan.Zero, halfDuration);
        opts.EnableAudioDownMixing = true;
        opts.AudioSampleRate = AudioSampleRate.Hz16000;
                
        MediaFile outputFile = new MediaFile(singleChWavFile);
        engine.Convert(mediaFile, outputFile, opts);
        engine.GetMetadata(outputFile);
        Assert.AreEqual("mono", outputFile.Metadata.AudioData.ChannelOutput);
      }
      
      string cmuSphinxDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "cmusphinx");
      string pocketSphinxExe = Path.Combine(cmuSphinxDir, "pocketsphinx_continuous.exe");
      string audioFile = singleChWavFile;
      string modelFile = Path.Combine(cmuSphinxDir, "model", "en-us", "en-us");
      string languageModelFile = Path.Combine(cmuSphinxDir, "model", "en-us", "en-us.lm.bin");
      string dictionary = Path.Combine(cmuSphinxDir, "model", "en-us", "cmudict-en-us.dict");

      CommandLineSphinx sphinx = new CommandLineSphinx(pocketSphinxExe, cmuSphinxDir);
      int exitCode = sphinx.ScanAudioFile(audioFile, modelFile, languageModelFile, dictionary);

      Assert.IsTrue(!string.IsNullOrEmpty(sphinx.ProcessOutput));
    }

    [Test]
    public void TestKeyWordParseing()
    {
      string audioFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "sample", "helloWorld.m4a");

      MediaFile mediaFile = new MediaFile(audioFile);

      string singleChWavFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "sample", "testingOneTwoThree.wav");

      // based on the Item Create a new media file for use
      using (Engine engine = new Engine())
      {
        ConversionOptions opts = new ConversionOptions();
        ConversionOptions secondOpts = new ConversionOptions();
        engine.GetMetadata(mediaFile);

        // TimeSpan mediaDuration = mediaFile.Metadata.Duration;
        // TimeSpan halfDuration = new TimeSpan(mediaDuration.Ticks / 5);
        opts.EnableAudioDownMixing = true;
        opts.AudioSampleRate = AudioSampleRate.Hz16000;

        MediaFile outputFile = new MediaFile(singleChWavFile);
        engine.Convert(mediaFile, outputFile, opts);
        engine.GetMetadata(outputFile);
        Assert.AreEqual("mono", outputFile.Metadata.AudioData.ChannelOutput);
      }

      string cmuSphinxDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "cmusphinx");
      string pocketSphinxExe = Path.Combine(cmuSphinxDir, "pocketsphinx_continuous.exe");
      string modelFile = Path.Combine(cmuSphinxDir, "model", "en-us", "en-us");
      string languageModelFile = Path.Combine(cmuSphinxDir, "model", "en-us", "en-us.lm.bin");
      string dictionary = Path.Combine(cmuSphinxDir, "model", "en-us", "cmudict-en-us.dict");
      SphinxOptions options = new SphinxOptions();
      //options.KeyPhrases.Add("hello world");
      //options.KeyPhrasesThreshold = "1e-40";

      CommandLineSphinx sphinx = new CommandLineSphinx(pocketSphinxExe, cmuSphinxDir);
      int exitCode = sphinx.ScanAudioFile(singleChWavFile, modelFile, languageModelFile, dictionary, options);

      Assert.IsTrue(!string.IsNullOrEmpty(sphinx.ProcessOutput));
    }

    [Test]
    public void TestKeyWordParsing()
    {
      string audioFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "sample", "oneTwoThree.wav");

      string cmuSphinxDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "cmusphinx");
      string pocketSphinxExe = Path.Combine(cmuSphinxDir, "pocketsphinx_continuous.exe");
      string modelFile = Path.Combine(cmuSphinxDir, "model", "en-us", "en-us");
      string languageModelFile = Path.Combine(cmuSphinxDir, "model", "en-us", "en-us.lm.bin");
      string dictionary = Path.Combine(cmuSphinxDir, "model", "en-us", "cmudict-en-us.dict");
      SphinxOptions options = new SphinxOptions();
      //options.KeyPhrases.Add("hello world");
      //options.KeyPhrasesThreshold = "1e-40";

      CommandLineSphinx sphinx = new CommandLineSphinx(pocketSphinxExe, cmuSphinxDir);
      int exitCode = sphinx.ScanAudioFile(audioFile, modelFile, languageModelFile, dictionary, options);
      string expectedResults = "one two three hello world";
      Assert.AreEqual(expectedResults, sphinx.ProcessOutput);
    }

    [Test]
    public void TestKeyWordSearchParsing()
    {
      string audioFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "sample", "oneTwoThree.wav");

      string cmuSphinxDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "cmusphinx");
      string pocketSphinxExe = Path.Combine(cmuSphinxDir, "pocketsphinx_continuous.exe");
      string modelFile = Path.Combine(cmuSphinxDir, "model", "en-us", "en-us");
      string languageModelFile = Path.Combine(cmuSphinxDir, "model", "en-us", "en-us.lm.bin");
      string dictionary = Path.Combine(cmuSphinxDir, "model", "en-us", "cmudict-en-us.dict");
      SphinxOptions options = new SphinxOptions();
      options.KeyPhrases.Add("two three");
      options.KeyPhrasesThreshold = "1e-40";
      options.TimeFlag = true;

      CommandLineSphinx sphinx = new CommandLineSphinx(pocketSphinxExe, cmuSphinxDir);
      //int exitCode = sphinx.ScanAudioFile(audioFile, modelFile, languageModelFile, dictionary, options);
      SphinxResult result = sphinx.Scan(audioFile, modelFile, languageModelFile, dictionary, options);
      string expectedResults = "one two three hello world";
      Assert.AreEqual(expectedResults, sphinx.ProcessOutput);
    }
  }
}
