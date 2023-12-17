namespace Homie.API.DTOs.ToDoList
{
    public class CreateToDoListItemResponseBody
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean IsCompleted { get; set; }
        public DateTime DateToDo { get; set; }
    }
}
