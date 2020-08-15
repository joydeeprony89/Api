using Api.Businesss;
using Api.Controllers;
using Api.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace Api.Test
{
    [TestClass]
    public class ApiTest
    {
        [TestMethod]
        public async Task Get_ReturnOkResponse()
        {
            //arrange
            var mock = Mock.Create<IItemService>();
            var controller = new TwoApiController(mock);
            Mock.Arrange(() => mock.Get(1, 10, "item1"));
            //act
            var actualResponse = await controller.Get();
            var okRes = actualResponse as OkObjectResult;
            //arrange
            Assert.AreEqual(200, okRes.StatusCode);
        }

        [TestMethod]
        public async Task Delete_ReturnOkResponse()
        {
            //arrange
            var mock = Mock.Create<IItemService>();
            var controller = new TwoApiController(mock);
            Mock.Arrange(() => mock.Delete("category1"));
            //act
            var actualResponse = await controller.Delete("category1");
            var okRes = actualResponse as OkObjectResult;
            //arrange
            Assert.AreEqual(200, okRes.StatusCode);
        }
    }
}
