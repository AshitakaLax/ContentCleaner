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
      IntPtr inoutCmdLn = IntPtr.Zero;
      IntPtr psArgs = PocketSphinx.ps_args();
      IntPtr config = PocketSphinx.cmd_ln_init(inoutCmdLn, psArgs, 2, "", "");
      Assert.IsNotNull(config);
    }

  }
}
