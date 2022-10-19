using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Resources;

namespace SharedComponents.Cultures
{
    // http://www.flaggenbilder.de/flaggen-der-welt-von-a-z.html

    // Table of Language Culture Names, Codes, and ISO 
    // https://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx

    public class LanguageItem
    {
        public string Image { get; set; }
        public string Label { get; set; }
        public CultureInfo Culture { get; set; }

        public LanguageItem(string image, string label, CultureInfo culture)
        {
            Image = image;
            Label = label;
            Culture = culture;
        }
    }

    /// <summary>
    /// Wraps up XAML access to instance of WPFLocalize.Properties.Resources, list of available cultures, and method to change culture
    /// </summary>
    public class CultureResources
    {
        //only fetch installed cultures once
        private static bool bFoundInstalledCultures = false;

        private static List<LanguageItem> pSupportedCultures = new List<LanguageItem>();
        /// <summary>
        /// List of available cultures, enumerated at startup
        /// </summary>
        public static List<LanguageItem> SupportedCultures
        {
            get { return pSupportedCultures; }
        }

        public CultureResources()
        {
            if (!bFoundInstalledCultures)
            {
                //determine which cultures are available to this application
                Debug.WriteLine("Get Installed cultures:");
                CultureInfo tCulture = new CultureInfo("");
                foreach (string dir in Directory.GetDirectories(Directory.GetCurrentDirectory()))
                {
                    try
                    {
                        //see if this directory corresponds to a valid culture name
                        DirectoryInfo dirinfo = new DirectoryInfo(dir);
                        tCulture = CultureInfo.GetCultureInfo(dirinfo.Name);
                        ResourceManager resourceManager = Properties.Resources.ResourceManager;
                        string r = "pack://application:,,,/" + resourceManager.GetString("_CultureLanguageImage", tCulture);
                        Uri y = new Uri(r);
                        string image = y.AbsoluteUri;
                        string label = tCulture.DisplayName;//resourceManager.GetString("LabelCultureName", tCulture);
                                                            //determine if a resources dll exists in this directory that matches the executable name
                        if (dirinfo.GetFiles(Path.GetFileNameWithoutExtension(System.AppDomain.CurrentDomain.FriendlyName) + ".resources.dll").Length > 0)
                        {
                            label = label.Split('(')[0];
                            LanguageItem languageItem = new LanguageItem(image, label, tCulture);
                            pSupportedCultures.Add(languageItem);
                            Debug.WriteLine(string.Format(" Found Culture: {0} [{1}]", tCulture.DisplayName, tCulture.Name));
                        }
                    }
                    catch (ArgumentException ex) //ignore exceptions generated for any unrelated directories in the bin folder
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
                bFoundInstalledCultures = true;
            }
        }

        /// <summary>
        /// The Resources ObjectDataProvider uses this method to get an instance of the WPFLocalize.Properties.Resources class
        /// </summary>
        /// <returns></returns>
        public Properties.Resources GetResourceInstance()
        {
            return new Properties.Resources();
        }

        //private static ObjectDataProvider m_provider;
        //public static ObjectDataProvider ResourceProvider
        //{
        //  get
        //  {
        //    if (m_provider == null)
        //    {
        //      m_provider = (ObjectDataProvider)App.Current.FindResource("Resources");
        //    }
        //    return m_provider;
        //  }
        //}

        /// <summary>
        /// Change the current culture used in the application.
        /// If the desired culture is available all localized elements are updated.
        /// </summary>
        /// <param name="culture">Culture to change to</param>
        public static void ChangeCulture(CultureInfo culture)
        {
            //remain on the current culture if the desired culture cannot be found
            // - otherwise it would revert to the default resources set, which may or may not be desired.
            foreach (LanguageItem item in pSupportedCultures)
            {
                if (item.Culture.Equals(culture))
                {
                    Properties.Resources.Culture = culture;
                    //ResourceProvider.Refresh();

                    ChangeCultureIhtCommunicApc(Properties.Resources.Culture);
                    ChangeCultureIhtCommunicService(Properties.Resources.Culture);

                    return;
                }
            }
            Debug.WriteLine(string.Format("Culture [{0}] not available", culture));
        }

        public static LanguageItem GetLanguageItem(CultureInfo culture)
        {
            foreach (LanguageItem item in pSupportedCultures)
            {
                if (item.Culture.Equals(culture))
                {
                    return item;
                }
            }
            return null;
        }

        public static string GetString(string p)
        {
            string result = Properties.Resources.ResourceManager.GetString(p, Properties.Resources.Culture);
            if (result == null || result == string.Empty)
            {
                return p;
            }
            return result;
        }


        internal static void ChangeCultureIhtCommunicApc(CultureInfo culture)
        {
            //IhtCommunicApc.Cultures.CultureResources.ChangeCulture(culture);
            //ResourceProvider.Refresh();
        }

        internal static void ChangeCultureIhtCommunicService(CultureInfo culture)
        {
            //IhtCommunicService.Cultures.CultureResources.ChangeCulture(culture);
            //ResourceProvider.Refresh();
        }
    }
}
