#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS=http://+:80; https://+:443
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pricat.Api/Pricat.Api.csproj", "Pricat.Api/"]
RUN dotnet restore "Pricat.Api/Pricat.Api.csproj"
COPY . .
WORKDIR "/src/Pricat.Api"
RUN dotnet build "Pricat.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pricat.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pricat.Api.dll"]