# https://hub.docker.com/_/microsoft-dotnet-sdk
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY WhatTheFuckShouldLukasHaveForLunch.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY . .

# publish
RUN dotnet publish -c Release -o out

# final stage/image
# https://hub.docker.com/_/microsoft-dotnet-aspnet
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "WhatTheFuckShouldLukasHaveForLunch.dll" ]