using System;
using System.Collections.Generic;
using System.Text;

namespace WeinApp.Services
{
    public interface IPasswordEncryptionService
    {
        byte[] GenerateKey(string passphrase);

        byte[] Encrypt(byte[] input, byte[] key);

        byte[] Decrypt(byte[] input, byte[] key);
    }
}
