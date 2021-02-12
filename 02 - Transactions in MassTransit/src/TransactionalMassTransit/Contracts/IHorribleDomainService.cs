using System.Threading.Tasks;

namespace TransactionalMassTransit.Contracts
{
    public interface IHorribleDomainService
    {
        void MyMethodThatAlwaysFails();
    }
}
