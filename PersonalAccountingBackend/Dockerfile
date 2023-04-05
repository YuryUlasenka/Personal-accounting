#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PersonalAccountingBackend/PersonalAccountingBackend.csproj", "PersonalAccountingBackend/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["Repository/Repository.csproj", "Repository/"]
RUN dotnet restore "PersonalAccountingBackend/PersonalAccountingBackend.csproj"
COPY . .
WORKDIR "/src/PersonalAccountingBackend"
RUN dotnet build "PersonalAccountingBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonalAccountingBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonalAccountingBackend.dll"]