FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
# EXPOSE 5001

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY R3NextGenBackend.csproj ./R3NextGenBackend/
# Restore the packages for our solution
RUN dotnet restore "R3NextGenBackend/R3NextGenBackend.csproj"
WORKDIR "/src/R3NextGenBackend"
COPY . .
RUN dotnet build "R3NextGenBackend.csproj" -c Release -o /app

FROM build AS publish
# Publish the application to the app folder
RUN dotnet publish "R3NextGenBackend.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
# Configure the container to run as an executable that will start the application
ENTRYPOINT ["dotnet", "R3NextGenBackend.dll"]