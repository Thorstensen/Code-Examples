
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /Solution
COPY MasstransitExample.Autofac.Host .
RUN dotnet publish MasstransitExample.Autofac.Host.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT dotnet MasstransitExample.Autofac.Host.dll
