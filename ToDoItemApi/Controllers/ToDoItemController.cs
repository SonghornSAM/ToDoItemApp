using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Linq;
using ToDoItemApi.Models;
using ToDoItemApi.Services.Interface;
using static ToDoItemApi.Helpers.BaseDataModel;

namespace ToDoItemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemService _toDoItemService;
        public ToDoItemController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        [HttpPost]
        [Route("get-all-todo-item")]
        public GetToDoItemResponse GetAllToDoItems(int id)
        {
            var result = _toDoItemService.GetAllToDoItems(id);
            return new GetToDoItemResponse { ToDoItems = result, };
        }

        [HttpPost]
        [Route("create-todo-item")]
        public ApiResponse<BaseResponse> CreateToDoItem(CreateToDoItemRequest req)
        {
            return new ApiResponse<BaseResponse>(_toDoItemService.CreateToDoItem(req));
        }

        [HttpPost]
        [Route("update-todo-item")]
        public ApiResponse<BaseResponse> UpdateToDoItem(UpdateToDoItemRequest req)
        {
            return new ApiResponse<BaseResponse>(_toDoItemService.UpdateToDoItem(req));
        }
    }
}
