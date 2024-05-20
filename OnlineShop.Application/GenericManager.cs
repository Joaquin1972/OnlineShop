using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application
{
    /// <summary>
    /// Clase genérica de manager
    /// </summary>
    public class GenericManager<T> where T : class
    {
        /// <summary>
        /// Contexto de datos del manager
        /// </summary>

        public ApplicationDbContext Context { get; private set; }

        /// <summary>
        /// Constructor del manager
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public GenericManager(ApplicationDbContext context)
        {
            Context = context;

        }

        /// <summary>
        /// Añade una entidad al contexto de datos
        /// </summary>
        /// <param name="entity">Entidad a añadir</param>
        /// <returns>Entidad añadida</returns>
        public T Add(T entity)
        {
            return Context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Elimina una entidad del contexto de datos
        /// </summary>
        /// <param name="entity">Entidad a eliminar</param>
        /// <returns>Entidad eliminada</returns>

        public T Remove(T entity)
        {
            return Context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Obtiene una entidad por sus posible claves
        /// </summary>
        /// <param name="key">Claves del objeto</param>
        /// <returns>Entidad si es encontrada</returns>


        /// <summary>
        /// Leer todas las entidades
        /// </summary>
        /// <returns>Lista de entidades</returns>
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public T GetById(object[] key)
        {
            return Context.Set<T>().Find(key);
        }

        /// <summary>
        /// Obtiene una entidad por su clave int
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Entidad si es encontrada</returns>

        public T GetById(int id)
        {
            return GetById(new object[] { id });
        }



    }
}
