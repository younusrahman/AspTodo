using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class ToDoTasks
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
                //[Display(Name ="helloworld")]  It is  possible to change name in add a task
                //more info https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-6.0
        [Required]
        public string Details { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime ComplitedDate { get; set; } = default(DateTime);
    }
}
