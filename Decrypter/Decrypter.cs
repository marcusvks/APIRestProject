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
                if (character.ToString() == "2")
                    passDecrypt = passDecrypt + "1";
                else if (character.ToString() == "6")
                    passDecrypt = passDecrypt + "5";
                else if (character.ToString() == "q")
                    passDecrypt = passDecrypt + "m";
                else if (character.ToString() == "w")
                    passDecrypt = passDecrypt + "v";
                else if (character.ToString() == "e")
                    passDecrypt = passDecrypt + "k";
                else if (character.ToString() == "r")
                    passDecrypt = passDecrypt + "s";
                else
                    passDecrypt = passDecrypt + character.ToString();
            }

            return passDecrypt;
        }
    }
}
