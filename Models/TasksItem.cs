using System.Text.Json;

namespace TaskAPI.Models
{
    public class TasksItem
    {
        public int TasksItemID { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string Titulo { get; set; }
        public string Descripcion { get; set; }



    }
}
