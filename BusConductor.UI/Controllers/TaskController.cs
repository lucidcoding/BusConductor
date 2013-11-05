using System;
using System.Linq;
using System.Web.Mvc;
using BusConductor.Application.Contracts;
using BusConductor.Application.Requests;
using BusConductor.Domain.Enumerations;
using BusConductor.Domain.RepositoryContracts;
using BusConductor.UI.ActionFilters;
using BusConductor.UI.Mappers;
using BusConductor.UI.ViewModels;

namespace BusConductor.UI.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskTypeRepository _taskTypeRepository;
        private readonly IUserRepository _userRepository;

        public TaskController(
            ITaskService taskService,
            IUserService userService,
            ITaskRepository taskRepository,
            ITaskTypeRepository taskTypeRepository,
            IUserRepository userRepository)
        {
            _taskService = taskService;
            _userService = userService;
            _taskRepository = taskRepository;
            _taskTypeRepository = taskTypeRepository;
            _userRepository = userRepository;
        }

        [Log]
        [NHibernateSession]
        public ActionResult Index()
        {
            _userService.EnsureExists(HttpContext.User.Identity.Name);  //This is not very secure, we would not do this in real life.
            var users = _userRepository.GetAll();
            var taskTypes = _taskTypeRepository.GetAll();
            var tasks = _taskRepository.Search(null, null, null, null, null, false);
            var viewModel = TaskIndexViewModelMapper.MapToViewModel(users, null, taskTypes, null, null, null, null, tasks);
            return View(viewModel);
        }

        [NHibernateSession]
        [HttpPost]
        public PartialViewResult Index(TaskIndexViewModel viewModel)
        {
            //Todo: validation somewhere?
            var tasks = _taskRepository.Search(
                viewModel.UserId,
                viewModel.TaskTypeId,
                viewModel.DueDateFrom,
                viewModel.DueDateTo,
                viewModel.TaskStatus,
                false);

            var partialViewModel = TaskIndexTaskViewModelMapper.MapToViewModel(tasks);
            return PartialView("_IndexTasks", partialViewModel);
        }

        [Log]
        [NHibernateSession]
        public ActionResult Raise()
        {
            var users = _userRepository.GetAll();
            var taskTypes = _taskTypeRepository.GetAll();
            var viewModel = TaskRaiseEditViewModelMapper.MapToViewModel(users, taskTypes);
            return View("RaiseEdit", viewModel);
        }

        [Log]
        [NHibernateSession]
        [HttpPost]
        public ActionResult Raise(TaskRaiseEditViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                //todo: wrong do properly
                return Raise();
            }

            var request = new RaiseTaskRequest
                          {
                              Description = viewModel.Description,
                              AssignedToId = viewModel.AssignedToId,
                              TypeId = viewModel.TypeId,
                              UserName = HttpContext.User.Identity.Name
                          };

            var validationMessages = _taskService.ValidateRaise(request).ToList();
            
            if(validationMessages.Any())
            {
                validationMessages.ForEach(x => ModelState.AddModelError(x.Field, x.Text));
                 return Raise();
            }

            _taskService.Raise(request);

            return RedirectToAction("/Index");
        }

        [Log]
        [NHibernateSession]
        public ActionResult Edit(Guid taskId)
        {
            var task = _taskRepository.GetById(taskId);
            var users = _userRepository.GetAll();
            var taskTypes = _taskTypeRepository.GetAll();
            var viewModel = TaskRaiseEditViewModelMapper.MapToViewModel(task, users, taskTypes);
            return View("RaiseEdit", viewModel);
        }

        [Log]
        [NHibernateSession]
        [HttpPost]
        public ActionResult Edit(TaskRaiseEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //todo: worng do properly
                return Raise();
            }

            //todo: refactor into mapper?

            var request = new EditTaskRequest
            {
                Id = viewModel.TaskId.Value,
                Description = viewModel.Description,
                AssignedToId = viewModel.AssignedToId,
                TypeId = viewModel.TypeId,
                UserName = HttpContext.User.Identity.Name
            };

            var validationMessages = _taskService.ValidateEdit(request).ToList();

            if (validationMessages.Any())
            {
                foreach (var validationMessage in validationMessages)
                {
                    ModelState.AddModelError(validationMessage.Field, validationMessage.Text);
                }

                return Raise();
            }

            _taskService.Edit(request);

            return RedirectToAction("/Index");
        }

        [Log]
        [NHibernateSession]
        [HttpPost]
        public PartialViewResult Cancel(Guid taskId, TaskIndexViewModel viewModel)
        {
            _taskService.Cancel(taskId, HttpContext.User.Identity.Name);
            //return null;
            return Index(viewModel);
        }
    }
}
