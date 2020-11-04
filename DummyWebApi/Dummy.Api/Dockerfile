#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app

ENV EnableTrace="True"
ENV DBConnection="mongodb+srv://your-connection-string"
ENV DatabaseName="sample_dummies"

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Dummy.Api/Dummy.Api.csproj", "Dummy.Api/"]
RUN dotnet restore "Dummy.Api/Dummy.Api.csproj"
COPY . .
WORKDIR "/src/Dummy.Api"
RUN dotnet build "Dummy.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dummy.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dummy.Api.dll"]