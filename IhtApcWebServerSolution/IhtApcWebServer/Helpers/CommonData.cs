using MudBlazor;
using System.Diagnostics;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
//using System.Windows.Forms;

namespace IhtApcWebServer.Helpers
{
    /// <summary>
    /// freeware helper class for getting .NET assembly info
    /// (W) 2011 by admin of codezentrale.6x.to
    /// </summary>
    public static class AssemblyInfo
    {
        /// <summary>
        /// get assembly title
        /// </summary>
        public static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];

                    if (titleAttribute.Title != string.Empty) return titleAttribute.Title;
                }

                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
        /// <summary>
        /// get assembly version
        /// </summary>
        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        /// <summary>
        /// get assembly description
        /// </summary>
        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);

                if (attributes.Length == 0) return string.Empty;

                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
        /// <summary>
        /// get assembly product
        /// </summary>
        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);

                if (attributes.Length == 0) return string.Empty;

                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        /// <summary>
        /// get assembly copyright
        /// </summary>
        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);

                if (attributes.Length == 0) return string.Empty;

                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        /// <summary>
        /// get assembly company
        /// </summary>
        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);

                if (attributes.Length == 0) return string.Empty;

                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
    }


    /// <summary>
    /// Static class that adds convenient methods for getting information on the running computers basic hardware and os setup.
    /// </summary>
    public static class ComputerInfo
    {
        /// <summary>
        ///     Returns the Windows major version number for this computer.
        /// </summary>
        public static uint WinMajorVersion
        {
            get
            {
                dynamic major;
                // The 'CurrentMajorVersionNumber' string value in the CurrentVersion key is new for Windows 10, 
                // and will most likely (hopefully) be there for some time before MS decides to change this - again...
                if (TryGetRegistryKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentMajorVersionNumber", out major))
                {
                    return (uint)major;
                }

                // When the 'CurrentMajorVersionNumber' value is not present we fallback to reading the previous key used for this: 'CurrentVersion'
                dynamic version;
                if (!TryGetRegistryKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentVersion", out version))
                    return 0;

                var versionParts = ((string)version).Split('.');
                if (versionParts.Length != 2) return 0;
                uint majorAsUInt;
                return uint.TryParse(versionParts[0], out majorAsUInt) ? majorAsUInt : 0;
            }
        }

        /// <summary>
        ///     Returns the Windows minor version number for this computer.
        /// </summary>
        public static uint WinMinorVersion
        {
            get
            {
                dynamic minor;
                // The 'CurrentMinorVersionNumber' string value in the CurrentVersion key is new for Windows 10, 
                // and will most likely (hopefully) be there for some time before MS decides to change this - again...
                if (TryGetRegistryKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentMinorVersionNumber",
                    out minor))
                {
                    return (uint)minor;
                }

                // When the 'CurrentMinorVersionNumber' value is not present we fallback to reading the previous key used for this: 'CurrentVersion'
                dynamic version;
                if (!TryGetRegistryKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentVersion", out version))
                    return 0;

                var versionParts = ((string)version).Split('.');
                if (versionParts.Length != 2) return 0;
                uint minorAsUInt;
                return uint.TryParse(versionParts[1], out minorAsUInt) ? minorAsUInt : 0;
            }
        }

        /// <summary>
        ///     Returns whether or not the current computer is a server or not.
        /// </summary>
        public static uint IsServer
        {
            get
            {
                dynamic installationType;
                if (TryGetRegistryKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "InstallationType",
                    out installationType))
                {
                    return (uint)(installationType.Equals("Client") ? 0 : 1);
                }

                return 0;
            }
        }

        private static bool TryGetRegistryKey(string path, string key, out dynamic value)
        {
            value = null;
            try
            {
                var rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return false;
                value = rk.GetValue(key);
                return value != null;
            }
            catch
            {
                return false;
            }
        }
    }

#if false
  /// <summary>
  /// class SecurityDirectory
  /// </summary>
  public class SecurityDirectory
  {
    /// <summary>
    /// Adds an AccessControlList entry on the specified directory for the specified account.
    /// </summary>
    /// <param name="directoryPath"></param>
    /// <param name="identity"></param>
    /// <param name="fileSystemRights"></param>
    /// <param name="inheritanceFlags"></param>
    /// <param name="propogationFlags"></param>
    /// <param name="accessControlType"></param>
    public static void AddDirectorySecurity(string directoryPath, string identity, System.Security.AccessControl.FileSystemRights fileSystemRights, System.Security.AccessControl.InheritanceFlags inheritanceFlags, System.Security.AccessControl.PropagationFlags propogationFlags, System.Security.AccessControl.AccessControlType accessControlType)
    {
      // Create a new DirectoryInfo object. 
      System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(directoryPath);

      // Get a DirectorySecurity object that represents the current security settings. 
      System.Security.AccessControl.DirectorySecurity dirSecurity = dirInfo.GetAccessControl();

      // Add the FileSystemAccessRule to the security settings.  
      dirSecurity.AddAccessRule(new System.Security.AccessControl.FileSystemAccessRule(identity, fileSystemRights, inheritanceFlags, propogationFlags, accessControlType));

      // Set the new access settings. 
      dirInfo.SetAccessControl(dirSecurity);
    }
    /// <summary>
    /// Adds an AccessControlList entry on the specified directory for the specified account.
    /// </summary>
    /// <param name="directoryPath"></param>
    /// <param name="identity"></param>
    /// <param name="fileSystemRights"></param>
    /// <param name="accessControlType"></param>
    public static void AddDirectorySecurity(string directoryPath, string identity, System.Security.AccessControl.FileSystemRights fileSystemRights, System.Security.AccessControl.AccessControlType accessControlType)
    {
      // Create a new DirectoryInfo object. 
      System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(directoryPath);

      // Get a DirectorySecurity object that represents the current security settings. 
      System.Security.AccessControl.DirectorySecurity dirSecurity = dirInfo.GetAccessControl();

      // Add the FileSystemAccessRule to the security settings.  
      dirSecurity.AddAccessRule(new System.Security.AccessControl.FileSystemAccessRule(identity, fileSystemRights, accessControlType));

      // Set the new access settings. 
      dirInfo.SetAccessControl(dirSecurity);
    }

    /// <summary>
    /// Removes an AccessControlList entry on the specified directory for the specified account.
    /// </summary>
    /// <param name="directoryPath"></param>
    /// <param name="identity"></param>
    /// <param name="fileSystemRights"></param>
    /// <param name="inheritanceFlags"></param>
    /// <param name="propogationFlags"></param>
    /// <param name="accessControlType"></param>
    public static void RemoveDirectorySecurity(string directoryPath, string identity, System.Security.AccessControl.FileSystemRights fileSystemRights, System.Security.AccessControl.InheritanceFlags inheritanceFlags, System.Security.AccessControl.PropagationFlags propogationFlags, System.Security.AccessControl.AccessControlType accessControlType)
    {
      // Create a new DirectoryInfo object. 
      System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(directoryPath);

      // Get a DirectorySecurity object that represents the current security settings. 
      System.Security.AccessControl.DirectorySecurity dirSecurity = dirInfo.GetAccessControl();

      // Remove the FileSystemAccessRule from the security settings.  
      dirSecurity.RemoveAccessRule(new System.Security.AccessControl.FileSystemAccessRule(identity, fileSystemRights, inheritanceFlags, propogationFlags, accessControlType));

      // Set the new access settings. 
      dirInfo.SetAccessControl(dirSecurity);
    }
    /// <summary>
    /// Removes an AccessControlList entry on the specified directory for the specified account.
    /// </summary>
    /// <param name="directoryPath"></param>
    /// <param name="identity"></param>
    /// <param name="fileSystemRights"></param>
    /// <param name="accessControlType"></param>
    public static void RemoveDirectorySecurity(string directoryPath, string identity, System.Security.AccessControl.FileSystemRights fileSystemRights, System.Security.AccessControl.AccessControlType accessControlType)
    {
      // Create a new DirectoryInfo object. 
      System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(directoryPath);

      // Get a DirectorySecurity object that represents the current security settings. 
      System.Security.AccessControl.DirectorySecurity dirSecurity = dirInfo.GetAccessControl();

      // Remove the FileSystemAccessRule from the security settings.  
      dirSecurity.RemoveAccessRule(new System.Security.AccessControl.FileSystemAccessRule(identity, fileSystemRights, accessControlType));

      // Set the new access settings. 
      dirInfo.SetAccessControl(dirSecurity);
    }

    /// <summary>
    /// Removes an AccessControlList entry on the specified directory for the specified account. 
    /// </summary>
    /// <param name="directoryPath"></param>
    public static void RemoveInheritablePermissons(string directoryPath)
    {
      // Create a new DirectoryInfo object. 
      System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(directoryPath);

      // Get a DirectorySecurity object that represents the current security settings. 
      System.Security.AccessControl.DirectorySecurity dirSecurity = dirInfo.GetAccessControl();

      // Add the FileSystemAccessRule to the security settings. 
      const bool IsProtected = true;
      const bool PreserveInheritance = false;
      dirSecurity.SetAccessRuleProtection(IsProtected, PreserveInheritance);

      // Set the new access settings. 
      dirInfo.SetAccessControl(dirSecurity);
    }

  }

  /// <summary>
  /// class SecurityFile
  /// </summary>
  class SecurityFile
  {
    /// <summary>
    /// Adds an AccessControlList entry on the specified file for the specified account.
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="identity"></param>
    /// <param name="fileSystemRights"></param>
    /// <param name="inheritanceFlags"></param>
    /// <param name="propogationFlags"></param>
    /// <param name="accessControlType"></param>
    public static void AddFileSecurity(string filePath, string identity, System.Security.AccessControl.FileSystemRights fileSystemRights, System.Security.AccessControl.InheritanceFlags inheritanceFlags, System.Security.AccessControl.PropagationFlags propogationFlags, System.Security.AccessControl.AccessControlType accessControlType)
    {
      // Get a FileSecurity object that represents the current security settings.
      System.Security.AccessControl.FileSecurity fileSecurity = System.IO.File.GetAccessControl(filePath);

      // Add the FileSystemAccessRule to the security settings. 
      fileSecurity.AddAccessRule(new System.Security.AccessControl.FileSystemAccessRule(identity, fileSystemRights, inheritanceFlags, propogationFlags, accessControlType));

      // Set the new access settings.
      System.IO.File.SetAccessControl(filePath, fileSecurity);
    }
    /// <summary>
    /// Adds an AccessControlList entry on the specified file for the specified account.
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="identity"></param>
    /// <param name="fileSystemRights"></param>
    /// <param name="accessControlType"></param>
    public static void AddFileSecurity(string filePath, string identity, System.Security.AccessControl.FileSystemRights fileSystemRights, System.Security.AccessControl.AccessControlType accessControlType)
    {
      // Get a FileSecurity object that represents the current security settings.
      System.Security.AccessControl.FileSecurity fileSecurity = System.IO.File.GetAccessControl(filePath);

      // Add the FileSystemAccessRule to the security settings. 
      fileSecurity.AddAccessRule(new System.Security.AccessControl.FileSystemAccessRule(identity, fileSystemRights, accessControlType));

      // Set the new access settings.
      System.IO.File.SetAccessControl(filePath, fileSecurity);
    }

    /// <summary>
    /// Removes an AccessControlList entry on the specified file for the specified account.
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="identity"></param>
    /// <param name="fileSystemRights"></param>
    /// <param name="inheritanceFlags"></param>
    /// <param name="propogationFlags"></param>
    /// <param name="accessControlType"></param>
    public static void RemoveFileSecurity(string filePath, string identity, System.Security.AccessControl.FileSystemRights fileSystemRights, System.Security.AccessControl.InheritanceFlags inheritanceFlags, System.Security.AccessControl.PropagationFlags propogationFlags, System.Security.AccessControl.AccessControlType accessControlType)
    {
      // Get a FileSecurity object that represents the current security settings.
      System.Security.AccessControl.FileSecurity fileSecurity = System.IO.File.GetAccessControl(filePath);

      // Add the FileSystemAccessRule to the security settings. 
      fileSecurity.RemoveAccessRule(new System.Security.AccessControl.FileSystemAccessRule(identity, fileSystemRights, inheritanceFlags, propogationFlags, accessControlType));

      // Set the new access settings.
      System.IO.File.SetAccessControl(filePath, fileSecurity);
    }

    /// <summary>
    /// Removes an AccessControlList entry on the specified file for the specified account.
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="identity"></param>
    /// <param name="fileSystemRights"></param>
    /// <param name="accessControlType"></param>
    public static void RemoveFileSecurity(string filePath, string identity, System.Security.AccessControl.FileSystemRights fileSystemRights, System.Security.AccessControl.AccessControlType accessControlType)
    {
      // Get a FileSecurity object that represents the current security settings.
      System.Security.AccessControl.FileSecurity fileSecurity = System.IO.File.GetAccessControl(filePath);

      // Add the FileSystemAccessRule to the security settings. 
      fileSecurity.RemoveAccessRule(new System.Security.AccessControl.FileSystemAccessRule(identity, fileSystemRights, accessControlType));

      // Set the new access settings.
      System.IO.File.SetAccessControl(filePath, fileSecurity);
    }

    /// <summary>
    /// Removes an AccessControlList entry on the specified directory for the specified account. 
    /// </summary>
    /// <param name="fileName">Path to the folder</param> 
    public static void RemoveInheritablePermissons(string fileName)
    {
      // Get a DirectorySecurity object that represents the current security settings. 
      System.Security.AccessControl.FileSecurity fileSecurity = System.IO.File.GetAccessControl(fileName);

      // Add the FileSystemAccessRule to the security settings. 
      const bool IsProtected = true;
      const bool PreserveInheritance = false;
      fileSecurity.SetAccessRuleProtection(IsProtected, PreserveInheritance);

      // Set the new access settings. 
      System.IO.File.SetAccessControl(fileName, fileSecurity);
    }
  }
#endif

    /// <summary>
    /// class CommonData
    /// </summary>
    class CommonData
    {
        public static readonly string folderExecutable;
        public static readonly string folderProgramFiles;
        public static readonly string folderDownloadTool;
        public static readonly string folderDownloadRamCanCuPlusDig;
        public static readonly string folderDownloadRamModbusCanCuPlusDig;
        public static readonly string folderCommonApplicationData;
        public static readonly string folderApplicationData;
        public static readonly string folderDeviceData;
        public static readonly string folderErrorData;
        public static readonly string folderDataBase;
        public static readonly string folderArchiveDataBase;
        public static readonly string folderCutCycleData;
        public static readonly string folderStatusData;
        public static readonly string folderStatusInfoData;
        public static readonly string folderHistogramData;
        public static readonly string folderHelpData;
        public static readonly string filePathArchiveSettings;
        public static readonly string filePathArchiveDataBase;
        public static readonly string folderUserDeviceData;
        public static readonly string folderUserErrorData;
        public static readonly string folderUserCutCycleData;
        public static readonly string folderUserStatusData;
        public static readonly string folderUserStatusInfoData;
        public static readonly string folderUserHistogramData;
        public static readonly string folderFdtiUsbConverterSetup;
        public static readonly string folderDownloadToolSetup;
        public static readonly string folderProlificUsbConverterSetup;
        public static readonly string fileAppInfoData;
        public static readonly string folderArchive;

        public static readonly string applicationName;

        /// <summary>
        /// 
        /// </summary>
        static CommonData()
        {
            folderExecutable = AppDomain.CurrentDomain.BaseDirectory;

            folderProgramFiles = Environment.GetEnvironmentVariable("PROGRAMFILES(X86)") ?? Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            if (folderProgramFiles != null)
            {
                folderDownloadTool = Path.Combine(folderProgramFiles, "IHT Automation", "Download Tool");
                folderDownloadRamCanCuPlusDig = Path.Combine(folderDownloadTool, "DownloadRamCan_Fit+3_Over_CU+DIG");//"DownloadRamCanCuPlusDig"        );
                folderDownloadRamModbusCanCuPlusDig = Path.Combine(folderDownloadTool, "DownloadRamModbusCan_Fit+3_Over_CU+DIG");//"DownloadRamModbusCanCuPlusDig"  );
            }
            else
            {
                folderProgramFiles = string.Empty;
                folderDownloadTool = string.Empty;
                folderDownloadRamCanCuPlusDig = string.Empty;
                folderDownloadRamModbusCanCuPlusDig = string.Empty;
            }

            if (folderDownloadRamCanCuPlusDig == string.Empty || !Directory.Exists(folderDownloadRamCanCuPlusDig))
            {
                folderDownloadRamCanCuPlusDig = Path.Combine(folderExecutable, "DownloadRamCanCuPlusDig");
                folderDownloadRamCanCuPlusDig = !Directory.Exists(folderDownloadRamCanCuPlusDig) ? string.Empty : folderDownloadRamCanCuPlusDig;
            }

            if (folderDownloadRamModbusCanCuPlusDig == string.Empty || !Directory.Exists(folderDownloadRamModbusCanCuPlusDig))
            {
                folderDownloadRamModbusCanCuPlusDig = Path.Combine(folderExecutable, "DownloadRamModbusCanCuPlusDig");
                folderDownloadRamModbusCanCuPlusDig = !Directory.Exists(folderDownloadRamModbusCanCuPlusDig) ? string.Empty : folderDownloadRamModbusCanCuPlusDig;
            }

            folderCommonApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            folderApplicationData = Path.Combine(folderCommonApplicationData, Properties.Resources.FolderManufacturer, Properties.Resources.FolderProductName);

            fileAppInfoData = Path.Combine(folderApplicationData, Properties.Resources.FileNameAppInfoData);

            #region Folder-DataBase
            folderDataBase = folderCommonApplicationData + "\\"
                              + Properties.Resources.FolderManufacturer + "\\"
                              + Properties.Resources.FolderProductName + "\\"
                              + Properties.Resources.ApplicationFolder + "\\"
                              + Properties.Resources.FolderDataBase;

            folderArchive = folderCommonApplicationData + "\\"
                              + Properties.Resources.FolderManufacturer + "\\"
                              + Properties.Resources.FolderProductName + "\\"
                              + Properties.Resources.FolderArchive;

            folderArchiveDataBase = folderArchive + "\\"
                                    + Properties.Resources.FolderDataBase;

            filePathArchiveDataBase = folderArchiveDataBase + "\\"
                                     + Properties.Resources.FileNameDataBase;

            filePathArchiveSettings = folderArchiveDataBase + "\\"
                              + Properties.Resources.FileNameSettingsData;

            #endregion // Folder-DataBase

            #region Folder-Data
            folderDeviceData = folderCommonApplicationData + "\\"
                              + Properties.Resources.FolderManufacturer + "\\"
                              + Properties.Resources.FolderProductName + "\\"
                              + Properties.Resources.FolderDeviceData;

            folderErrorData = folderCommonApplicationData + "\\"
                              + Properties.Resources.FolderManufacturer + "\\"
                              + Properties.Resources.FolderProductName + "\\"
                              + Properties.Resources.FolderErrorData;

            folderCutCycleData = folderCommonApplicationData + "\\"
                                + Properties.Resources.FolderManufacturer + "\\"
                                + Properties.Resources.FolderProductName + "\\"
                                + Properties.Resources.FolderCutCycleData;

            folderStatusData = folderCommonApplicationData + "\\"
                              + Properties.Resources.FolderManufacturer + "\\"
                              + Properties.Resources.FolderProductName + "\\"
                              + Properties.Resources.FolderStatusData;

            folderStatusInfoData = folderCommonApplicationData + "\\"
                                  + Properties.Resources.FolderManufacturer + "\\"
                                  + Properties.Resources.FolderProductName + "\\"
                                  + Properties.Resources.FolderStatusInfoData;

            folderHistogramData = folderCommonApplicationData + "\\"
                                  + Properties.Resources.FolderManufacturer + "\\"
                                  + Properties.Resources.FolderProductName + "\\"
                                  + Properties.Resources.FolderHistogramData;

            folderHelpData = folderCommonApplicationData + "\\"
                            + Properties.Resources.FolderManufacturer + "\\"
                            + Properties.Resources.FolderProductName + "\\"
                            + Properties.Resources.FolderHelpData;
            #endregion // Folder-Data   

            #region Folder-User-Data
            folderUserDeviceData = folderCommonApplicationData + "\\"
                                  + Properties.Resources.FolderManufacturer + "\\"
                                  + Properties.Resources.FolderProductName + "\\"
                                  + Properties.Resources.FolderUser + "\\"
                                  + Properties.Resources.FolderDeviceData;

            folderUserErrorData = folderCommonApplicationData + "\\"
                                  + Properties.Resources.FolderManufacturer + "\\"
                                  + Properties.Resources.FolderProductName + "\\"
                                  + Properties.Resources.FolderUser + "\\"
                                  + Properties.Resources.FolderErrorData;

            folderUserCutCycleData = folderCommonApplicationData + "\\"
                                    + Properties.Resources.FolderManufacturer + "\\"
                                    + Properties.Resources.FolderProductName + "\\"
                                    + Properties.Resources.FolderUser + "\\"
                                    + Properties.Resources.FolderCutCycleData;

            folderUserStatusData = folderCommonApplicationData + "\\"
                                   + Properties.Resources.FolderManufacturer + "\\"
                                   + Properties.Resources.FolderProductName + "\\"
                                   + Properties.Resources.FolderUser + "\\"
                                   + Properties.Resources.FolderStatusData;

            folderUserStatusInfoData = folderCommonApplicationData + "\\"
                                       + Properties.Resources.FolderManufacturer + "\\"
                                       + Properties.Resources.FolderProductName + "\\"
                                       + Properties.Resources.FolderUser + "\\"
                                       + Properties.Resources.FolderStatusInfoData;

            folderUserHistogramData = folderCommonApplicationData + "\\"
                                  + Properties.Resources.FolderManufacturer + "\\"
                                  + Properties.Resources.FolderProductName + "\\"
                                  + Properties.Resources.FolderUser + "\\"
                                  + Properties.Resources.FolderHistogramData;
            #endregion // Folder-User-Data

            folderFdtiUsbConverterSetup = folderCommonApplicationData + "\\"
                                         + Properties.Resources.FolderManufacturer + "\\"
                                         + Properties.Resources.FolderProductName + "\\"
                                         + Properties.Resources.FolderFdtiUsbConverterSetup;

            folderDownloadToolSetup = folderCommonApplicationData + "\\"
                                     + Properties.Resources.FolderManufacturer + "\\"
                                     + Properties.Resources.FolderProductName + "\\"
                                     + Properties.Resources.FolderDownloadToolSetup;

            folderProlificUsbConverterSetup = folderCommonApplicationData + "\\"
                                         + Properties.Resources.FolderManufacturer + "\\"
                                         + Properties.Resources.FolderProductName + "\\"
                                         + Properties.Resources.FolderProlificUsbConverterSetup;

            //applicationName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationName;
            /*      
                  // Assembly-Informationen der laufenden Assembly abholen 
                  Assembly  asmInfo = System.Reflection.Assembly.GetExecutingAssembly(); 

                  AssemblyTitleAttribute       asmTitleAttribute;
                  AssemblyDescriptionAttribute asmDescriptionAttribute;
                  AssemblyCompanyAttribute     asmCompanyAttribute;
                  AssemblyProductAttribute     asmProductAttribute;
                  AssemblyCopyrightAttribute   asmCopyrightAttribute;
                  AssemblyTrademarkAttribute   asmTrademarkAttribute;

                  asmInfo.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            */
            Debug.Print("Titel: " + AssemblyInfo.AssemblyTitle);
            Debug.Print("Beschreibung: " + AssemblyInfo.AssemblyDescription);
            Debug.Print("Firma: " + AssemblyInfo.AssemblyCompany);
            Debug.Print("Produkt: " + AssemblyInfo.AssemblyProduct);
            Debug.Print("Copyright: " + AssemblyInfo.AssemblyCopyright);
            Debug.Print("Version: " + AssemblyInfo.AssemblyVersion);

            Debug.Print("IHT CommonApplicationData: " + folderCommonApplicationData);

            Debug.Print("IHT Manufacturer-Vereichnis: " + Properties.Resources.FolderManufacturer);
            Debug.Print("IHT Product-Verzeichnis: " + Properties.Resources.FolderProductName);

            Debug.Print("IHT DatenBank-Verzeichnis: " + folderDataBase);
            Debug.Print("IHT EinstellungenArchiv-File: " + filePathArchiveSettings);
            Debug.Print("IHT DatenBankArchiv-File: " + filePathArchiveDataBase);

            Debug.Print("IHT GeräteDaten-Verzeichnis: " + folderDeviceData);
            Debug.Print("IHT User-GeräteDaten-Verzeichnis: " + folderUserDeviceData);

            Debug.Print("IHT StatusDaten-Verzeichnis: " + folderStatusData);
            Debug.Print("IHT User-StatusDaten-Verzeichnis: " + folderUserStatusData);

            Debug.Print("IHT FDTI USB Converter Treiber Verzeichnis: " + folderFdtiUsbConverterSetup);
            Debug.Print("IHT Download Tool Setup Verzeichnis: " + folderDownloadToolSetup);

            Debug.Print("IHT PROLIFIC USB Converter Treiber Verzeichnis: " + folderProlificUsbConverterSetup);
        }

        /// <summary>
        /// 
        /// </summary>
        //static public bool OpenFileDlg(string title, string directory, string filter, ref string fileName)
        //{
        //    bool blResult = false;
        //    try
        //    {
        //        if (!Directory.Exists(directory))
        //        {
        //            Directory.CreateDirectory(directory);
        //        }

        //        OpenFileDialog ofd = new OpenFileDialog();
        //        ofd.Multiselect = false;
        //        ofd.InitialDirectory = directory;
        //        ofd.Filter = filter;
        //        ofd.Title = title;
        //        if (ofd.ShowDialog() == DialogResult.OK)
        //        {
        //            fileName = ofd.FileName;
        //            blResult = true;
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        MainWindow.MsgBox(exc.Message);
        //    }
        //    return blResult;
        //}

        /// <summary>
        /// 
        /// </summary>
        //static public bool SaveFileDlg(string title, string directory, string filter, ref string fileName)
        //{
        //    bool blResult = false;
        //    try
        //    {
        //        if (!Directory.Exists(directory))
        //        {
        //            Directory.CreateDirectory(directory);
        //        }
        //        string Month = (DateTime.Now.Month < 10) ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
        //        string Day = (DateTime.Now.Day < 10) ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
        //        string Hour = (DateTime.Now.Hour < 10) ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString();
        //        string Minute = (DateTime.Now.Minute < 10) ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString();
        //        string Second = (DateTime.Now.Second < 10) ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString();

        //        SaveFileDialog sfd = new SaveFileDialog();
        //        sfd.InitialDirectory = directory;
        //        sfd.Filter = filter;
        //        sfd.FileName = fileName + "__" + DateTime.Now.Year.ToString() + "_" + Month + "_" + Day
        //                                + "__" + Hour + "_" + Minute + "_" + Second;
        //        sfd.Title = title;//"Save ... data";
        //        if (sfd.ShowDialog() == DialogResult.OK)
        //        {
        //            fileName = sfd.FileName;
        //            blResult = true;
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        MainWindow.MsgBox(exc.Message);
        //    }
        //    return blResult;
        //}


        /// <summary>
        /// 
        /// </summary>
        public class InstalledProgramInfo
        {
            public string name;
            public string path;
        }
        /// <summary>
        /// 
        /// </summary>
        public static InstalledProgramInfo FindInstalledApp(string appName, string exeName)
        {
            if (String.IsNullOrEmpty(appName)) return null;

            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            Microsoft.Win32.RegistryHive[] keys = new Microsoft.Win32.RegistryHive[] { Microsoft.Win32.RegistryHive.CurrentUser, Microsoft.Win32.RegistryHive.LocalMachine };
            Microsoft.Win32.RegistryView[] views = new Microsoft.Win32.RegistryView[] { Microsoft.Win32.RegistryView.Registry32, Microsoft.Win32.RegistryView.Registry64 };

            foreach (var hive in keys)
            {
                //Exception exdummy;

                foreach (var view in views)
                {
                    Microsoft.Win32.RegistryKey rk = null;
                    Microsoft.Win32.RegistryKey basekey = null;

                    try
                    {
                        basekey = Microsoft.Win32.RegistryKey.OpenBaseKey(hive, view);
                        rk = basekey.OpenSubKey(uninstallKey);
                    }
                    catch (Exception ex)
                    {
                        //exdummy=ex; 
                        Debug.Write(ex.Message);
                        continue;
                    }

                    if (basekey == null || rk == null)
                    {
                        continue;
                    }

                    if (rk == null)
                    {
                        return null;
                    }


                    foreach (string skName in rk.GetSubKeyNames())
                    {
                        try
                        {
                            using (Microsoft.Win32.RegistryKey sk = rk.OpenSubKey(skName))
                            {
                                if (sk == null)
                                {
                                    continue;
                                }

                                object skname = sk.GetValue("DisplayName");
                                object skpath = sk.GetValue("InstallLocation");
                                if (skpath == null)
                                {
                                    skpath = sk.GetValue("UninstallString");
                                    if (skpath == null)
                                    {
                                        continue;
                                    }
                                    string fileName = skpath.ToString();
                                    if (fileName.StartsWith("\"", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        continue;
                                    }
                                    FileInfo fi = new FileInfo(fileName);
                                    skpath = fi.Directory.FullName;
                                }

                                if (skname == null || skpath == null)
                                {
                                    continue;
                                }
                                string thisname = skname.ToString();
                                string thispath = skpath.ToString();


                                if (!thisname.Equals(appName, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    continue;
                                }

                                // C:\\Program Files (x86)\\IHT Automation\\Download Tool\\{E1A3D23B-CB52-4B78-95A2-5DC0094A71ED}\\AKDeInstall.exe
                                if (thispath.Contains("AKDeInstall.exe"))
                                {
                                    string[] splits = thispath.Split('{');
                                    exeName = exeName.Replace(".exe", String.Empty);
                                    thispath = splits[0] + exeName + ".exe";
                                }
                                InstalledProgramInfo inf = new InstalledProgramInfo();
                                inf.name = thisname;
                                inf.path = thispath;

                                return inf;
                            } // using
                        }
                        catch (System.ArgumentException ex)
                        {
                            //exdummy = exc;
                            Debug.Write(ex.Message);
                        }
                        catch (System.NotSupportedException ex)
                        {
                            //exdummy = exc;
                            Debug.Write(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Debug.Write(ex.Message);
                            //MainWndHelper.GetMainWndHelper().SetStatusMsg(IhtMsgLog.Info.Error, ex.Message);
                        }
                    }
                } // view
            } // hive

            return null;
        }
        /// <summary>
        /// 
        /// </summary>
//        static public string FindByDisplayName(string appName, string exeName)
//        {
//            InstalledProgramInfo installedProgramInfo = FindInstalledApp(appName, exeName);
//            return (installedProgramInfo != null) ? installedProgramInfo.path : String.Empty;
//#if false
//      // If you don't use contracts, check this and throw ArgumentException
//      //Contract.Requires(!string.IsNullOrEmpty(appName));
//      const string keyPath = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall";// @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

//      using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(keyPath))
//      {
//        var installed =
//            (from skName in key.GetSubKeyNames()
//             let subkey = key.OpenSubKey(skName)
//             select new
//             {
//               name = subkey.GetValue("DisplayName") as string,
//               path = subkey.GetValue("InstallLocation") as string

//             }).ToList();

//        var desired = installed.FindAll(
//            program => program.name != null &&
//            program.name.Contains(appName) &&
//            !String.IsNullOrEmpty(program.path));

//        return (desired.Count > 0) ? desired[0].path : null;
//      }
//#endif
//#if false
//      // 32-bit applications 
//      // Microsoft.Win32.RegistryKey parentKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
//      nameList = parentKey.GetSubKeyNames();
//      for (int i = 0; i < nameList.Length; i++)
//      {
//        Microsoft.Win32.RegistryKey regKey = parentKey.OpenSubKey(nameList[i]);
//        try
//        {
//          if (regKey.GetValue("DisplayName").ToString() == appName)
//          {
//            string location = (string)regKey.GetValue("InstallLocation").ToString();
//            return location;
//          }
//        }
//        catch (Exception exc)
//        {
//          MainWndHelper.GetMainWndHelper().SetStatusMsg(IhtMsgLog.Info.Error, exc.Message);
//        }
//        catch { }
//      }

//      // 64-bit applications 
//      parentKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
//      nameList = parentKey.GetSubKeyNames();
//      for (int i = 0; i < nameList.Length; i++)
//      {
//        Microsoft.Win32.RegistryKey regKey = parentKey.OpenSubKey(nameList[i]);
//        try
//        {
//          if (regKey.GetValue("DisplayName").ToString() == appName)
//          {
//            string location = (string)regKey.GetValue("InstallLocation").ToString();
//            return location;
//          }
//        }
//        catch (Exception exc)
//        {
//          MainWndHelper.GetMainWndHelper().SetStatusMsg(IhtMsgLog.Info.Error, exc.Message);
//        }
//        catch { }
//      }

//      return String.Empty;
//#endif
//        }


        /// <summary>
        /// 
        /// </summary>
        //static public void SecurityDirectory(string path)
        //{
        //    try
        //    {
        //        DirectorySecurity sec = Directory.GetAccessControl(path);
        //        // Using this instead of the "Everyone" string means we work on non-English systems.
        //        SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
        //        sec.AddAccessRule
        //        (
        //          new FileSystemAccessRule
        //          (
        //            everyone,
        //            FileSystemRights.Modify | FileSystemRights.Synchronize,
        //            InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
        //            PropagationFlags.None, AccessControlType.Allow
        //           )
        //        );
        //        Directory.SetAccessControl(path, sec);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.Write(ex.Message);
        //    }
        //}

        #region Download
        /// <summary>
        /// 
        /// </summary>
        static public string FindFwFile(string partNo, string folder)
        {
            string fileFw = string.Empty;
            try
            {
                if (folder != string.Empty)
                {
                    string[] directories = Directory.GetDirectories(folder);
                    string directoryFwFiles = string.Empty;
                    if (directories.Length > 0 && partNo != string.Empty)
                    {
                        foreach (string directory in directories)
                        {
                            if (directory.Contains(partNo))
                            {
                                directoryFwFiles = directory;
                                break;
                            }
                        }
                    }
                    else
                    {
                        directoryFwFiles = folder;
                    }

                    UInt32 dwFwVersion = 0;
                    string[] files = Directory.GetFiles(directoryFwFiles, "*.fw");
                    foreach (string file in files)
                    {
                        UInt32 dwCurrFwVersion = GetCurrFwVersion(file.Replace(directoryFwFiles, ""));
                        // Fw-File mit hoechster Version merken          
                        if (dwCurrFwVersion > dwFwVersion)
                        {
                            dwFwVersion = dwCurrFwVersion;
                            fileFw = file;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return fileFw;
        }

        public static uint GetCurrFwVersion(string file)
        {
            string fileFw = file;
            // Die Fw-Version extrahieren
            fileFw = fileFw.Replace("\\", "");
            fileFw = fileFw.ToUpper();
            // FW-Version sieht folgendermassen aus: Vxx_yy_zz
            fileFw = fileFw.Replace("V", "");
            string[] txtVersions = fileFw.Split('_');
            UInt32 dwCurrFwVersion = 0;
            if (txtVersions.Length >= 3)
            {
                dwCurrFwVersion = Convert.ToUInt32(txtVersions[0]) << 16;
                dwCurrFwVersion += Convert.ToUInt32(txtVersions[1]) << 8;
                dwCurrFwVersion += Convert.ToUInt32(txtVersions[2]);
            }
            return dwCurrFwVersion;
        }
        #endregion // Download

    }

}

