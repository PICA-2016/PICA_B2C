using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Infrastructure.CrossCutting.Core.Parameters
{
    /// <summary>
    /// Class responsible for managing the settings in the configuration file of the application.
    /// </summary>
    public static class ParameterSettings
    {
        /// <summary>
        /// Returns a value of configuration file.
        /// </summary>
        /// <param name="nombrePropiedad">Name of the property to be searched.</param>
        /// <param name="valorDefecto">Default value that is returned if not found. 
        /// If the property is not the default value is inserted in the file.</param>
        /// <returns>Value found.</returns>
        public static string GetValue(string nombrePropiedad, string valorDefecto)
        {
            string valor = ConfigurationManager.AppSettings[nombrePropiedad];

            if (valor == null)
            {
                SetValue(nombrePropiedad, valorDefecto);
                valor = valorDefecto;
            }

            return valor;
        }

        /// <summary>
        /// It sets a value in the configuration file of the application.
        /// </summary>
        /// <param name="nombrePropiedad">Name property to search.</param>
        /// <param name="valor">Value to be set.</param>
        public static void SetValue(string nombrePropiedad, string valor)
        {
            Configuration configuracion;

            try
            {
                configuracion = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            catch
            {
                configuracion = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            }

            configuracion.AppSettings.Settings.Remove(nombrePropiedad);
            configuracion.AppSettings.Settings.Add(nombrePropiedad, valor);
            configuracion.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
