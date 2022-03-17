#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/CloudLabs.ASVAL.Identity/CloudLabs.ASVAL.Identity.csproj", "src/Services/CloudLabs.ASVAL.Identity/"]
RUN dotnet restore "src/Services/CloudLabs.ASVAL.Identity/CloudLabs.ASVAL.Identity.csproj"
COPY . .
WORKDIR "/src/src/Services/CloudLabs.ASVAL.Identity"
RUN dotnet build "CloudLabs.ASVAL.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudLabs.ASVAL.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudLabs.ASVAL.Identity.dll"]