using System.Text.Json;
using TaskAPI.Models;

namespace TaskAPI.Services
{
    public static class TasksItemService
    {
        private static readonly string filePath = "tasks.json";

        private static async Task<List<TasksItem>> ReadAllAsync()
        {
            if (!File.Exists(filePath)) return new List<TasksItem>();

            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<List<TasksItem>>(json) ?? new List<TasksItem>();
        }

        private static async Task WriteAllAsync(List<TasksItem> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }

        public static async Task<bool> SaveToFile(TasksItem datosAGuardar)
        {
            try
            {
                var tasks = await ReadAllAsync();
                datosAGuardar.TasksItemID = tasks.Count > 0 ? tasks.Max(t => t.TasksItemID) + 1 : 1;
                tasks.Add(datosAGuardar);
                await WriteAllAsync(tasks);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task<List<TasksItem>> GetAllTasksItems()
        {
            try
            {
                return await ReadAllAsync();
            }
            catch (Exception)
            {
                return new List<TasksItem>();
            }
        }

        public static async Task<TasksItem?> GetTasksItemByID(int id)
        {
            try
            {
                var tasks = await ReadAllAsync();
                return tasks.FirstOrDefault(t => t.TasksItemID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static async Task<bool> DeleteTaskItemByID(int id)
        {
            try
            {
                var tasks = await ReadAllAsync();
                var task = tasks.FirstOrDefault(t => t.TasksItemID == id);
                if (task is null) return false;
                tasks.Remove(task);
                await WriteAllAsync(tasks);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task<bool> UpdateTaskItemByID(int id, TasksItem updatedItem)
        {
            try
            {
                var tasks = await ReadAllAsync();
                var index = tasks.FindIndex(t => t.TasksItemID == id);
                if (index == -1) return false;
                updatedItem.TasksItemID = id;
                tasks[index] = updatedItem;
                await WriteAllAsync(tasks);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}