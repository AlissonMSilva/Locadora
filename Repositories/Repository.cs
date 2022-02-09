using System.Collections.Generic;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Locadora.Repositories
{
    public class Repository<TModel> where TModel : class
    {
        private SqlConnection _connection;

        public Repository(SqlConnection connection)
        {
            _connection = DataBase.connection;
        }
        public void Create(TModel model)
        {
            _connection.Insert<TModel>(model);
        }
        public IEnumerable<TModel> Read()
            => _connection.GetAll<TModel>();

        public TModel Read(int id)
            =>_connection.Get<TModel>(id);
        
        public void Update(TModel model)
        {
            _connection.Update<TModel>(model);
        }
        public void Delete(TModel model)
        {
            _connection.Delete<TModel>(model);
        }
        public void Delete(int id)
        {
            var model = _connection.Get<TModel>(id);
            _connection.Delete<TModel>(model);
        }
        public void Delete(string table, string name)
        {
            var nome="Titulo";

            if(table!="Filme") nome="Nome";

            var delete = @$"
            DELETE FROM
                [{table}]
            WHERE
                [{table}].[{nome}]='{name}'
            ";

            _connection.Execute(delete);
        }
    }
}