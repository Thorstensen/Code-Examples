namespace TransactionalMassTransit.Messages
{
    public class AMessage
    {
        public AMessage(string content)
        {
            Content = content;
        }

        public string Content { get; private set; }
    }
}
