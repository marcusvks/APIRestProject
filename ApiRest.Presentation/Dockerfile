#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiRest.Presentation/ApiRest.Presentation.csproj", "ApiRest.Presentation/"]
COPY ["Decrypter/Decrypter.csproj", "Decrypter/"]
COPY ["ApiRest.Infra/ApiRest.Infra.csproj", "ApiRest.Infra/"]
COPY ["ApiRest.Domain/ApiRest.Domain.csproj", "ApiRest.Domain/"]
RUN dotnet restore "ApiRest.Presentation/ApiRest.Presentation.csproj"
COPY . .
WORKDIR "/src/ApiRest.Presentation"
RUN dotnet build "ApiRest.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiRest.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiRest.Presentation.dll"]