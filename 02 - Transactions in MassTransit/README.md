## Transactions in MassTransit
A demo showing how to use the TransactionalEnlistmentBus in MassTransit with RabbitMQ

### How do I run this demo?
It doesnt make sense to run this demo in a docker container, so you'll need to have 
dotnet core 3.1 installed as well as RabbitMQ. We'll pull and run RabbitMQ from DockerHub. 
1. Pull the image from docker hub: `docker pull rabbitmq:3-management`
2. Run the image in a container and map and expose two ports in the container `docker run --rm -it --hostname rabbitmq -p 15672:15672 -p 5672:5672 rabbitmq:3-management`
3. Open a new terminal and navigate to the `src/TransactionalMassTransit` folder and run `dotnet run`
