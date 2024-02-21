using System;
using System.Security.Cryptography;
using System.Text;
using Yubico.YubiKey;
using Yubico.YubiKey.Piv;

namespace AASAXUtilLib.AX.Framework.Tools.ModelManagement
{
    internal class KeyCollector
    {
        public bool KeyCollectorDelegate(KeyEntryData? p_keyEntryData)
        {
            if (p_keyEntryData is null) return false;

            switch (p_keyEntryData.Request)
            {
                case KeyEntryRequest.Release:
                    // Do something here if there is sensitive data to clean up.
                    break;
                case KeyEntryRequest.VerifyPivPin:

                    var result = GetPinFromUser(p_keyEntryData.IsRetry, p_keyEntryData.RetriesRemaining ?? 0);

                    if (result.UserCanceled || result.PinBytes is null)
                    {
                        return false;
                    }

                    p_keyEntryData.SubmitValue(result.PinBytes);

                    return true;
            }

            return false;
        }

        private (byte[]? PinBytes, bool UserCanceled) GetPinFromUser(bool p_isRetry, int p_retriesRemaining)
        {
            Console.Clear();

            if (p_isRetry)
            {
                Console.WriteLine("Invalid PIN. Please try again.");
                Console.WriteLine($"{p_retriesRemaining} retries remaining before PIN is locked.");
            }

            Console.Write("Please input your PIV PIN (C to cancel): ");

            var pinEntry = Console.ReadLine();

            if (pinEntry is null)
            {
                return (null, false);
            }

            if (pinEntry.Equals("c", StringComparison.InvariantCultureIgnoreCase))
            {
                return (null, true);
            }

            return (Encoding.Default.GetBytes(pinEntry), false);
        }        
    }
}
