#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Services/Farming/Farming.Api/Farming.Api.csproj", "src/Services/Farming/Farming.Api/"]
COPY ["src/Services/Farming/Farming.Persistense.Database/Farming.Persistense.Database.csproj", "src/Services/Farming/Farming.Persistense.Database/"]
COPY ["src/Services/Farming/Farming.Service/Farming.Service.csproj", "src/Services/Farming/Farming.Service/"]
COPY ["src/Services/Farming/Farming.Domain/Farming.Domain.csproj", "src/Services/Farming/Farming.Domain/"]
COPY ["src/Common/Common/Common.Utilities.csproj", "src/Common/Common/"]
COPY ["src/Services/Farming/Farming.DTOs/Farming.DTOs.csproj", "src/Services/Farming/Farming.DTOs/"]
RUN dotnet restore "src/Services/Farming/Farming.Api/Farming.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Farming/Farming.Api"
RUN dotnet build "Farming.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Farming.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Farming.Api.dll"]