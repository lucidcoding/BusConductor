using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using BusConductor.Application.Contracts;
using BusConductor.Application.Implementations;
using BusConductor.Application.Requests;
using BusConductor.Domain.Common;
using BusConductor.Domain.RepositoryContracts;
using BusConductor.UI.Controllers;
using BusConductor.UI.ViewModels;

namespace BusConductor.UI.UnitTests.Controllers.TaskControllerTests
{
    [TestFixture]
    public class RaiseTests
    {
        //private Mock<ITaskService> _taskService;
        //private Mock<IUserService> _userService;
        //private Mock<ITaskRepository> _taskRepository;
        //private Mock<ITaskTypeRepository> _taskTypeRepository;
        //private Mock<IUserRepository> _userRepository;
        //private TaskController _taskController;

        [SetUp]
        public void SetUp()
        {
            //_taskService = new Mock<ITaskService>();
            //_userService = new Mock<IUserService>();
            //_taskRepository = new Mock<ITaskRepository>();
            //_taskTypeRepository = new Mock<ITaskTypeRepository>();
            //_userRepository = new Mock<IUserRepository>();

            //_taskController = new TaskController(
            //    _taskService.Object,
            //    _userService.Object,
            //    _taskRepository.Object,
            //    _taskTypeRepository.Object,
            //    _userRepository.Object);
        }

        [Test]
        public void Given_valid_parameters_When_Raise_called_Then_calls_service_with_correct_parameters()
        {
            var taskService = new Mock<ITaskService>();
            var userService = new Mock<IUserService>();
            var taskRepository = new Mock<ITaskRepository>();
            var taskTypeRepository = new Mock<ITaskTypeRepository>();
            var userRepository = new Mock<IUserRepository>();
            var principal = new Mock<IPrincipal>();
            var identity = new Mock<IIdentity>();
            var httpContext = new Mock<HttpContextBase>();
            var controllerContext = new Mock<ControllerContext>();

            var taskController = new TaskController(
                taskService.Object,
                userService.Object,
                taskRepository.Object,
                taskTypeRepository.Object,
                userRepository.Object);

            identity
                .SetupGet(x => x.Name)
                .Returns("Test Username 01");

            principal
                .SetupGet(x => x.Identity)
                .Returns(identity.Object);

            httpContext
                .SetupGet(x => x.User)
                .Returns(principal.Object);

            controllerContext
                .SetupGet(x => x.HttpContext)
                .Returns(httpContext.Object);


            taskController.ControllerContext = controllerContext.Object;

            var viewModel = new TaskRaiseEditViewModel
                                {
                                    Description = "Raise Description 01",
                                    AssignedToId = Guid.NewGuid(),
                                    TypeId = Guid.NewGuid()
                                };

            taskService
                .Setup(x => x.ValidateRaise(It.IsAny<RaiseTaskRequest>()))
                .Returns(new ValidationMessageCollection());

            taskController.Raise(viewModel);

            taskService.Verify(x => x.ValidateRaise(It.Is<RaiseTaskRequest>(
                y => y.Description == "Raise Description 01"
                && y.AssignedToId == viewModel.AssignedToId
                && y.TypeId == viewModel.TypeId
                && y.UserName == "Test Username 01")),
                Times.Once());

            taskService.Verify(x => x.Raise(It.Is<RaiseTaskRequest>(
                y => y.Description == "Raise Description 01"
                && y.AssignedToId == viewModel.AssignedToId
                && y.TypeId == viewModel.TypeId
                && y.UserName == "Test Username 01")),
                Times.Once());
        }
    }
}
