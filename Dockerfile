# 1 - Define base image
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env

# 2 - Change working directory
WORKDIR /app

# 3 - Copy csproj to current working directory
COPY ./ChessBackend/ChessBackend/*.csproj ./

# 4 - Restore distinct layers
RUN dotnet restore

# 5 - Copy everything else to current working directory
COPY ./ChessBackend/ChessBackend/ ./

# 6 - Build project
RUN dotnet publish -c Release -o out

# 7 - Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

# 8 - Change working directory
WORKDIR /app

# 9 - Copy build project to current working directory
COPY --from=build-env /app/out .

# 10 - Set entrypoint commands
ENTRYPOINT ["dotnet", "ChessBackend.dll"]
