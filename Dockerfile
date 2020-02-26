#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["BasicCSharpRESTful.csproj", ""]
RUN dotnet restore "./BasicCSharpRESTful.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BasicCSharpRESTful.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasicCSharpRESTful.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasicCSharpRESTful.dll"]
