# MyDoctor_NETCore
# front (in ui folder)
docker build . -t="front"

docker run -d --name front -p 4200:80 front

# backend
docker build -f "docker file full path contains docker file name" --force-rm -t targetnetcore  --label "com.microsoft.created-by=visual-studio" --label "com.microsoft.visual-studio.project-name=Target NETCORE" ".sln folder path"

ex:

docker build -f "g:\tmp\netcore-master\.netcore-master\netcore\dockerfile" --force-rm -t targetnetcore  --label "com.microsoft.created-by=visual-studio" --label "com.microsoft.visual-studio.project-name=Target NETCORE" "g:\tmp\netcore-master\.netcore-master"



docker run -dt -p 53162:80 --name Target_NETCORE  targetnetcore:latest
