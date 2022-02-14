FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CloudLabs.ASVAL.Finance.Funds/CloudLabs.ASVAL.Finance.Funds.csproj", "CloudLabs.ASVAL.Finance.Funds/"]
RUN dotnet restore "src/CloudLabs.ASVAL.Finance.Funds/CloudLabs.ASVAL.Finance.Funds.csproj"
COPY . .
WORKDIR "/src/CloudLabs.ASVAL.Finance.Funds"
RUN dotnet build "CloudLabs.ASVAL.Finance.Funds.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudLabs.ASVAL.Finance.Funds.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudLabs.ASVAL.Finance.Funds.dll"]
