# Zero Trust File Access Control Demo
## Why Zero Trust
Instead of assuming everything behind the corporate firewall is safe, the Zero Trust model assumes breach and verifies each request as though it originates from an open network. Regardless of where the request originates or what resource it accesses, Zero Trust teaches us to “never trust, always verify.” Every access request is fully authenticated, authorized, and encrypted before granting access. Zero trust adoption can offer organizations the following benefits:

1.  protection of sensitive data.
2.  securing digital transformation.
3.  lower breach risk and detection time.
4.	close security gaps and minimize risk of lateral movement.
5.  better control in cloud environments.

## Zero Trust Architecture
Instead of assuming everything behind the corporate firewall is safe, the Zero Trust model assumes breach and verifies each request as though it originates from an open network. Regardless of where the request originates or what resource it accesses, Zero Trust teaches us to “never trust, always verify.” Every access request is fully authenticated, authorized, and encrypted before granting access.
![Zero Trust Architecture](https://www.easefilter.com/images/ZeroTrust.png)
## Implement Zero trust file access control with EaseFilter
[EaseFilter File Control Filter Driver](https://www.easefilter.com/kb/file-control-file-security-sdk.htm) allows you to control the file I/O operations with the filter rule configuration by setting the whitelist and blacklist processes or users, you can allow or block the specific file I/O operation to the specific process or user, you can control who can read your file, allow or block the file modification, prevent your important file from being deleted, renamed.

To implement the Zero Trust file access control , you can setup the filter rule with the default least privilege access rights, by default all the processes or users don’t have privilege to access the files inside this filter rule, it is zero trust to all processes and users. You can setup the whitelist for the filter rule, to add the specific access rights to specific processes or users, so the processes or users who are in the whitelist can have the specific access rights to the files.

[EaseFilter Encryption Filter Driver(EEFD)](https://www.easefilter.com/kb/transparent-file-encryption-filter-driver-sdk.htm) allows you to encrypt file automatically and transparently, combine with the File Control Filter Driver and [Process Filter Driver](https://www.easefilter.com/kb/process-filter-driver-sdk.htm), you can implement the Zero Trust File Access Control with encryption enabled, it can enhance the file security. By default all files will be encrypted automatically, all processes or users can't read the encrypted files, they will get the raw encrypted data. You can authorize the processes or users to access these encrypted files. 

## How to run ZeroTrustDemo.exe?

Usage: 	ZeroTrustDemo folderNameMask processName e

options:

folderNameMask       --setup the zero trust folder, i.e. c:\\zerotrust\\*"

processName          --authorized the process name to access the files, i.e. notepad.exe

e or null           --if it is e, it will enable the encryption for zero trust folder.

Example1:

ZeroTrustDemo c:\zerotrust\*  notepade.exe  e

All files in folder c:\zerotrust will be encrypted by default, no process can't read the encrypted files except the process "notepad.exe"

Example2:

ZeroTrustDemo c:\zerotrust\*  notepade.exe 

No process can access the files in folder c:\zerotrust except the process "notepad.exe"

## EaseFilter File System Filter Driver SDK Reference
| Product Name | Description |
| --- | --- |
| [Cloud File System SDK](https://www.easefilter.com/cloud/cloud-file-system-sdk.htm) | EaseFilter Cloud File System SDK Introduction. |
| [CloudTier Storage Tiering SDK](https://www.easefilter.com/cloud/storage-tiering-sdk.htm) | EaseFilter Storage Tiering Filter Driver SDK Introduction. |
| [File Monitor SDK](https://www.easefilter.com/kb/file-monitor-filter-driver-sdk.htm) | EaseFilter File Monitor Filter Driver SDK Introduction. |
| [File Control SDK](https://www.easefilter.com/kb/file-control-file-security-sdk.htm) | EaseFilter File Control Filter Driver SDK Introduction. |
| [File Encryption SDK](https://www.easefilter.com/kb/transparent-file-encryption-filter-driver-sdk.htm) | EaseFilter Transparent File Encryption Filter Driver SDK Introduction. |
| [Registry Filter SDK](https://www.easefilter.com/kb/registry-filter-drive-sdk.htm) | EaseFilter Registry Filter Driver SDK Introduction. |
| [Process Filter SDK](https://www.easefilter.com/kb/process-filter-driver-sdk.htm) | EaseFilter Process Filter Driver SDK Introduction. |
| [EaseFilter SDK Programming](https://www.easefilter.com/kb/programming.htm) | EaseFilter Filter Driver SDK Programming. |

## EaseFilter SDK Sample Projects
| Sample Project | Description |
| --- | --- |
| [CloudTier Storage Tiering Demo](https://www.easefilter.com/cloud/cloudtier-storage-tiering-demo.htm) | A HSM File System Filter Driver Demo. |
| [CloudTier S3 Tiering Demo](https://www.easefilter.com/cloud/cloudtier-s3-intelligent-tiering-demo.htm) | CloudTier S3 Intelligent Tiering Demo. |
| [Cloud File DR S3 Demo](https://www.easefilter.com/cloud/cloud-file-dr-demo.htm) | Cloud File DR S3 Demo. |
| [Amazon S3 File Explorer Demo](https://www.easefilter.com/cloud/s3-browser-demo.htm) | Amazon S3 File Explorer Demo. |
| [Auto File DRM Encryption](https://www.easefilter.com/kb/auto-file-drm-encryption-tool.htm) | Auto file encryption with DRM data embedded. |
| [Transparent File Encrypt](https://www.easefilter.com/kb/AutoFileEncryption.htm) | Transparent on access file encryption. |
| [Secure File Sharing with DRM](https://www.easefilter.com/kb/DRM_Secure_File_Sharing.htm) | Secure encrypted file sharing with digital rights management. |
| [File Monitor Example](https://www.easefilter.com/kb/file-monitor-demo.htm) | Monitor file system I/O in real time, tracking file changes. |
| [File Protector Example](https://www.easefilter.com/kb/file-protector-demo.htm) | Prevent sensitive files from being accessed by unauthorized users or processes. |
| [FolderLocker Example](https://www.easefilter.com/kb/FolderLocker.htm) | Lock file automatically in a FolderLocker. |
| [Process Monitor](https://www.easefilter.com/kb/Process-Monitor.htm) | Monitor the process creation and termination, block unauthorized process running. |
| [Registry Monitor](https://www.easefilter.com/kb/RegMon.htm) | Monitor the Registry activities, block the modification of the Registry keys. |
| [Secure Sandbox Example](https://www.easefilter.com/kb/Secure-Sandbox.htm) |A secure sandbox example, block the processes accessing the files out of the box. |
| [FileSystemWatcher Example](https://www.easefilter.com/kb/FileSystemWatcher.htm) | File system watcher, logging the file I/O events. |
| [ZeroTrust Example](https://www.easefilter.com/kb/zero-trust-file-access-control-demo.htm) | Zero trust file access control with encryption feature. |

## Filter Driver Reference

* [Understand MiniFilter Driver](https://www.easefilter.com/kb/understand-minifilter.htm)
* [Understand File I/O](https://www.easefilter.com/kb/File_IO.htm)
* [Understand I/O Request Packets(IRPs)](https://www.easefilter.com/kb/understand-irps.htm)
* [Filter Driver Developer Guide](https://www.easefilter.com/kb/DeveloperGuide.htm)
* [MiniFilter Filter Driver Framework](https://www.easefilter.com/kb/minifilter-framework.htm)
* [Isolation Filter Driver](https://www.easefilter.com/kb/Isolation_Filter_Driver.htm)

## Support
If you have questions or need help, please contact support@easefilter.com 

[Home](https://www.easefilter.com/) | [Solution](https://www.easefilter.com/solutions.htm) | [Download](https://www.easefilter.com/download.htm) | [Demos](https://www.easefilter.com/online-fileio-test.aspx) | [Blog](https://blog.easefilter.com/) | [Programming](https://www.easefilter.com/kb/programming.htm)
