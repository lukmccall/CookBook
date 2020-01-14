using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using CookBook.API.Requests.UserController;
using CookBook.Controllers;
using CookBook.Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class UserControllerTests
{
    private UserController _requestController;
    private Mock<UserManager<ApplicationUser>> userManager;
    private GenericPrincipal principal;
    private GenericIdentity fakeIdentity;
    private Mock<HttpContext> fakeHttpContext;
    public UserControllerTests()
    {
        fakeHttpContext = new Mock<HttpContext>();
        fakeIdentity = new GenericIdentity("User");
        principal = new GenericPrincipal(fakeIdentity, null);

        fakeHttpContext.Setup(t => t.User).Returns(principal);
        userManager = UserControllerTests.MockUserManager<ApplicationUser>(_users);
    }

    [Fact]
    public async Task GetCurrentUserTest()
    {
        _requestController = new UserController(userManager.Object);
        _requestController.ControllerContext = new ControllerContext
        {
            HttpContext = fakeHttpContext.Object
        };

        var result = await _requestController.GeCurrentUser();
        result.Should().NotBeNull();
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        Assert.True(result.As<OkObjectResult>().StatusCode.Equals(200));
    }

    [Fact]
    public async Task UpdateCurrentUser_NotFound()
    {
        _requestController = new UserController(userManager.Object);

        _requestController.ControllerContext = new ControllerContext
        {
            HttpContext = fakeHttpContext.Object
        };

        var result = await _requestController.UpdateCurrentUser(null);
        var okResult = result.Should().BeOfType<NotFoundResult>().Subject;
        Assert.True(result.As<NotFoundResult>().StatusCode.Equals(404));
    }

    [Fact]
    public async Task UpdateCurrentUser_NoContent()
    {
        userManager.Setup(t => t.GetUserAsync(principal)).Returns(Task.FromResult(_users[0]));
        _requestController = new UserController(userManager.Object);

        _requestController.ControllerContext = new ControllerContext
        {
            HttpContext = fakeHttpContext.Object
        };

        var updateUser = new UpdateCurrentUserRequest() { UserName = "x", UserSurname = "y", Age = 12, Description = "z", PhoneNumber = "123123123" };
        var result = await _requestController.UpdateCurrentUser(updateUser);
        result.Should().NotBeNull();
        var okResult = result.Should().BeOfType<NoContentResult>().Subject;
        Assert.True(result.As<NoContentResult>().StatusCode.Equals(204));
    }
    [Fact]
    public async Task ChangeCurrentPassword_NotFound()
    {
        _requestController = new UserController(userManager.Object);

        _requestController.ControllerContext = new ControllerContext
        {
            HttpContext = fakeHttpContext.Object
        };

        var result = await _requestController.ChangeCurrentUserPassword(null);
        var okResult = result.Should().BeOfType<NotFoundResult>().Subject;
        Assert.True(result.As<NotFoundResult>().StatusCode.Equals(404));
    }
    private static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
    {
        var store = new Mock<IUserStore<TUser>>();
        var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
        mgr.Object.UserValidators.Add(new UserValidator<TUser>());
        mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

        mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
        mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
        mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

        return mgr;
    }

    private List<ApplicationUser> _users = new List<ApplicationUser>
 {
      new ApplicationUser() { Id = "1", Age = 12, UserName = "Name1", Description="Desc1" },
      new ApplicationUser() { Id = "2", Age = 1, UserName = "Name2", Description="Desc2" },
 };

}
