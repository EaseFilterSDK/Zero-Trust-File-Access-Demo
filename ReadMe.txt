How to run ZeroTrustDemo.exe?

Usage: 	ZeroTrustDemo folderNameMask processName e;
options:
folderNameMask       --setup the zero trust folder, i.e. c:\\zerotrust\\*";
processName          --authorized the process name to access the files, i.e. notepad.exe;
e  or null           --if it is e, it will enable the encryption for zero trust folder.;

Example1:
ZeroTrustDemo c:\zerotrust\*  notepade.exe  e
All files in folder c:\zerotrust will be encrypted by default, no process can't read the encrypted files except the process "notepad.exe"

Example2:
ZeroTrustDemo c:\zerotrust\*  notepade.exe 
No process can access the files in folder c:\zerotrust except the process "notepad.exe"

