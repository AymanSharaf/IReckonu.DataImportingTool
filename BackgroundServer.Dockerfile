# Stage 1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish "./IReckonu.DataImportingTool.Data/IReckonu.DataImportingTool.Data.csproj" -c Release -o /app 
RUN dotnet publish  "./IReckonu.DataImportingTool.Data.Caching/IReckonu.DataImportingTool.Data.Caching.csproj" -c Release -o /app 
RUN dotnet publish  "./IReckonu.DataImportingTool.Data.SqlServer/IReckonu.DataImportingTool.Data.SqlServer.csproj" -c Release -o /app 
RUN dotnet publish  "./IReckonu.DataImportingTool.Application/IReckonu.DataImportingTool.Application.csproj" -c Release -o /app 
RUN dotnet publish  "./IReckonu.DataImportingTool.BackgroundJobs.Hangfire/IReckonu.DataImportingTool.BackgroundJobs.Hangfire.csproj" -c Release -o /app 
RUN dotnet publish "./IReckonu.DataImportingTool.ProcessingApplication/IReckonu.DataImportingTool.ProcessingApplication.csproj" -c Release -o /app  

# Stage 2
FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "IReckonu.DataImportingTool.ProcessingApplication.dll"]