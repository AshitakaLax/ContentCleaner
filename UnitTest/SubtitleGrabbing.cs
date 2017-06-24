using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentCleaner;
using NUnit.Framework;

namespace UnitTest
{
  /// <summary>
  /// 
  /// </summary>
  [TestFixture]
  public class SubtitleGrabbing
  {
    
    [Test]
    public void TestGrabbingFile()
    {
      Form1 form = new Form1();

      string user = ConfigurationManager.AppSettings["userName"];
      string password = ConfigurationManager.AppSettings["password"];
      string userAgent = ConfigurationManager.AppSettings["TestUserAgent"];
      string currentDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "test1");
      if(!Directory.Exists(currentDir))
      {
        Directory.CreateDirectory(currentDir);
      }

      string subtitleFile = form.FetchSubtitle(user, password, userAgent, currentDir, "red-vs-blue-the-blood-gulch-chronicles", 1, 4);
      Assert.IsFalse(string.IsNullOrEmpty(subtitleFile));
    }
  }
}
