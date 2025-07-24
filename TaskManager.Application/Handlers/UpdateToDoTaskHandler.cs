//using MediatR;
//using TaskManager.Application.Commands;
//using TaskManager.Core.Interfaces;

//namespace TaskManager.Application.Handlers
//{
//    public class UpdateToDoTaskHandler : IRequestHandler<UpdateToDoTaskCommand>
//    {
//        private readonly IToDoTaskRepository _repository;

//        public UpdateToDoTaskHandler(IToDoTaskRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task Handle(UpdateToDoTaskCommand request, CancellationToken cancellationToken)
//        {
//            var task = await _repository.GetbyIdAsync(request.TaskDto.Id);
//            if (task != null)
//            {
//                task.SetTitle(request.TaskDto.Title);
//                task.SetDescription(request.TaskDto.Description);
//                if (request.TaskDto.IsCompleted && !task.IsCompleted)
//                    task.MarkComplete();
//                else if (!request.TaskDto.IsCompleted && task.IsCompleted)
//                    task.MarkIncomplete();
//                await _repository.UpdateAsync(task);
//            }
//        }
//    }
//}
