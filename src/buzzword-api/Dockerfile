FROM microsoft/dotnet:1.0.0-core
WORKDIR /app
ENV ASPNETCORE_URLS http://*:5001
EXPOSE 5001
ENTRYPOINT ["dotnet", "buzzword-api.dll"]
COPY . /app
