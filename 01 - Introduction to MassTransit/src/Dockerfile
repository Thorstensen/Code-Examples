FROM mcr.microsoft.com/dotnet/core/runtime:3.1

COPY publish/ app/
WORKDIR /app
ENTRYPOINT ["dotnet", "MassTransitExample.Host.dll"]
