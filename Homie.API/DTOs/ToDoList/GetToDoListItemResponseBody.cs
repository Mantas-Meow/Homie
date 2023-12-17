namespace Homie.API.DTOs.ToDoList
{
    public class GetToDoListItemResponseBody
    {
        public Guid Id { get; set; }
        public Guid? ChoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean IsCompleted { get; set; }
        public DateTime DateToDo { get; set; }
    }
}
