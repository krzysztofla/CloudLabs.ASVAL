#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Gateways/CloudLabs.ASVAL.BFF/CloudLabs.ASVAL.BFF.csproj", "src/Gateways/CloudLabs.ASVAL.BFF/"]
RUN dotnet restore "src/Gateways/CloudLabs.ASVAL.BFF/CloudLabs.ASVAL.BFF.csproj"
COPY . .
WORKDIR "/src/src/Gateways/CloudLabs.ASVAL.BFF"
RUN dotnet build "CloudLabs.ASVAL.BFF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudLabs.ASVAL.BFF.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudLabs.ASVAL.BFF.dll"]