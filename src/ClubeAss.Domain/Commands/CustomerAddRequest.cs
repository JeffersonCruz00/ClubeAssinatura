using MediatR;

namespace ClubeAss.Domain.Commands
{
    public class CustomerAddRequest : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}