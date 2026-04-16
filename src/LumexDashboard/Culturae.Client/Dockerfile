# Build stage: .NET SDK + Node.js for Tailwind CSS compilation
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release

# Install Node.js for Tailwind CSS build
RUN apt-get update && apt-get install -y curl \
    && curl -fsSL https://deb.nodesource.com/setup_22.x | bash - \
    && apt-get install -y nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["Culturae.Client/Culturae.Client.csproj", "Culturae.Client/"]
COPY ["Culturae.UI.Shared/Culturae.UI.Shared.csproj", "Culturae.UI.Shared/"]
COPY ["package.json", "./"]
RUN dotnet restore "Culturae.Client/Culturae.Client.csproj"
RUN npm install

COPY . .

# LumexUI's NuGet package copies theme files to bin/lumexui/ via a CopyContents
# target (BeforeTargets="Build"). The Tailwind CSS target also runs BeforeTargets="Build".
# If Tailwind runs first and fails (due to the cross-project import path), CopyContents
# never executes and bin/lumexui/ is never created. Fix: manually copy theme files from
# the NuGet cache before building, and mirror them to the cross-project path app.css expects.
WORKDIR "/src/Culturae.Client"
RUN LUMEX_THEME=$(find /root/.nuget -path "*/lumexui/*/theme" -type d 2>/dev/null | head -1) \
    && mkdir -p bin/lumexui /src/LumexDashboard.Client/bin/lumexui \
    && cp -r "$LUMEX_THEME"/* bin/lumexui/ \
    && cp -r "$LUMEX_THEME"/* /src/LumexDashboard.Client/bin/lumexui/

RUN dotnet publish "./Culturae.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Runtime stage: nginx to serve static WASM files
FROM nginx:alpine AS final
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
COPY Culturae.Client/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
