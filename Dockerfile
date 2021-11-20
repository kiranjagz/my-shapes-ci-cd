#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV AppSettings__Secret="0987!@#%%"
ENV AppSettings__Value1="values are vcool"
ENV AppSettings__Name="KDawg"

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ./src .
#COPY ["Shapes.Api/Shapes.Api.csproj", "Shapes.Api/"]
#COPY ["nuget.config", ""]

ARG PAT
RUN wget -qO- https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh | bash
ENV NUGET_CREDENTIALPROVIDER_SESSIONTOKENCACHE_ENABLED true
ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS "{\"endpointCredentials\": [{\"endpoint\":\"https://pkgs.dev.azure.com/kiranjagz/Bobbi-Force/_packaging/bobbi-force/nuget/v3/index.json\", \"password\":\"${PAT}\"}]}"

RUN dotnet restore -s "https://pkgs.dev.azure.com/kiranjagz/Bobbi-Force/_packaging/bobbi-force/nuget/v3/index.json" -s "https://api.nuget.org/v3/index.json" "Shapes.Api/Shapes.Api.csproj"
RUN dotnet test "Shapes.Test/Shapes.Test.csproj"

COPY . .
WORKDIR "/src/Shapes.Api"
RUN dotnet build "Shapes.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shapes.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shapes.Api.dll"]