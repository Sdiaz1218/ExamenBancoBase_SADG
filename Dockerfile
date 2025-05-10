FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR ExamenBancoBase

EXPOSE 80
EXPOSE 5024

COPY ./*.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /ExamenBancoBase
COPY --from=build /ExamenBancoBase/out .
ENTRYPOINT ["dotnet","ExamenBancoBase.dll"]