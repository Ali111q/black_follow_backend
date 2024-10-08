# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Install PostgreSQL 16
RUN apt-get update && apt-get install -y wget gnupg2 lsb-release
RUN sh -c 'echo "deb http://apt.postgresql.org/pub/repos/apt/ `lsb_release -cs`-pgdg main" > /etc/apt/sources.list.d/pgdg.list'
RUN wget --quiet -O - https://www.postgresql.org/media/keys/ACCC4CF8.asc | apt-key add -
RUN apt-get update && apt-get install -y postgresql-16 postgresql-client-16

# Configure PostgreSQL
USER postgres
RUN /etc/init.d/postgresql start && \
    psql --command "ALTER USER postgres WITH PASSWORD '10109989';" && \
    psql --command "CREATE DATABASE blackfollow;"

# Expose PostgreSQL port
EXPOSE 5432

# Switch back to the application user
USER root

# Copy the .NET application
WORKDIR /app
COPY --from=build /app/out .

# Set environment variables
ENV ASPNETCORE_URLS=http://*:80
ENV DefaultConnection="Server=localhost;Port=5432;Database=blackfollow;User Id=postgres;Password=10109989;trust server certificate=true"

# Start the application
CMD service postgresql start && dotnet Moi.dll
