using MediatR;

namespace BaseModel.Application.Queries.City
{
    public class GetByNameAndUfQuery : IRequest<Domain.Entities.City?>
    {
        public string Name { get; set; }
        public string Uf { get; set; }
        public GetByNameAndUfQuery(string name, string uf)
        {
            Name = name;
            Uf = uf;
        }
    }
}
