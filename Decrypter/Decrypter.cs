namespace Decrypter
{
    public static class Decrypter
    {
        public static string Decrypt(string pass)
        {
            char[] charList = pass.ToCharArray(0, pass.Length);
            string passDecrypt = string.Empty;
            
            foreach (var character in charList)
            {
                if (character.ToString() == "0")
                    passDecrypt = passDecrypt + "1";
                else if (character.ToString() == "4")
                    passDecrypt = passDecrypt + "5";
                else if (character.ToString() == "8")
                    passDecrypt = passDecrypt + "9";
                else if (character.ToString() == "1")
                    passDecrypt = passDecrypt + "2";
                else if (character.ToString() == "Q")
                    passDecrypt = passDecrypt + "M";
                else if (character.ToString() == "w")
                    passDecrypt = passDecrypt + "v";
                else if (character.ToString() == "E")
                    passDecrypt = passDecrypt + "K";
                else if (character.ToString() == "r")
                    passDecrypt = passDecrypt + "s";
                else
                    passDecrypt = passDecrypt + character.ToString();
            }

            return passDecrypt;
        }
    }
}
