FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /src

ENTRYPOINT [ "bash", "-lc", "dotnet restore ErintekTestTask.sln && dotnet test ErintekTestTask.sln -c Release --nologo --logger \"trx;LogFileName=TestResults.trx\" --results-directory /src/TestResults" ]
