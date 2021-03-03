FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CRUD-project.Web/CRUD-project.Web.csproj", "CRUD-project.Web/"]
COPY ["CRUD-project.Domain/CRUD-project.Domain.csproj", "CRUD-project.Domain/"]
COPY ["CRUD-project.Application/CRUD-project.Application.csproj", "CRUD-project.Application/"]
COPY ["CRUD-project.Infra/CRUD-project.Infra.csproj", "CRUD-project.Infra/"]
RUN dotnet restore "CRUD-project.Web/CRUD-project.Web.csproj"
COPY . .
WORKDIR "/src/CRUD-project.Web"
RUN dotnet build "CRUD-project.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CRUD-project.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CRUD-project.Web.dll"]