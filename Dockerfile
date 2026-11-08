FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["DevTrackAI/DevTrackAI.csproj", "DevTrackAI/"]
RUN dotnet restore "DevTrackAI/DevTrackAI.csproj"

COPY . .
WORKDIR /src/DevTrackAI
RUN dotnet publish "DevTrackAI.csproj" \
	--configuration Release \
	--output /app/publish \
	--no-restore \
	/p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=8080 \
	ConnectionStrings__DefaultConnection="Data Source=/data/DevTrack.db"

RUN mkdir -p /data && chown -R "$APP_UID:$APP_UID" /data
VOLUME ["/data"]
EXPOSE 8080

COPY --from=build /app/publish .
RUN chown -R "$APP_UID:$APP_UID" /app
USER $APP_UID

ENTRYPOINT ["dotnet", "DevTrackAI.dll"]
