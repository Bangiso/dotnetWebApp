docker build -t dotnet-web-app -f Dockerfile .
docker run -d --rm -p 5000:80 --name webapp dotnet-web-app
