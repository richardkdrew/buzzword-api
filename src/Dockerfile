# DOCKER VERSION 1.12.0
FROM microsoft/dotnet:1.0.0-core

MAINTAINER Richard Drew <richardkdrew@gmail.com>

# set the start/working directory
WORKDIR /app

# copy the files into place
COPY . /app

# set up some basic (runtime) environment variable defaults for the app
ENV ASPNETCORE_URLS "http://*80;https://*:443"
ENV ASPNETCORE_ENVIRONMENT "Production"

# expose the hosting port
EXPOSE 443/tcp
EXPOSE 80/tcp

# set the run command
ENTRYPOINT ["dotnet", "src.dll"]