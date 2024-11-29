using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;

namespace Dice_Game.Components
{
    public class HMACGenerator
    {
        KeyGenerator keyGenerator = new KeyGenerator();
        public string key = "";
        public string CalculateHMAC(string message)
        {
            key = keyGenerator.GetHEXKey();

            byte[] keyBytes = Convert.FromHexString(key);
            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
            
            var hmac = new HMac(new Sha3Digest(256));
            
            hmac.Init(new KeyParameter(keyBytes));
            
            hmac.BlockUpdate(messageBytes, 0, messageBytes.Length);

            byte[] hmacBytes = new byte[hmac.GetMacSize()];
            hmac.DoFinal(hmacBytes, 0);

            string hmacHex = BitConverter.ToString(hmacBytes).Replace("-", "");

            return hmacHex;
        }
    }
}
