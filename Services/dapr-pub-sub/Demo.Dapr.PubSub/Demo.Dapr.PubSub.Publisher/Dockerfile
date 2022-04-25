#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Demo.Dapr.PubSub.Publisher/Demo.Dapr.PubSub.Publisher.csproj", "Demo.Dapr.PubSub.Publisher/"]
RUN dotnet restore "Demo.Dapr.PubSub.Publisher/Demo.Dapr.PubSub.Publisher.csproj"
COPY . .
WORKDIR "/src/Demo.Dapr.PubSub.Publisher"
RUN dotnet build "Demo.Dapr.PubSub.Publisher.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.Dapr.PubSub.Publisher.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.Dapr.PubSub.Publisher.dll"]