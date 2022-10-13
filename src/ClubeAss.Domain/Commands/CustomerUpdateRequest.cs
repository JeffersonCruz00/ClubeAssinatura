using MediatR;

namespace ClubeAss.Domain.Commands
{
    public class CustomerUpdateRequest : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}