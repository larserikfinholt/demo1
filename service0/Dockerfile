#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["service0/service0.csproj", "service0/"]
RUN dotnet restore "service0/service0.csproj"
COPY . .
WORKDIR "/src/service0"
RUN dotnet build "service0.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "service0.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "service0.dll"]