FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG MIGRATE
WORKDIR /src
COPY ["WhereMyBooks.Api/WhereMyBooks.Api.csproj", "WhereMyBooks.Api/"]
COPY ["WhereMyBooks.Infrastructure/WhereMyBooks.Infrastructure.csproj", "WhereMyBooks.Infrastructure/"]
COPY ["WhereMyBooks.Core/WhereMyBooks.Core.csproj", "WhereMyBooks.Core/"]
COPY ["WhereMyBooks.Application/WhereMyBooks.Application.csproj", "WhereMyBooks.Application/"]
RUN dotnet restore "WhereMyBooks.Api/WhereMyBooks.Api.csproj"
COPY . .
WORKDIR "/src/WhereMyBooks.Api"
RUN dotnet build "WhereMyBooks.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WhereMyBooks.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM build AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
ENV RUN_MIGRATE=${MIGRATE}
COPY [".", "/app/WhereMyBooks"]
ENTRYPOINT ["dotnet", "WhereMyBooks.Api.dll"]
