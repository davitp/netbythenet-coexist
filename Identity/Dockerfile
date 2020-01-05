FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine as base
WORKDIR /identity
EXPOSE 33000


FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine as builder

COPY . /identity
WORKDIR /identity
RUN ["dotnet", "restore"]


RUN dotnet build -c Debug -o /result

FROM builder AS publish
RUN dotnet publish -c Debug -o /result


FROM base AS final
COPY ["appsettings.json", "/usr/share"]
WORKDIR /app
COPY --from=publish /result .

ENTRYPOINT ["dotnet", "Identity.dll"]
