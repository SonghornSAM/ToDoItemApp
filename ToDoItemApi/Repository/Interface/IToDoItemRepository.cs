using ToDoItemApi.Models;
using static ToDoItemApi.Helpers.BaseDataModel;

namespace ToDoItemApi.Repository.Interface
{
    public interface IToDoItemRepository
    {
        List<ToDoItem> GetAllToDoItems(int id);
        BaseResponse CreateToDoItem(CreateToDoItemRequest req);
        BaseResponse UpdateToDoItem(UpdateToDoItemRequest req);
    }
}
