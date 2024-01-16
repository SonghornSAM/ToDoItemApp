using ToDoItemApi.Models;
using static ToDoItemApi.Helpers.BaseDataModel;

namespace ToDoItemApi.Services.Interface
{
    public interface IToDoItemService
    {

        List<ToDoItem> GetAllToDoItems(int id);
        BaseResponse CreateToDoItem(CreateToDoItemRequest req);
        BaseResponse UpdateToDoItem(UpdateToDoItemRequest req);


    }
}
