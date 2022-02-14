FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CloudLabs.ASVAL.Finance.Cart/CloudLabs.ASVAL.Finance.Cart.csproj", "CloudLabs.ASVAL.Finance.Cart/"]
RUN dotnet restore "src/CloudLabs.ASVAL.Finance.Cart/CloudLabs.ASVAL.Finance.Cart.csproj"
COPY . .
WORKDIR "/src/CloudLabs.ASVAL.Finance.Cart"
RUN dotnet build "CloudLabs.ASVAL.Finance.Cart.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudLabs.ASVAL.Finance.Cart.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudLabs.ASVAL.Finance.Cart.dll"]
