FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CloudLabs.ASVAL.Fnance.Price.Feed/CloudLabs.ASVAL.Fnance.Price.Feed.csproj", "CloudLabs.ASVAL.Fnance.Price.Feed/"]
RUN dotnet restore "src/CloudLabs.ASVAL.Fnance.Price.Feed/CloudLabs.ASVAL.Fnance.Price.Feed.csproj"
COPY . .
WORKDIR "/src/CloudLabs.ASVAL.Fnance.Price.Feed"
RUN dotnet build "CloudLabs.ASVAL.Fnance.Price.Feed.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudLabs.ASVAL.Fnance.Price.Feed.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudLabs.ASVAL.Fnance.Price.Feed.dll"]
