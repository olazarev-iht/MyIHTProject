@echo off
echo "Publishing..."

Rem if folder "SourceCode" does not exist - exit
if exist SourceCode\ (
  echo Folder SourceCode exists...
) else (
  echo Error: SourceCode folder does not exist. Installation has bin terminated.
  pause
  exit
)

Rem if folder "ApcWebServer_Install_Package" does not exist - exit
if exist ApcWebServer_Install_Package\ (
  cd ApcWebServer_Install_Package
  echo Folder ApcWebServer_Install_Package exists...
  rd /s /q publish
  md publish
  echo Folder publish has been created...
) else (
  echo error: ApcWebServer_Install_Package folder does not exist. The installation has been terminated.
  pause
  exit
)

dotnet publish %0\..\SourceCode\IhtApcWebServer\IhtApcWebServer.csproj -c Release -r win-x64 --self-contained=true /p:PublishSingleFile=true --output %0\..\ApcWebServer_Install_Package\publish\

if exist publish\ (
  cd publish
)

dir

if exist IhtApcWebServer.exe (
  echo Success: The installation package has been created...
) else (
  echo Error: The installation package can not be created...
)

pause



