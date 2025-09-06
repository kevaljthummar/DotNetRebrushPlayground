# Use .NET Framework 4.7.2 runtime image
FROM mcr.microsoft.com/dotnet/framework/runtime:4.7.2 AS base
WORKDIR /app

# Use SDK image to build
FROM mcr.microsoft.com/dotnet/framework/sdk:4.7.2 AS build
WORKDIR /src

# Copy project files and restore
COPY OOP_Concepts/OOP_Concepts.csproj ./OOP_Concepts/
RUN nuget restore OOP_Concepts/OOP_Concepts.csproj

# Copy everything else and build
COPY . .
WORKDIR /src/OOP_Concepts
RUN msbuild OOP_Concepts.csproj /p:Configuration=Release /p:OutputPath=c:\out

# Final stage: runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["OOP_Concepts.exe"]
