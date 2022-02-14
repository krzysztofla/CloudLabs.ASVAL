FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["client/CloudLabs.ASVAL.Finance.Client/CloudLabs.ASVAL.Finance.Client.csproj", "CloudLabs.ASVAL.Finance.Client/"]
RUN dotnet restore "client/CloudLabs.ASVAL.Finance.Client/CloudLabs.ASVAL.Finance.Client.csproj"
COPY . .
WORKDIR "/src/CloudLabs.ASVAL.Finance.Client"
RUN dotnet build "CloudLabs.ASVAL.Finance.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudLabs.ASVAL.Finance.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudLabs.ASVAL.Finance.Client.dll"]
