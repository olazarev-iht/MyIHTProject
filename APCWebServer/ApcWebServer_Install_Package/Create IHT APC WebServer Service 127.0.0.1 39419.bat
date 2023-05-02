@echo off

sc.exe stop "IHT APC WebServer Service"

sc.exe delete "IHT APC WebServer Service"

echo The IHT APC WebServer Service installing...

set user_mashine_path=C:\IHT_APC_Service

set user_mashine_publish_folder=%user_mashine_path%\publish

if exist %user_mashine_path%\ (
  echo %user_mashine_path% exists
) else ( 
    echo %user_mashine_path% not exists
  rd /s /q %user_mashine_path%
  md %user_mashine_path%
  echo %user_mashine_path% has been created
)

  echo "Removing existing publish..."
  IF EXIST %user_mashine_publish_folder%\ (
    rmdir %user_mashine_publish_folder% /s /q
  )

  :: that xcopy command should work without rmdir %user_mashine_path%\publish
  xcopy /y /s /e /i /v /h /k %0\..\publish %user_mashine_publish_folder%\

  Rem - robocopy C:\Folder1 C:\Folder2 /COPYALL /E /IS /IT https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/robocopy

sc.exe create "IHT APC WebServer Service" binPath= "%user_mashine_publish_folder%\IhtApcWebServer.exe --tcpaddr 127.0.0.1 --tcpport 39419 --client default"

sc.exe start "IHT APC WebServer Service"
pause
