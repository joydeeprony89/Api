using Api.Businesss;
using Api.Controllers;
using Api.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock;

namespace Api.Test
{
    [TestClass]
    public class ApiTest
    {
        List<Response> expectedResponse = new List<Response>()
            {
                new Response()
                {
                    Id = 1,
                    MessageCount = 2,
                    Unread = false,
                    Participants = new List<Participant>(),
                    LastMessage = new LastMessages()
                    {
                        Subject = "Pizza",
                        Snippet = "Lets have Pizza!.",
                        CreatedAt = "Wed Aug 10 2020 19:32:19 GMT+0530 (India Standard Time)"
                    }
                }
            };
        [TestMethod]
        public void GetAllMails_ReturnOkResponse()
        {
            //arrange
            var mock = Mock.Create<IUserConnectService>();
            var controller = new UserConnectController(mock);
            Mock.Arrange(() => mock.GetAllMails()).Returns(expectedResponse);
            //act
            var actualResponse = controller.GetAllMails();
            var okRes = actualResponse as OkObjectResult;
            //arrange
            Assert.AreEqual(200, okRes.StatusCode);
        }

        [TestMethod]
        public void GetAllMails_Return_SujectPizza()
        {
            //arrange
            var mock = Mock.Create<IUserConnectService>();
            var controller = new UserConnectController(mock);
            Mock.Arrange(() => mock.GetAllMails()).Returns(expectedResponse);
            //act
            var actualResponse = controller.GetAllMails() as OkObjectResult;
            var okRes = actualResponse.Value as List<Response>;

            var actual = okRes.Select(i => i.LastMessage.Subject).FirstOrDefault();
            var expected = expectedResponse.Select(i => i.LastMessage.Subject).FirstOrDefault();
            //arrange
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllMails_Return_ContainsOneResponse()
        {
            //arrange
            var expectedResponse = new List<Response>();
            var mock = Mock.Create<IUserConnectService>();
            var controller = new UserConnectController(mock);
            Mock.Arrange(() => mock.GetAllMails()).Returns(expectedResponse);
            //act
            var actualResponse = controller.GetAllMails() as OkObjectResult;
            var okRes = actualResponse.Value as List<Response>;
            //arrange
            Assert.AreEqual(expectedResponse.Count, okRes.Count);
        }
    }
}
