#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Newsio.PL/Newsio.PL.csproj", "Newsio.PL/"]
RUN dotnet restore "Newsio.PL/Newsio.PL.csproj"
COPY . .
WORKDIR "/src/Newsio.PL"
RUN dotnet build "Newsio.PL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Newsio.PL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Newsio.PL.dll"]