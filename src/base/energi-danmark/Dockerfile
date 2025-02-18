FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS publish
WORKDIR /src
COPY energi-danmark.csproj ./

RUN dotnet restore "./energi-danmark.csproj" --runtime linux-musl-x64
COPY . .
RUN dotnet publish "energi-danmark.csproj" -c Release -o /app/publish \
    --runtime linux-musl-x64 

FROM mcr.microsoft.com/dotnet/runtime-deps:9.0-alpine AS final

RUN adduser --disabled-password \
    --home /app \
    --gecos '' dotnetuser && chown -R dotnetuser /app

USER dotnetuser
WORKDIR /app
EXPOSE 5000
COPY --from=publish /app/publish .

ENTRYPOINT ["./energi-danmark", "--urls", "http://localhost:5000"]