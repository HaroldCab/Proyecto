using Backends.Model;

namespace Backends.Data
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> GetAllTareas();
        Task<Tarea> GetTareaById(int id);
        Task<bool> CreateTarea(Tarea tarea);
        Task<bool> UpdateTarea(Tarea tarea);
        Task<bool> DeleteTarea(Tarea tarea);

    }
}
