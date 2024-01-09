FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
ENV TZ=Asia/Shanghai
EXPOSE 80
COPY . .
ENTRYPOINT ["dotnet", "MemoryOverflowGenerator.dll"]