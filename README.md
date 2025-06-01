1- Inside MDDPlatform.Diagrams.Api run this command to publish the project
dotnet publish -c Release -o app/publish

2- In the folder that contains your Dockerfile run this command to build your image
docker build -t diagramservice .


3- Run this command to create a container in a user-defined network
docker run -d --network mddplatform -p 8080:8080 --name plantuml-service plantuml/plantuml-server:jetty

docker run -d --network mddplatform -p 5047:80 --name diagrams-service diagramservice
