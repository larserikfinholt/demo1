FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000


FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["service0.csproj", "./"]
RUN dotnet restore "./service0.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "service0.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "service0.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "service0.dll"]
