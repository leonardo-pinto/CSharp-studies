using System;

namespace LABank.Configuration
{
    /// <summary>
    /// Project level configuration settings
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Customer number start from 1001;incremented by 1
        /// </summary>
        public static long BaseCustomerNo { get; set; } = 1000;
    }
}
