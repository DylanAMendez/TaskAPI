FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY ["TaskAPI.csproj", "./"]
RUN dotnet restore "TaskAPI.csproj"
COPY . .
RUN dotnet build "TaskAPI.csproj" -c Release -o /app/build
RUN dotnet publish "TaskAPI.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "TaskAPI.dll"]