cd .\Data\System
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc /main:Server.Tests.TestHarness /define:DEBUG /optimize /unsafe /t:exe /out:Test.exe /win32icon:Source\icon.ico /d:NEWTIMERS /d:NEWPARENT /recurse:*.cs
.\Test.exe