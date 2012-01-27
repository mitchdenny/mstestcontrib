@echo off
call "%VS100COMNTOOLS%vsvars32.bat"
mkdir .\build\log\

msbuild.exe /ToolsVersion:4.0 "MSTestContrib.UITesting.proj" 

pause