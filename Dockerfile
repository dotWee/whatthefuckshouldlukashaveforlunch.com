# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY WhatTheFuckShouldLukasHaveForLunch.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY . .

# publish
RUN dotnet publish -c Release -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "WhatTheFuckShouldLukasHaveForLunch.dll" ]