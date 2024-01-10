FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV TZ=Asia/Shanghai
ENV COMPlus_DbgEnableMiniDump=1
ENV COMPlus_DbgMiniDumpType=4
ENV COMPlus_DbgMiniDumpName=/diag/%p-%e-%h-%t.dmp
EXPOSE 80
COPY . .
ENTRYPOINT ["dotnet", "MemoryOverflowGenerator.dll"]