using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TaskAPI.Models;
using TaskAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        public async Task<List<TasksItem>> Get()
        {
            return await TasksItemService.GetAllTasksItems();
        }

        [HttpGet("{ID}")]
        public async Task<TasksItem> Get(int ID)
        {
            return await TasksItemService.GetTasksItemByID(ID);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TasksItem value)
        {
           var result = await TasksItemService.SaveToFile(value);

            return result ? Created() :  BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TasksItem value)
        {
            var result = await TasksItemService.UpdateTaskItemByID(id, value);  
            return result ? Ok() : BadRequest();
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            var result = await TasksItemService.DeleteTaskItemByID(ID);

            return result ? NoContent() : NotFound();

        }

    }
}
