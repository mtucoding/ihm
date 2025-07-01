# Step 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY LiveImageStream/LiveImageStream.csproj ./LiveImageStream/
RUN dotnet restore ./LiveImageStream/LiveImageStream.csproj

# Copy the full source code
COPY . ./
WORKDIR /app/LiveImageStream
RUN dotnet publish -c Release -o /app/out

# Step 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "LiveImageStream.dll"]
