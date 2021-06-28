using System;
using System.Collections.Generic;
using System.Text;

namespace WeinApp.Services
{
    public interface IBiometricAuthenticationService
    {
        void Encrypt(byte[] input, Action<byte[]> success, Action<string> error);

        void Decrypt(byte[] input, Action<byte[]> success, Action<string> error);
    }
}
