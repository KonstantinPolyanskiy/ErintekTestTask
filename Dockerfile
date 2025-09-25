FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /work
ENTRYPOINT ["bash","-lc","cp -a /host/. /work && dotnet restore ErintekTestTask.sln && dotnet test ErintekTestTask.sln -c Release --nologo --logger \"trx;LogFileName=TestResults.trx\" --results-directory /work/_out && cp -a /work/_out /host/TestResults"]
