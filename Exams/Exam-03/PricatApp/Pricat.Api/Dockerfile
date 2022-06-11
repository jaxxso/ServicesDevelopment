#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 443
EXPOSE 3306

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pricat.Api/Pricat.Api.csproj", "Pricat.Api/"]
COPY ["Pricat.Infrastructure/Pricat.Infrastructure.csproj", "Pricat.Infrastructure/"]
COPY ["Pricat.Domain/Pricat.Domain.csproj", "Pricat.Domain/"]
COPY ["Pricat.Application/Pricat.Application.csproj", "Pricat.Application/"]
COPY ["Pricat.Utilities/Pricat.Utilities.csproj", "Pricat.Utilities/"]
RUN dotnet restore "Pricat.Api/Pricat.Api.csproj"
RUN dotnet restore "Pricat.Infrastructure/Pricat.Infrastructure.csproj"
RUN dotnet restore "Pricat.Domain/Pricat.Domain.csproj"
RUN dotnet restore "Pricat.Application/Pricat.Application.csproj"
RUN dotnet restore "Pricat.Utilities/Pricat.Utilities.csproj"
COPY . .
WORKDIR "/src/Pricat.Api"
WORKDIR "/src/Pricat.Infrastructure"
WORKDIR "/src/Pricat.Domain"
WORKDIR "/src/Pricat.Application"
WORKDIR "/src/Pricat.Utilities"
RUN dotnet build "Pricat.Api.csproj" -c Release -o /app/build
RUN dotnet build "Pricat.Infrastructure" -c Release -o /app/build
RUN dotnet build "Pricat.Domain" -c Release -o /app/build
RUN dotnet build "Pricat.Application.csproj" -c Release -o /app/build
RUN dotnet build "Pricat.Utilities.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pricat.Api.csproj" -c Release -o /app/publish
RUN dotnet publish "Pricat.Infrastructure" -c Release -o /app/publish
RUN dotnet publish "Pricat.Domain" -c Release -o /app/publish
RUN dotnet publish "Pricat.Application.csproj" -c Release -o /app/publish
RUN dotnet publish "Pricat.Utilities.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pricat.Api.dll"]
ENTRYPOINT ["dotnet", "Pricat.Infrastructure.dll"]
ENTRYPOINT ["dotnet", "Pricat.Domain.dll"]
ENTRYPOINT ["dotnet", "Pricat.Application.dll"]
ENTRYPOINT ["dotnet", "Pricat.Utilities.dll"]
