docker stop  $(docker ps | grep -i dotnet-web-app | head -n 1  | awk '{print $1;}')
docker build -t dotnet-web-app -f Dockerfile .
docker run -d --rm -p 7146:80 --name webapp dotnet-web-app
docker commit  $(docker ps | grep -i dotnet-web-app | head -n 1 | awk '{print $1;}')  aphiwe2020/dotnet-web-app:$1
docker push aphiwe2020/dotnet-web-app:$1
