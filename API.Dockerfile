# Stage 1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app "./IReckonu.DataImportingTool.Data/IReckonu.DataImportingTool.Data.csproj"
RUN dotnet publish -c Release -o /app "./IReckonu.DataImportingTool.Data.SqlServer/IReckonu.DataImportingTool.Data.SqlServer.csproj"
RUN dotnet publish -c Release -o /app "./IReckonu.DataImportingTool.Application/IReckonu.DataImportingTool.Application.csproj"
RUN dotnet publish -c Release -o /app "./IReckonu.DataImportingTool.BackgroundJobs.Hangfire/IReckonu.DataImportingTool.BackgroundJobs.Hangfire.csproj"
RUN dotnet publish -c Release -o /app

# Stage 2
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "IReckonu.DataImportingTool.API.dll"]