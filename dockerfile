# Use the .NET 8 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


RUN apt-get update && apt-get install -y curl


COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# Use the .NET 8 Runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Install curl in the runtime stage
RUN apt-get update && apt-get install -y curl

# Copy the build output from the build image
COPY --from=build /app/out ./

# Define the entry point for the application
ENTRYPOINT ["dotnet", "SampleBackend.dll"]
