using ClubeAss.Domain;
using ClubeAss.Domain.Interface.Repository;
using ClubeAss.Repository.Postegre.Base;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ClubeAss.Repository.Postegre
{
    public class CustomerRepository : ICustomerRepository
    {
        private DbSession _session;

        public CustomerRepository(DbSession session)
        {
            _session = session;
        }

        public Task<int> Add(Customer customer)
        {

            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Id", customer.Id, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Nome", customer.Nome, DbType.String, ParameterDirection.Input);

            return _session.Connection.ExecuteAsync($"INSERT INTO public.\"Cliente\" (\"Nome\") VALUES(@Nome)", parameter, _session.Transaction);
        }

        public Task<int> Alter(Customer customer)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Id", customer.Id, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Nome", customer.Nome, DbType.String, ParameterDirection.Input);

            return _session.Connection.ExecuteAsync($"Update public.\"Cliente\" set \"Nome\" = @Nome where id = @id", parameter, _session.Transaction);
        }      

        public Task<IEnumerable<Customer>> GetAll()
        {
            return _session.Connection.QueryAsync<Customer>($"SELECT * FROM public.\"Cliente\"", null, _session.Transaction);
        }

        public Task<Customer> GetByid(int id)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

            return _session.Connection.QueryFirstOrDefaultAsync<Customer>($"SELECT * FROM public.\"Cliente\" where id = @id", parameter, _session.Transaction);
        }

        public void Remove(int id)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

            _session.Connection.ExecuteAsync($"Delete FROM public.\"Cliente\" where id = @id", parameter, _session.Transaction);
        }

       
    }
}