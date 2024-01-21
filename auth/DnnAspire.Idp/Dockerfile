FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
COPY . ./src
WORKDIR /src

RUN dotnet build -c $BUILD_CONFIGURATION -o /app
RUN dotnet publish -c $BUILD_CONFIGURATION -o /publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
COPY --from=build /publish /app

WORKDIR /app
EXPOSE 7001

#CMD ["./DnnAspire.Idp"]

ENTRYPOINT ["dotnet", "DnnAspire.Idp.dll"]