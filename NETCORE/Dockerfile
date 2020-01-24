FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["NETCORE/Target NETCORE.csproj", "NETCORE/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["BL/BL.csproj", "BL/"]
COPY ["DAL/DAL.csproj", "DAL/"]
COPY ["Frameworks/Repository.Pattern/Repository.csproj", "Frameworks/Repository.Pattern/"]
RUN dotnet restore "NETCORE/Target NETCORE.csproj"
COPY . .
WORKDIR "/src/NETCORE"
RUN dotnet build "Target NETCORE.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Target NETCORE.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Target_NETCORE.dll"]