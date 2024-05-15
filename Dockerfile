# Use the official .NET SDK image for build and publish
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY WebApiExample/WebApiExample.csproj WebApiExample/
RUN dotnet restore WebApiExample/WebApiExample.csproj

# copy project files for build
COPY . .
WORKDIR /src/WebApiExample
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

# publish
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish

# setup runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# add global tools to path
ENV PATH="$PATH:/root/.dotnet/tools"

# expost ports and establish entry
EXPOSE 8000
EXPOSE 8081
ENTRYPOINT ["dotnet", "WebApiExample.dll"]
