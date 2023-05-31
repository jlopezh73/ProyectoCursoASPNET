FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /ProyectoCursos
COPY . /ProyectoCursos
RUN dotnet restore
RUN dotnet publish -c Release -o bin

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /ProyectoCursos
COPY --from=build-env /ProyectoCursos/bin .
ENTRYPOINT [ "dotnet", "ProyectoCursos.dll" ]