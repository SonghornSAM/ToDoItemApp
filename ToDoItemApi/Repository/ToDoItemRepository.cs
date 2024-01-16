using System.Data.SqlClient;
using System.Data;
using ToDoItemApi.Models;
using ToDoItemApi.Repository.Interface;
using Dapper;
using Newtonsoft.Json;
using static ToDoItemApi.Helpers.BaseDataModel;

namespace ToDoItemApi.Repository
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private const string connectionString = "Server=KH-NB045;Database=ToDoItemDb;User Id=sa;Password=123;";
        protected IEnumerable<T> GetData<T>(string spName, object? param = null)
        {
            IEnumerable<T> result;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    result = connection.Query<T>(spName, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"StoredProcedure:'{spName}', Param:{JsonConvert.SerializeObject(param)}, ErrorCode:'{e.HResult}', ErrorMessage:'{e.Message}'");
                throw;
            }
            return result;
        }

        public List<ToDoItem> GetAllToDoItems(int id)
        {
            return GetData<ToDoItem>("sp_GetAllToDoItem", new
            { 
                Id = id, 
            }).ToList();
        }
        public BaseResponse CreateToDoItem(CreateToDoItemRequest req)
        {
            return GetData<BaseResponse>("sp_InsertToDoItem", new
            {
                req.Title,
                req.Description,
                req.Status,
                req.CreatedBy
            }).FirstOrDefault();
        }

        public BaseResponse UpdateToDoItem(UpdateToDoItemRequest req)
        {
            return GetData<BaseResponse>("sp_UpdateToDoItem", new
            {
                req.Id,
                req.Title,
                req.Description,
                req.Status,
                req.ModifiedBy
            }).FirstOrDefault();
        }
    }
}
