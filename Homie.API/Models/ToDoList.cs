namespace Homie.API.Models
{
    public class ToDoListItem
    {
        public Guid Id { get; set; }
        public Guid? ChoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean IsCompleted { get; set; }
        public DateTime DateToDo { get; set; }

    }
}
