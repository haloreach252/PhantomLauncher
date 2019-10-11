set /P browser="What browser do you use (firefox or chrome): "
if %browser%==firefox (goto :firefox)
else ( if %browser%==chrome (goto :chrome) else (goto :unknown))


:firefox
REM "C:\Program Files\Mozilla Firefox\firefox.exe" -url "https://github.com/haloreach252/PhantomLauncher" "https://trello.com/b/ptbmYbrR/phantom-launcher" "https://fontawesome.com/cheatsheet/free/solid"
for /f "tokens=1,2* delims= " %%i in ('reg query "HKLM\Software\Clients\StartMenuInternet\FIREFOX.EXE\shell\open\command" /s ^| find "Default"') do (
  set choice=%%~dpk
)
goto :openBrowser

:chrome
for /f "tokens=1,2* delims= " %%i in ('reg query "HKLM\Software\Clients\StartMenuInternet\CHROME.EXE\shell\open\command" /s ^| find "Default"') do (
  set choice=%%~dpk
)
goto :openBrowser

:unknown
echo "Unknown browser, please retry"
pause
goto :eof

:openBrowser
set s=%choice%%browser%.exe
start "s" "https://github.com/haloreach252/PhantomLauncher"
start "s" "https://trello.com/b/ptbmYbrR/phantom-launcher"
start "s" "https://fontawesome.com/cheatsheet/free/solid"