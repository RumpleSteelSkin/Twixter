@echo off 
:: Terminate previous instances
taskkill /IM "dotnet.exe" /F >nul 2>&1
taskkill /IM "node.exe" /F >nul 2>&1

:: Display menu
:menu
cd /d "%~dp0"
cls
echo ==================================
echo    TwixterR Project Launcher
echo ==================================
echo [1] Start API and React
echo [2] Start API only
echo [3] Start React only
echo [4] Install required React modules
echo [5] Exit
echo ==================================
set /p choice=Enter your choice (1-5): 

if "%choice%"=="1" goto start_both
if "%choice%"=="2" goto start_api
if "%choice%"=="3" goto start_react
if "%choice%"=="4" goto install_modules
if "%choice%"=="5" goto exit_script

:: Invalid input, return to menu
echo Invalid choice! Please enter a number between 1 and 5.
pause
goto menu

:start_both
:: Start Web API
start cmd /k "cd /d src\project\TwixterR.Presentation && dotnet run"

:: Wait for API to initialize
timeout /t 5 /nobreak >nul

:: Start React app (ensure correct path)
start cmd /k "cd /d TwixterR FrontEnd\twixterr && npm run dev"

:: Open browser with API and React
timeout /t 3 /nobreak >nul
start "" "http://localhost:5183/swagger"
start "" "http://localhost:5173"
goto menu

:start_api
:: Start Web API
start cmd /k "cd /d src\project\TwixterR.Presentation && dotnet run"

:: Open API in browser
timeout /t 3 /nobreak >nul
start "" "http://localhost:5183/swagger"
goto menu

:start_react
:: Start React app (ensure correct path)
start cmd /k "cd /d TwixterR FrontEnd\twixterr && npm run dev"

:: Open React in browser
timeout /t 3 /nobreak >nul
start "" "http://localhost:5173"
goto menu

:install_modules
:: Install required React modules (ensure correct path)
echo Installing required React modules...
cd /d TwixterR FrontEnd\twixterr
start cmd /k "npm install"
start cmd /k "npm install lucide-react"
start cmd /k "npm update lucide-react"



pause
goto menu

:: Inform the user that modules are installed
echo Modules installed successfully. You can now start the React app.
pause
goto menu

:exit_script
echo Exiting...
timeout /t 2 /nobreak >nul
exit
