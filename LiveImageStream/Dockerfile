# STEP 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY LiveImageStream/LiveImageStream.csproj ./LiveImageStream/
RUN dotnet restore ./LiveImageStream/LiveImageStream.csproj

COPY . ./
WORKDIR /app/LiveImageStream
RUN dotnet publish -c Release -o /app/out

# STEP 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "LiveImageStream.dll"]
