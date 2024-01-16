namespace ToDoItemApi.Models
{
    public class UpdateToDoItemRequest
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string ModifiedBy { get; set; }
    }
}
