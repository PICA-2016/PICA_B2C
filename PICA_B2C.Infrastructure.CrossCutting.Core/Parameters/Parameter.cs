using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICA_B2C.Infrastructure.CrossCutting.Core.Parameters
{
    /// <summary>
    /// Management class parameter.
    /// </summary>
    public static class Parameter
    {
        /// <summary>
        /// Name of IoCFactory
        /// </summary>
        public static string NameIoCFactory
        {
            get
            {
                return ParameterSettings.GetValue("IoCFactoryServiceAgent", "RealAppContext");
            }
        }
    }
}
