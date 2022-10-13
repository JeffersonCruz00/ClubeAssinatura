using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubeAss.Domain.Interface.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();

        Task<Customer> GetByid(int id);

        Task<int> Add(Customer customer);

        Task<int> Alter(Customer customer);

        void Remove(int id);
    }
}