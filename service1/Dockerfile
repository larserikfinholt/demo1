FROM mcr.microsoft.com/dotnet/core/runtime:3.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["service1.csproj", "./"]
RUN dotnet restore "./service1.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "service1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "service1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "service1.dll"]
