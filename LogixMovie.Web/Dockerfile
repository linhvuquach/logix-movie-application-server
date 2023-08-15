#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LogixMovie.Web/LogixMovie.Web.csproj", "LogixMovie.Web/"]
COPY ["LogixMovie.Application/LogixMovie.Application.csproj", "LogixMovie.Application/"]
COPY ["LogixMovie.Domain/LogixMovie.Domain.csproj", "LogixMovie.Domain/"]
COPY ["LogixMovie.Infrastructure/LogixMovie.Infrastructure.csproj", "LogixMovie.Infrastructure/"]
RUN dotnet restore "LogixMovie.Web/LogixMovie.Web.csproj"
COPY . .
WORKDIR "/src/LogixMovie.Web"
RUN dotnet build "LogixMovie.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LogixMovie.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogixMovie.Web.dll"]