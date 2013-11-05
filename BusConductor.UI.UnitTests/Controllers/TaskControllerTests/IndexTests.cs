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
using BusConductor.Domain.Entities;
using BusConductor.Domain.Enumerations;
using BusConductor.Domain.RepositoryContracts;
using BusConductor.UI.Controllers;
using BusConductor.UI.ViewModels;

namespace BusConductor.UI.UnitTests.Controllers.TaskControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        private Mock<IPrincipal> _principal;
        private Mock<IIdentity> _identity;
        private Mock<HttpContextBase> _httpContext;
        private Mock<ControllerContext> _controllerContext;
        private Mock<IUserService> _userService;
        private Mock<ITaskService> _taskService;
        private Mock<ITaskRepository> _taskRepository;
        private Mock<ITaskTypeRepository> _taskTypeRepository;
        private Mock<IUserRepository> _userRepository;
        private TaskController _taskController;
        private User _user1;
        private User _user2;
        private List<User> _users;
        private TaskType _taskType1;
        private TaskType _taskType2;
        private List<TaskType> _taskTypes;
        private Mock<Task> _task1;
        private Mock<Task> _task2;
        private List<Task> _tasks;

        [SetUp]
        public void SetUp()
        {
            _principal = new Mock<IPrincipal>();
            _identity = new Mock<IIdentity>();
            _httpContext = new Mock<HttpContextBase>();
            _controllerContext = new Mock<ControllerContext>();
            _taskService = new Mock<ITaskService>();
            _userService = new Mock<IUserService>();
            _taskRepository = new Mock<ITaskRepository>();
            _taskTypeRepository = new Mock<ITaskTypeRepository>();
            _userRepository = new Mock<IUserRepository>();

            _taskController = new TaskController(
                _taskService.Object,
                _userService.Object,
                _taskRepository.Object,
                _taskTypeRepository.Object,
                _userRepository.Object);

            _user1 = new User { Id = Guid.NewGuid(), Username = "Barry Blue" };
            _user2 = new User { Id = Guid.NewGuid(), Username = "Susan Silver" };

            _users = new List<User>
                         {
                             _user1,
                             _user2
                         };

            _taskType1 = new TaskType {Description = "Test Task Type 01"};
            _taskType2 = new TaskType {Description = "Test Task Type 02"};

            _taskTypes = new List<TaskType>
                             {
                                 _taskType1,
                                 _taskType2
                             };

            _httpContext
                .SetupGet(x => x.User)
                .Returns(_principal.Object);

            _controllerContext
                .SetupGet(x => x.HttpContext)
                .Returns(_httpContext.Object);

            _taskController.ControllerContext = _controllerContext.Object;

            _principal
                .SetupGet(x => x.Identity)
                .Returns(_identity.Object);

            _identity
                .SetupGet(x => x.Name)
                .Returns("Test Name");

            _task1 = new Mock<Task>();
            _task1.Setup(x => x.Id).Returns(Guid.NewGuid());
            _task1.Setup(x => x.AssignedTo).Returns(_user1);
            _task1.Setup(x => x.Description).Returns("Test Task 01");
            _task1.Setup(x => x.DueDate).Returns(new DateTime(2020, 10, 01, 9, 0, 0));
            _task1.Setup(x => x.RagStatus).Returns(RagStatus.Green);
            _task1.Setup(x => x.Status).Returns(TaskStatus.InProgress);
            _task1.Setup(x => x.Type).Returns(_taskType1);
            _task2 = new Mock<Task>();
            _task2.Setup(x => x.Id).Returns(Guid.NewGuid());
            _task2.Setup(x => x.AssignedTo).Returns(_user2);
            _task2.Setup(x => x.Description).Returns("Test Task 02");
            _task2.Setup(x => x.DueDate).Returns(new DateTime(2000, 1, 15, 12, 0, 0));
            _task2.Setup(x => x.RagStatus).Returns(RagStatus.Red);
            _task2.Setup(x => x.Status).Returns(TaskStatus.InProgress);
            _task2.Setup(x => x.Type).Returns(_taskType2);

            _tasks = new List<Task>
                            {
                                _task1.Object,
                                _task2.Object
                            };

            _taskRepository
                .Setup(x => x.Search(null, null, null, null, null, false))
                .Returns(_tasks);

            _userRepository
                .Setup(x => x.GetAll())
                .Returns(_users);

            _taskTypeRepository
                .Setup(x => x.GetAll())
                .Returns(_taskTypes);
        }

        //Need to mock Task, otherwise I can't test RagStatus without testing Domain at the same time!
        [Test]
        public void Given_repositories_return_certain_values_When_Index_is_called_The_correct_view_model_is_retunred()
        {
            var actionResult = _taskController.Index() as ViewResult;

            //Add user to controller.

            var viewModel = actionResult.Model as TaskIndexViewModel;
            Assert.That(viewModel, Is.Not.Null);
            Assert.That(viewModel, Is.TypeOf<TaskIndexViewModel>());

            //other stuff
            var users = viewModel.Users.ToList();
            var taskTypes = viewModel.TaskTypes.ToList();
            var taskStatuses = viewModel.TaskStatuses.ToList();
            Assert.That(users.Count, Is.EqualTo(3));
            Assert.That(users[0].Text, Is.EqualTo("[Please Select...]"));
            Assert.That(users[0].Value, Is.Empty);
            Assert.That(users[1].Text, Is.EqualTo("Barry Blue"));
            Assert.That(users[1].Value, Is.EqualTo(_user1.Id.ToString()));
            Assert.That(users[2].Text, Is.EqualTo("Susan Silver"));
            Assert.That(users[2].Value, Is.EqualTo(_user2.Id.ToString()));
            Assert.That(viewModel.UserId, Is.Null);
            Assert.That(taskTypes.Count, Is.EqualTo(3));
            Assert.That(taskTypes[0].Text, Is.EqualTo("[Please Select...]"));
            Assert.That(taskTypes[0].Value, Is.Empty);
            Assert.That(taskTypes[1].Text, Is.EqualTo("Test Task Type 01"));
            Assert.That(taskTypes[1].Value, Is.EqualTo(_taskType1.Id.ToString()));
            Assert.That(taskTypes[2].Text, Is.EqualTo("Test Task Type 02"));
            Assert.That(taskTypes[2].Value, Is.EqualTo(_taskType2.Id.ToString()));
            Assert.That(viewModel.TaskTypeId, Is.Null);
            Assert.That(viewModel.DueDateFrom, Is.Null);
            Assert.That(viewModel.DueDateTo, Is.Null);
            Assert.That(taskStatuses.Count, Is.EqualTo(4));
            Assert.That(taskStatuses[0].Text, Is.EqualTo("[Please Select...]"));
            Assert.That(taskStatuses[0].Value, Is.Empty);
            Assert.That(taskStatuses[1].Text, Is.EqualTo("InProgress"));
            Assert.That(taskStatuses[1].Value, Is.EqualTo("1"));
            Assert.That(taskStatuses[2].Text, Is.EqualTo("Completed"));
            Assert.That(taskStatuses[2].Value, Is.EqualTo("2"));
            Assert.That(taskStatuses[3].Text, Is.EqualTo("Cancelled"));
            Assert.That(taskStatuses[3].Value, Is.EqualTo("3"));
            Assert.That(viewModel.TaskStatus, Is.Null);
            Assert.That(viewModel.Tasks.Count, Is.EqualTo(2));
            Assert.That(viewModel.Tasks[0].TaskId, Is.EqualTo(_tasks[0].Id.Value));
            Assert.That(viewModel.Tasks[0].AssignedTo, Is.EqualTo(_tasks[0].AssignedTo.Username));
            Assert.That(viewModel.Tasks[0].Description, Is.EqualTo(_tasks[0].Description));
            Assert.That(viewModel.Tasks[0].DueDate, Is.EqualTo(_tasks[0].DueDate));
            Assert.That(viewModel.Tasks[0].RagStatus, Is.EqualTo("Green"));
            Assert.That(viewModel.Tasks[0].Status, Is.EqualTo("InProgress"));
            Assert.That(viewModel.Tasks[0].Type, Is.EqualTo("Test Task Type 01"));
            Assert.That(viewModel.Tasks[1].TaskId, Is.EqualTo(_tasks[1].Id.Value));
            Assert.That(viewModel.Tasks[1].AssignedTo, Is.EqualTo(_tasks[1].AssignedTo.Username));
            Assert.That(viewModel.Tasks[1].Description, Is.EqualTo(_tasks[1].Description));
            Assert.That(viewModel.Tasks[1].DueDate, Is.EqualTo(_tasks[1].DueDate));
            Assert.That(viewModel.Tasks[1].RagStatus, Is.EqualTo("Red"));
            Assert.That(viewModel.Tasks[1].Status, Is.EqualTo("InProgress"));
            Assert.That(viewModel.Tasks[1].Type, Is.EqualTo("Test Task Type 02"));
        }
    }
}
