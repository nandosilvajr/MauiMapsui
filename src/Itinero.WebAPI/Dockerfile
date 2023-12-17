FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Itinero.WebAPI/Itinero.WebAPI.csproj", "src/Itinero.WebAPI/"]
RUN dotnet restore "src/Itinero.WebAPI/Itinero.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Itinero.WebAPI"
RUN dotnet build "Itinero.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Itinero.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Itinero.WebAPI.dll"]
