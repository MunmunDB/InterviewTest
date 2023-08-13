using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ResponseSystem.Business;

namespace TestAPI
{
    public class ResponseDetailsUnitTest
    {
        /*Set of inputs for test senerios */
        string InputMessagefr1 = "The alarm id from video server number 7 is 10.";
        string InputMessagefr2 = "Alarm id 10 has been received from video server number 7.";
        string InputMessageWrong = "Alarm id 10 and video server number 7.";
        string testfilepath = Path.Join(Directory.GetCurrentDirectory(), "\\TestResourceFile\\TestFormats.csv");

        ResponseDetails resObj;
       

        [SetUp]
        public void Setup()
        {
            var logger = new Mock<ILogger<ResponseDetails>>();
            var utilObj = new Utility(new Mock<ILogger<Utility>>().Object);
            resObj = new ResponseDetails(logger.Object, utilObj);
        }

        [Test]
        public void TestParseFormat_1()
        {
            var obj = resObj.ParseResponse(InputMessagefr1);
            Assert.AreEqual(obj.alamNo, 10);
            Assert.AreEqual(obj.serverNo, 7);

        }
        [Test]
        public void TestParseFormat_2()
        {
            var obj = resObj.ParseResponse(InputMessagefr2);
            Assert.AreEqual(obj.alamNo,10);
            Assert.AreEqual(obj.serverNo, 7);
        }
        [Test]
        public void TestParseFormat_Wrong()
        {
            Assert.That(resObj.ParseResponse(InputMessageWrong), Is.SameAs(new ResponseDetail() { message = InputMessageWrong, alamNo = 0, serverNo = 0 }));
        }

      
    }
}