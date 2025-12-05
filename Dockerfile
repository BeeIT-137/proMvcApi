# ----- STAGE 1: BUILD -----
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copy csproj và restore
COPY *.csproj ./
RUN dotnet restore

# copy toàn bộ source
COPY . .

# publish ra thư mục /app/publish
RUN dotnet publish -c Release -o /app/publish

# ----- STAGE 2: RUNTIME -----
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

# app nghe ở port 8080 trong container
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# ĐÚNG TÊN DLL của bạn ở đây
CMD ["dotnet", "proMvcApi.dll"]
