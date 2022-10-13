FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

COPY./sims/sims.csproj.sims/sims.csproj
COPY *.sln./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o build --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from= build./ build.
ENV ASPNETCORE_URLS = https://*:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "sims.dll"]