// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("bnp7sW/XRQFfB9/fgPU6nX3pughy0T/fEy3nPTjKHahNLpkx2UuIgr6vX9lfpzi5U0juCIyzP35hcTlJmydf5fdtzOgm0i/X+el/oK9MWHd4SAS22SOCUECj3VPsC1XoojwrGge1NhUHOjE+HbF/scA6NjY2Mjc0/kmpUfcMWTWFgY5NOeekIi/+6+U6urYiQXw2TWvlugeNZ/kk93GNbIuVkWAkvG4ROAeQB9zYe21UwDtDK+DAIlhdA1g29psBm+4g6+z1uoiL+zm/2duW4W3LAkIsGH0rPyVW1DQr/4G2Wx6jMuqkeScACeEz5Yok2ohUEyXvQeNIg73TK/eWF4bq0ne1Njg3B7U2PTW1NjY3tctm+rlj0i7AQu5dBrFunjU0Njc2");
        private static int[] order = new int[] { 10,2,3,5,8,10,7,11,11,11,11,13,12,13,14 };
        private static int key = 55;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
