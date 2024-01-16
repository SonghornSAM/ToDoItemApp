using System.ComponentModel.DataAnnotations;

namespace ToDoItemApi.Models
{
    public class GetToDoItemResponse
    {
        public List<ToDoItem> ToDoItems { get; set; }
    }
    public class ToDoItem
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set;}
        public string ModifiedBy { get; set; }
    }
}
