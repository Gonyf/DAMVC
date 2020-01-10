@echo off
set /p migrationName="Enter migration name: "
cd ..
dotnet ef migrations add %migrationName%
dotnet ef database update