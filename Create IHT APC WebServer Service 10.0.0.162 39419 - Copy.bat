@echo off
sc.exe stop "IHT APC WebServer Service"
pause
sc.exe delete "IHT APC WebServer Service"
pause
sc.exe create "IHT APC WebServer Service" binPath= "c:\_IHT APC Web Server\publish\IhtApcWebServer.exe --tcpaddr 10.0.0.174 --tcpport 39419"
pause
sc.exe start "IHT APC WebServer Service"
pause
