@echo off
rem Builds Countdown.exe with the C# compiler that ships with Windows - nothing to install.
"%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /nologo /target:winexe /optimize /out:"%~dp0Countdown.exe" /r:System.Windows.Forms.dll /r:System.Drawing.dll "%~dp0Countdown.cs"
