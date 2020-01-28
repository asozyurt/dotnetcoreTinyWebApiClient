FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["TinyWebApiForBalanceAdjustment/TinyWebApiForBalanceAdjustment.csproj", "TinyWebApiForBalanceAdjustment/"]
RUN dotnet restore "TinyWebApiForBalanceAdjustment/TinyWebApiForBalanceAdjustment.csproj"
COPY . .
WORKDIR "/src/TinyWebApiForBalanceAdjustment"
RUN dotnet build "TinyWebApiForBalanceAdjustment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TinyWebApiForBalanceAdjustment.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TinyWebApiForBalanceAdjustment.dll"]