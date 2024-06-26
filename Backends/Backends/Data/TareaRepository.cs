using Backends.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace Backends.Data
{
    public class TareaRepository : ITareaRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public TareaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> CreateTarea(Tarea tarea)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO tarea(titulo,descripcion)
                        VALUES (@Titulo,@Descripcion)";
            var result= await db.ExecuteAsync(sql, new {tarea.Titulo,tarea.Descripcion});
            return result > 0;
        }

        public async Task<bool> DeleteTarea(Tarea tarea)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM tarea WHERE id=@Id";
            var result=await db.ExecuteAsync(sql, new {Id= tarea.Id});
            return result > 0;
        }

        public async Task<IEnumerable<Tarea>> GetAllTareas()
        {
            var db = dbConnection();
            var sql = @"SELECT id,titulo,descripcion,completada 
                        FROM tarea";
            return await  db.QueryAsync<Tarea>(sql, new { });
        }

        public  async Task<Tarea> GetTareaById(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id,titulo,descripcion,completada 
                        FROM tarea
                        WHERE id=@Id";
            return  await db.QueryFirstOrDefaultAsync<Tarea>(sql, new {Id = id});
        }

        public async Task<bool> UpdateTarea(Tarea tarea)
        {
            var db = dbConnection();
            var sql = @"UPDATE tarea
                        SET titulo = @Titulo,
                            descripcion=@descripcion,
                            completada=@Completada
                        WHERE id = @Id ";
            var result = await db.ExecuteAsync(sql, new { tarea.Titulo, tarea.Descripcion, tarea.Completada,tarea.Id });
            return result > 0;
        }

    }
}
