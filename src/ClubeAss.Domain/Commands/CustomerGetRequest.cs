using MediatR;

namespace ClubeAss.Domain.Commands
{
    public class CustomerGetRequest : IRequest<CustomerResponse>
    {
        public CustomerGetRequest(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
