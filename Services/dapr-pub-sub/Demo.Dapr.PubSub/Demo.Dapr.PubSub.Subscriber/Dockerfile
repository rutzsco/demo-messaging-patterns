#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Demo.Dapr.PubSub.Subscriber/Demo.Dapr.PubSub.Subscriber.csproj", "Demo.Dapr.PubSub.Subscriber/"]
RUN dotnet restore "Demo.Dapr.PubSub.Subscriber/Demo.Dapr.PubSub.Subscriber.csproj"
COPY . .
WORKDIR "/src/Demo.Dapr.PubSub.Subscriber"
RUN dotnet build "Demo.Dapr.PubSub.Subscriber.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.Dapr.PubSub.Subscriber.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.Dapr.PubSub.Subscriber.dll"]