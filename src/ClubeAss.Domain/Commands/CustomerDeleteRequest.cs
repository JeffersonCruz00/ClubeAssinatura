using MediatR;

namespace ClubeAss.Domain.Commands
{
    public class CustomerDeleteRequest : IRequest<BaseResponse>
    {
        public CustomerDeleteRequest(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
