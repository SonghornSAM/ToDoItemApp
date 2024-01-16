using ToDoItemApi.Models;
using ToDoItemApi.Repository.Interface;
using ToDoItemApi.Services.Interface;
using static ToDoItemApi.Helpers.BaseDataModel;

namespace ToDoItemApi.Services
{
    public class ToDoItemService: IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository;
        public ToDoItemService(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }
        public List<ToDoItem> GetAllToDoItems(int id)
        {
            return _toDoItemRepository.GetAllToDoItems(id);
        }
        public BaseResponse CreateToDoItem(CreateToDoItemRequest req)
        {
            return _toDoItemRepository.CreateToDoItem(req);
        }
        public BaseResponse UpdateToDoItem(UpdateToDoItemRequest req)
        {
            return _toDoItemRepository.UpdateToDoItem(req);
        }
    }
}
