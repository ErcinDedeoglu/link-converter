FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TY.LinkConverter.WebAPI/TY.LinkConverter.WebAPI.csproj", "TY.LinkConverter.WebAPI/"]
RUN dotnet restore "TY.LinkConverter.WebAPI/TY.LinkConverter.WebAPI.csproj"
COPY . .
WORKDIR "/src/TY.LinkConverter.WebAPI"
RUN dotnet build "TY.LinkConverter.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TY.LinkConverter.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "TY.LinkConverter.WebAPI.dll"]
# Use the following instead for Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet TY.LinkConverter.WebAPI.dll