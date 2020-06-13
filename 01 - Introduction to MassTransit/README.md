##Introduction to MassTransit
A short an simple introduction to MassTransit, the free and open-source distributed application framework for .NET https://masstransit-project.com/

###How do I run this demo?

1. Clone the project
2. Run the following commands to set up and run RabbitMQ in a container
   `docker run -d --hostname my-rabbit --name rabbitmq -e RABBITMQ_DEFAULT_USER=guest -e RABBITMQ_DEFAULT_PASS=guest rabbitmq:3-management`
3. `docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management`
4. Navigate to the `DockerFile` for this project and run  
   `docker build -t masstransit.autofac.demo .`
5. Create and start a container from this image  
   `docker run -it --network host masstransit.autofac.demo`
6. Have fun with Docker, dotnet core 3.1 and RabbitMQ!
