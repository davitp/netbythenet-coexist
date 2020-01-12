FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine as base
WORKDIR /consumer
EXPOSE 80


FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine as builder

COPY . /consumer
WORKDIR /consumer
RUN ["dotnet", "restore"]


RUN dotnet build -c Debug -o /result

FROM builder AS publish
RUN dotnet publish -c Debug -o /result


FROM base AS final
COPY ["appsettings.json", "/usr/share"]
WORKDIR /app
COPY --from=publish /result .


ENTRYPOINT ["dotnet", "Consumer.dll"]
