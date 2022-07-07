#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OrderManagment.API/OrderManagment.API.csproj", "OrderManagment.API/"]
RUN dotnet restore "OrderManagment.API/OrderManagment.API.csproj"
COPY . .
WORKDIR "/src/OrderManagment.API"
RUN dotnet build "OrderManagment.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderManagment.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderManagment.API.dll"]