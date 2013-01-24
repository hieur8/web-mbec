using Resources;

namespace MiBo.Domain.Common.Helper
{
    public static class ParameterHelper
    {
        /// <summary>
        /// Get message param from resource.
        /// </summary>
        /// <param name="key">Param</param>
        /// <returns>Message param</returns>
        public static string GetMessageParam(string key)
        {
            var rm = Parameters.ResourceManager;
            return rm.GetString(key);
        }
    }
}