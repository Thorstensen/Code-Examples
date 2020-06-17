## Introduction to MassTransit
A short an simple introduction to MassTransit, the free and open-source distributed application framework for .NET https://masstransit-project.com/

### How do I run this demo?

1. Navigate to the src folder with your favorite terminal and find `docker-compose.yml`
2. Found it? Nice. Run the folllowing command `docker-compose up`

If you want to debug the code without installing rabbitmq? Run the following docker image:

`docker run -it  -p 15672:15672 -p 5672:5672 rabbitmq:3-management`
