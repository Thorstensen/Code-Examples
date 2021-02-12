using TransactionalMassTransit.Contracts;

namespace TransactionalMassTransit.Domain
{
    public class MyHorribleDomainService : IHorribleDomainService
    {
        public void MyMethodThatAlwaysFails()
        {
            throw new System.Exception();
        }
    }
}
