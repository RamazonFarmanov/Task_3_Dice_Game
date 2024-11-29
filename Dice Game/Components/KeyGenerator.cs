using System.Security.Cryptography;

namespace Dice_Game.Components
{
    public class KeyGenerator
    {
        public string GetHEXKey()
        {
            byte[] key = new byte[32];
            RandomNumberGenerator.Fill(key);
            string keyHex = Convert.ToHexString(key);
            return keyHex;
        }
    }
}