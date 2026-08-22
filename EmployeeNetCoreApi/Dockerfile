# Multi-stage Dockerfile for building and running the EmployeeNetCoreApi (.NET 8)
#
# Swagger UI (external): http://localhost:8080/swagger
# Swagger JSON: http://localhost:8080/swagger/v1/swagger.json
#
# NOTE: When building from solution root, use:
#   docker build -t employeenetcoreapi:latest -f EmployeeNetCoreApi/Dockerfile .

# Note: image metadata for documentation (set as a label in the runtime stage below)

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies (leverages Docker layer caching)
COPY ["EmployeeNetCoreApi/EmployeeNetCoreApi.csproj", "EmployeeNetCoreApi/"]
RUN dotnet restore "EmployeeNetCoreApi/EmployeeNetCoreApi.csproj"

# Copy the rest of the sources and publish
COPY . .
WORKDIR /src/EmployeeNetCoreApi
RUN dotnet publish "EmployeeNetCoreApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Set an environment variable and image label so the Swagger URL is discoverable
ENV SWAGGER_URL="http://localhost:8080/swagger"
LABEL org.opencontainers.image.documentation="${SWAGGER_URL}"

EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "EmployeeNetCoreApi.dll"]
