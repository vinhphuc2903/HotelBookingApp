# ===== BUILD STAGE =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj và restore
COPY ["HotelBookingAPI.csproj", "./"]
RUN dotnet restore "HotelBookingAPI.csproj"

# Copy toàn bộ code và build
COPY . .
RUN dotnet publish "HotelBookingAPI.csproj" -c Release -o /app/publish

# ===== RUNTIME STAGE =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "HotelBookingAPI.dll"]
