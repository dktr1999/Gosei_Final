using FinalProject.Debugging;

namespace FinalProject
{
    public class FinalProjectConsts
    {
        public const string LocalizationSourceName = "FinalProject";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "5ce6ef57eeff45ce9195543cc91017bd";
    }
}
