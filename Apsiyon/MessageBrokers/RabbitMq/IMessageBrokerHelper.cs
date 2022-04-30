namespace Apsiyon.MessageBrokers.RabbitMq
{
    public interface IMessageBrokerHelper
    {
        void QueueMessage(string messageText);
    }
}