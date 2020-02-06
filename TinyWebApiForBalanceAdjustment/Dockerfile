FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Z2H_Demo_WebApiForBalanceAdjustment/Z2H_Demo_WebApiForBalanceAdjustment.csproj", "Z2H_Demo_WebApiForBalanceAdjustment/"]
RUN dotnet restore "Z2H_Demo_WebApiForBalanceAdjustment/Z2H_Demo_WebApiForBalanceAdjustment.csproj"
COPY . .
WORKDIR "/src/TinyWebApiForBalanceAdjustment"
RUN dotnet build "Z2H_Demo_WebApiForBalanceAdjustment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Z2H_Demo_WebApiForBalanceAdjustment.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Z2H_Demo_WebApiForBalanceAdjustment.dll"]