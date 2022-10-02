using NetCoreApiMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiMySQL.Data.Repositories
{
    public interface IArticuloRepository
    {
        Task<IEnumerable<Artitulo>> GetAllArticles();
        Task<Artitulo> GetArticleById(int id);
        Task<bool> InsertArticle(Artitulo artitulo);
        Task<bool> UpdateArticle(Artitulo artitulo);
        Task<bool> DeleteArticle(Artitulo artitulo);
    }
}
