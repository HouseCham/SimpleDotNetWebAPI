using Dapper;
using MySql.Data.MySqlClient;
using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiMySQL.Data.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly MySqlConfiguration _connectionString;
        public ArticuloRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteArticle(Artitulo artitulo)
        {
            MySqlConnection db = dbConnection();
            string command = @"DELETE FROM articulos WHERE id = @Id";
            var result = await db.ExecuteAsync(command, new { Id = artitulo.Id });
            return result > 0;
        }

        public async Task<IEnumerable<Artitulo>> GetAllArticles()
        {
            MySqlConnection db = dbConnection();
            string command = @"SELECT id, nombre, descripcion, categoria FROM articulos";
            return await db.QueryAsync<Artitulo>(command, new {});
        }

        public async Task<Artitulo> GetArticleById(int id)
        {
            MySqlConnection db = dbConnection();
            string command = @"SELECT id, nombre, descripcion, categoria FROM articulos WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Artitulo>(command, new { Id = id });
        }

        public async Task<bool> InsertArticle(Artitulo artitulo)
        {
            MySqlConnection db = dbConnection();
            string command = @"INSERT INTO articulos (nombre, descripcion, categoria) VALUES (@Id, @Nombre, @Descripcion, @Categoria)";
            var result = await db.ExecuteAsync(command, new { artitulo.Nombre, artitulo.Descripcion, artitulo.Categoria });
            return result > 0;
        }

        public async Task<bool> UpdateArticle(Artitulo artitulo)
        {
            MySqlConnection db = dbConnection();
            string command = @"UPDATE articulos SET (nombre = @Nombre, descripcion = @Descripcion, categoria = @Categoria) WHERE id = @Id";
            var result = await db.ExecuteAsync(command, new { artitulo.Nombre, artitulo.Descripcion, artitulo.Categoria, artitulo.Id });
            return result > 0;
        }
    }
}
