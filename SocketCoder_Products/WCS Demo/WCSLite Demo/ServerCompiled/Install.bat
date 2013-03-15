@ECHO OFF

REM The following directory is for .NET 2.0
set DOTNETFX2=%SystemRoot%\Microsoft.NET\Framework\v2.0.50727
set PATH=%PATH%;%DOTNETFX2%

echo Installing SocketCoder WCS Main Service...
echo ---------------------------------------------------
Copy SocketClientAccessPolicy.xml %windir%\system32
InstallUtil /i SocketCoder_WCService.MainService.exe
NET Start SocketCoder_WCService
echo ---------------------------------------------------
echo Done.