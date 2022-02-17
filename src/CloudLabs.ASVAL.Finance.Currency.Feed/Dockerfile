FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CloudLabs.ASVAL.Finance.Currency/CloudLabs.ASVAL.Finance.Currency.csproj", "CloudLabs.ASVAL.Finance.Currency/"]
RUN dotnet restore "CloudLabs.ASVAL.Finance.Currency/CloudLabs.ASVAL.Finance.Currency.csproj"
COPY . .
WORKDIR "/src/CloudLabs.ASVAL.Finance.Currency"
RUN dotnet build "CloudLabs.ASVAL.Finance.Currency.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudLabs.ASVAL.Finance.Currency.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudLabs.ASVAL.Finance.Currency.dll"]
