using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.DirectoryServices.AccountManagement ;
using System.Runtime.InteropServices;

namespace SISFALLA
{
   public class WinAPI{
// Use NTLM security provider to check 
public const int LOGON32_PROVIDER_DEFAULT = 0x0;
// To validate the account
public const int LOGON32_LOGON_NETWORK = 0x3;

// API declaration for validating user credentials
[DllImport("advapi32.dll", SetLastError = true)] public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out int phToken);
//API to close the credential token
[DllImport("kernel32", EntryPoint="CloseHandle")] public static extern long CloseHandle (long hObject);
};



}
