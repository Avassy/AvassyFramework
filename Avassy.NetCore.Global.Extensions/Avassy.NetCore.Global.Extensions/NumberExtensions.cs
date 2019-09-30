namespace Avassy.NetCore.Global.Extensions
{
    public static class NumberExtensions
    {
        public static string ToByteSizeString(this long numberOfBytes)
        {
            string[] suffix = { "Bytes", "KB", "MB", "GB", "TB" };

            int i;

            double bytesDouble = numberOfBytes;

            for (i = 0; i < suffix.Length && numberOfBytes >= 1024; i++, numberOfBytes /= 1024)
            {
                bytesDouble = numberOfBytes / 1024.0;
            }

            return $"{bytesDouble:0.##} {suffix[i]}";
        }

        public static string ToByteSizeString(this double numberOfBytes)
        {
            string[] suffix = { "Bytes", "KB", "MB", "GB", "TB" };

            int i;

            double bytesDouble = numberOfBytes;

            for (i = 0; i < suffix.Length && numberOfBytes >= 1024; i++, numberOfBytes /= 1024)
            {
                bytesDouble = numberOfBytes / 1024.0;
            }

            return $"{bytesDouble:0.##} {suffix[i]}";
        }
        
        public static string ToByteSizeString(this int numberOfBytes)
        {
            string[] suffix = { "Bytes", "KB", "MB", "GB", "TB" };

            int i;

            double bytesDouble = numberOfBytes;

            for (i = 0; i < suffix.Length && numberOfBytes >= 1024; i++, numberOfBytes /= 1024)
            {
                bytesDouble = numberOfBytes / 1024.0;
            }

            return $"{bytesDouble:0.##} {suffix[i]}";
        }
    }
}
