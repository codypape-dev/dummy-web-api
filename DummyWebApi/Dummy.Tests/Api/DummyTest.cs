using AutoMapper;
using Dummy.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;
using bl = Dummy.Business.Dummies;
using dto = Dummy.DTO;
using model = Dummy.Model;


namespace Dummy.Tests.Api
{
    public class DummyTest
    {
        [Fact]
        public void Add_WhenValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var mockRepo = new Mock<bl.IDummy>();
            var mockRepoMapper = new Mock<IMapper>();
            var newDummy = new dto.Dummy()
            {
                Name = "Test",
                LastName = "Dummy"
            };

            var response = new model.Dummy()
            {
                Id = "1",
                Name = "Test",
                LastName = "Dummy"
            };

            mockRepo.Setup(repo => repo.Create(It.IsAny<model.Dummy>()))
                .Returns(response);

            var controller = new DummiesController(mockRepo.Object, mockRepoMapper.Object);


            // Act
            IActionResult result = controller.Post(newDummy);

            // Assert            
            Assert.IsType<CreatedResult>(result);

        }

        [Fact]
        public void Get_ReturnsCreatedResponse()
        {
            // Arrange
            var mockRepo = new Mock<bl.IDummy>();
            var mockRepoMapper = new Mock<IMapper>();
           
            var response = new List<model.Dummy>
            {
                new model.Dummy()
                {
                    Id = "1",
                    Name = "Test",
                    LastName = "Dummy"
                },
                new model.Dummy()
                {
                    Id = "2",
                    Name = "Test",
                    LastName = "Dummy"
                }
            };

            mockRepo.Setup(repo => repo.GetDummies())
                .Returns(response);

            var controller = new DummiesController(mockRepo.Object, mockRepoMapper.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsType<List<dto.Dummy>>(result);

        }
    }
}
