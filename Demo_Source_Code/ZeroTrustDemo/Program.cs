﻿using System;
using EaseFilter.FilterControl;

namespace FileProtectorConsole
{
    class Program
    {
        static FilterControl filterControl = new FilterControl();

        static void PrintUsage()
        {
            Console.WriteLine("Usage: ZeroTrustDemo folderNameMask processName e");
            Console.WriteLine("options:");
            Console.WriteLine("folderNameMask       --setup the zero trust folder, i.e. c:\\zerotrust\\*");
            Console.WriteLine("processName          --authorized the process name to access the files, i.e. notepad.exe");
            Console.WriteLine("e  or null           --if it is e, it will enable the encryption for zero trust folder.");
        }

        static void Main(string[] args)
        {
            string lastError = string.Empty;          

            FilterAPI.FilterType filterType = FilterAPI.FilterType.CONTROL_FILTER | FilterAPI.FilterType.PROCESS_FILTER | FilterAPI.FilterType.ENCRYPTION_FILTER;

            int serviceThreads = 5;
            int connectionTimeOut = 10; //seconds

            try
            {
                //setup the zero trust folder, no one can access the files in this folder by default.
                string zeroTrustFolder = "c:\\ZeroTrust\\*";
                //setup the authorized process to access the files in zero trust folder.
                string authorizedProcess = "notepad.exe";
                //enable the encryption for the zero trust folder, if it is true, all files will be encrypted in the folder.
                bool enableEncryption = false;

                if (args.Length < 2)
                {
                    PrintUsage();
                    return;
                }

                zeroTrustFolder = args[0];
                authorizedProcess = args[1];

                if (args.Length > 2)
                {
                    if (args[2].Equals("e"))
                    {
                        enableEncryption = true;
                    }
                }

                //Purchase a license key with the link: http://www.easefilter.com/Order.htm
                //Email us to request a trial key: info@easefilter.com //free email is not accepted.
                string licenseKey = "******************************";

                if (!filterControl.StartFilter(filterType, serviceThreads, connectionTimeOut, licenseKey, ref lastError))
                {
                    Console.WriteLine("\r\nStart Filter Service failed with error:" + lastError);
                    return;
                }                

                //create the zero trust filter rule, every filter rule must have the unique watch path. 
                FileFilter zeroTrustFilter = new FileFilter(zeroTrustFolder);
                //setup the zero trust access flag of the filter rule
                zeroTrustFilter.AccessFlags = FilterAPI.AccessFlag.LEAST_ACCESS_FLAG;              

                if (enableEncryption)
                {
                    zeroTrustFilter.AccessFlags = (FilterAPI.AccessFlag)FilterAPI.ALLOW_MAX_RIGHT_ACCESS;
                    //enable encryption for this filter rule.
                    zeroTrustFilter.EnableEncryption = true;
                    //no one can read the encrypted file data by default.
                    zeroTrustFilter.EnableReadEncryptedFileData = false;
                    //set up a 32bytes test encryption key for the filter rule.
                    byte[] key = { 0x60, 0x3d, 0xeb, 0x10, 0x15, 0xca, 0x71, 0xbe, 0x2b, 0x73, 0xae, 0xf0, 0x85, 0x7d, 0x77, 0x81, 0x1f, 0x35, 0x2c
                        , 0x07, 0x3b, 0x61, 0x08, 0xd7, 0x2d, 0x98, 0x10, 0xa3, 0x09, 0x14, 0xdf, 0xf4 };

                    zeroTrustFilter.EncryptionKey = key;
                }

                //authorize process notepad.exe with the full access right
                zeroTrustFilter.ProcessNameAccessRightList.Add(authorizedProcess, FilterAPI.ALLOW_MAX_RIGHT_ACCESS);

                //you can authorize the processes which were signed with your digital certicate with full access right.
                //zeroTrustFilter.SignedProcessAccessRightList.Add("Certificate name", FilterAPI.ALLOW_MAX_RIGHT_ACCESS);

                //you also can authorize the process which has the same sha256 hash with full access right.
                //byte[] processSha256Hash = new byte[32];
                //uint hashBytesLength = 0;
                //bool ret = FilterAPI.Sha256HashFile("your process name file path", processSha256Hash, ref hashBytesLength);
                //zeroTrustFilter.Sha256ProcessAccessRightList.Add(processSha256Hash, FilterAPI.ALLOW_MAX_RIGHT_ACCESS);

                //authorize the user with the full access right.
                //zeroTrustFilter.userAccessRightList.Add("domainname or computer\\username", FilterAPI.ALLOW_MAX_RIGHT_ACCESS);

                filterControl.AddFilter(zeroTrustFilter);

                if (!filterControl.SendConfigSettingsToFilter(ref lastError))
                {
                    Console.WriteLine("SendConfigSettingsToFilter failed." + lastError);
                    return;
                }

                Console.WriteLine("Start Zero trust demo succeeded, zero trust folder:" + zeroTrustFolder 
                    + ",authorized process:" + authorizedProcess + ",eanbleEncryption:" + enableEncryption.ToString() + "\r\n");

                // Wait for the user to quit the program.
                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;

                filterControl.StopFilter();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Start filter service failed with error:" + ex.Message);
            }

        }
       
    }
}
