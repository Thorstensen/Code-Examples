## Introduction to MassTransit
A brief introduction to MassTransit, the free and open-source distributed application framework for .NET https://masstransit-project.com/

### How do I run this demo?

1. Navigate to the src folder with your favorite terminal and find `docker-compose.yml`
2. Found it? Nice. Run the folllowing command `docker-compose up --no-start --build && docker-compose run masstransit`

If you want to debug the code without installing rabbitmq? Run the following docker image:

`docker run -it  -p 15672:15672 -p 5672:5672 rabbitmq:3-management`
