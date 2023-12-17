namespace Homie.API.DTOs.ToDoList
{
    public class CreateToDoListItemRequestBody
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime  DateToDo { get; set; }
    }
}
