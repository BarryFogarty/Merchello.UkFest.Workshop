using System;
using System.Configuration;
using System.Globalization;

namespace Merchello.UkFest.Web
{
    public static class AppSettings
    {
        #region App Settings

        public static object CropBackgroundColour
        {
            get { return Setting<string>("CropBackgroundColour"); }
        }


        #endregion

        #region Generic getter

        private static T Setting<T>(string name)
        {
            string value = ConfigurationManager.AppSettings[name];

            if (value == null)
            {
                throw new Exception(String.Format("Could not find setting '{0}',", name));
            }

            return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }

        #endregion
    }
}
