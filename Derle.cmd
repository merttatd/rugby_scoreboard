@echo off
setlocal
set "COMPILER=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
if not exist "%COMPILER%" set "COMPILER=%WINDIR%\Microsoft.NET\Framework\v4.0.30319\csc.exe"
if not exist "%COMPILER%" (
  echo .NET Framework C# compiler not found.
  exit /b 1
)
"%COMPILER%" /nologo /target:winexe /optimize+ /platform:anycpu /out:"%~dp0RugbyScoreboard.exe" /reference:System.Windows.Forms.dll /resource:"%~dp0index.html",index.html /resource:"%~dp0style.css",style.css /resource:"%~dp0app.js",app.js "%~dp0desktop\Launcher.cs"
if errorlevel 1 exit /b 1
echo RugbyScoreboard.exe built successfully.
