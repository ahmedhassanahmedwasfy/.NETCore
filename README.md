# MyDoctor_NETCore
#front (in ui folder)
docker build . -t="front"
docker run -d --name front -p 80:4200  front
#backend
docker build -f "docker file complete path" --force-rm -t targetnetcore:dev --target base  --label "com.microsoft.created-by=visual-studio" --label "com.microsoft.visual-studio.project-name=Target NETCORE" "docker file solution folder .SLN file folder"

docker run -dt  -p 80:53162 --name Target_NETCORE --entrypoint tail targetnetcore:dev
