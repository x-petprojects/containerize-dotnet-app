using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnStatusCode200()
    {
        // Arrange
        var mockUserService = new Mock<IUsersService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UserFixture.GetTestUsers());

        var sut = new UsersController(mockUserService.Object);

        // Act
        var result = (OkObjectResult) await sut.Get();

        // Assert
        result.StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task Get_OnSuccess_InvokesUserServiceExactlyOnes()
    {
        // Arrange
        var mockUserService = new Mock<IUsersService>();
        
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());


        var sut = new UsersController(mockUserService.Object);

        // Act
        var result = await sut.Get();

        // Assert
        mockUserService.Verify(
            ServiceFilterAttribute => ServiceFilterAttribute.GetAllUsers(),
            Times.Once());

    }

    [Fact]
    public async Task Get_OnSuccess_ReturnListOfUsers()
    {
        // Arrange
        var mockUserService = new Mock<IUsersService>();

        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UserFixture.GetTestUsers());


        var sut = new UsersController(mockUserService.Object);

        // Act
        var result = await sut.Get();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult) result;
        objectResult.Value.Should().BeOfType<List<User>>();

    }

    [Fact]
    public async Task Get_OnNoUsersFound_Returns404()
    {
        // Arrange
        var mockUserService = new Mock<IUsersService>();

        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());


        var sut = new UsersController(mockUserService.Object);

        // Act
        var result = await sut.Get();

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult) result;
        objectResult.StatusCode.Should().Be(404);
    }
}