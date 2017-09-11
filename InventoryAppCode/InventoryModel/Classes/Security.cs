using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net.NetworkInformation;

namespace InventoryModel.Classes
{
    public class Security
    {
        static string appName = Properties.Settings.Default["AppName"].ToString();

        public static string ComputeHash(string str)
        {
            List<byte> list = new List<byte>(ComputeHashToBytes(str));
            return (Convert.ToBase64String(list.ToArray()));
        }

        public static IList<byte> ComputeHashToBytes(string str)
        {
            HashAlgorithm hasher;
            List<byte> encodedBytes;
            List<byte> result;
            encodedBytes = new List<byte>(Encoding.Unicode.GetBytes(str));
            hasher = new SHA1Managed();
            using (hasher)
            {
                result = new List<byte>(hasher.ComputeHash(encodedBytes.ToArray()));
                return (result);
            }
        }

        private static void firstTime(RegistryKey i_regKey)
        {
            DateTime dt = DateTime.Now;
            string onlyDate = dt.ToString("ddMMyyyy"); // get only date not time
            i_regKey.SetValue("Install", Encrypt(onlyDate)); //Value Name,Value Data
            i_regKey.SetValue("Use", Encrypt(onlyDate)); //Value Name,Value Data
            i_regKey.SetValue("Last", Encrypt(onlyDate));
            i_regKey.SetValue("Word", ComputeHash("12345"));
        }

        public static string getEvalDays()
        {
            try
            {
                String regKeyPath = @"Software\" + appName;
                // get present date from system
                DateTime presentDate = DateTime.Now;
                string today = presentDate.ToString("ddMMyyyy");
                presentDate = DateTime.ParseExact(today, "ddMMyyyy", CultureInfo.InvariantCulture);

                // get instalation date
                RegistryKey regkey = Registry.CurrentUser;
                regkey = regkey.OpenSubKey(regKeyPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (regkey == null)
                {
                    // first time use
                    regkey = Registry.CurrentUser.CreateSubKey(regKeyPath);
                    firstTime(regkey);
                }
                string Br = Decrypt((string)regkey.GetValue("Last"));
                DateTime lastDate = DateTime.ParseExact(Br, "ddMMyyyy", CultureInfo.InvariantCulture);

                TimeSpan diff = lastDate.Subtract(presentDate); //first.Subtract(second);
                int totaldays = (int)diff.TotalDays;

                //// special check if user chenge date in system
                //string usd = Decrypt((string)regkey.GetValue("Use"));
                //DateTime lastUse = DateTime.ParseExact(usd, "ddMMyyyy", CultureInfo.InvariantCulture);
                //TimeSpan diff1 = presentDate.Subtract(lastUse); //first.Subtract(second);
                //int useBetween = (int)diff1.TotalDays;

                //if (useBetween >= 0)
                //{
                //    // put next use day in registry
                //    regkey.SetValue("Use", Encrypt(today)); //Value Name,Value Data
                //    if (totaldays < 0)
                //        return "0"; // if user change date in system like date set before installation
                //    else
                //        return totaldays.ToString(); //Expired
                //}
                //else
                //    return "0"; // if user change date in system

                return totaldays.ToString();
            }
            catch (Exception)
            {
                return "0";
            }
        }

        //public static void changeAppPass(string i_newPass)
        //{
        //    String regKeyPath = @"Software\" + appName;
        //    RegistryKey regkey = Registry.CurrentUser;
        //    regkey = regkey.OpenSubKey(regKeyPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
        //    regkey.SetValue("Word", ComputeHash(i_newPass));
        //}

        //public static bool checkAppPass(string i_pass)
        //{
        //    String regKeyPath = @"Software\" + appName;
        //    // get present date from system

        //    // get instalation date
        //    RegistryKey regkey = Registry.CurrentUser;
        //    regkey = regkey.OpenSubKey(regKeyPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
        //    string currPass = (string)regkey.GetValue("Word");
        //    if (currPass == null)
        //    {
        //        currPass = ComputeHash("12345");
        //        regkey.SetValue("Word", currPass);
        //    }
        //    if (currPass == ComputeHash(i_pass))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = GetPublicKey();
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            try
            {
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new
                        Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        clearText = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return clearText;
            }
            catch (Exception)//Exception handled
            {
                return "";
            }
        }

        public static string Decrypt(string cipherText)
        {
            try
            {
                string EncryptionKey = GetPublicKey();
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new
                        Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
            catch (Exception)//Exception handled
            {
                return "";
            }
        }

        public static string EncryptPswd(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string key = "12356780QPXVLNGY";
                byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
                Aes tripleDES = new AesManaged();
                tripleDES.KeySize = 128;  // in bits    
                tripleDES.Key = new byte[128 / 8];  // 16 bytes for 128 bit encryption    
                tripleDES.IV = new byte[128 / 8];
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            else
            {
                return "";
            }
        }

        public static string DecryptPswd(string input)
        {
            try
            {
                string key = "12356780QPXVLNGY";
                byte[] inputArray = Convert.FromBase64String(input);
                Aes tripleDES = new AesManaged();
                tripleDES.KeySize = 128;          // in bits
                tripleDES.Key = new byte[128 / 8];  // 16 bytes for 128 bit encryption
                tripleDES.IV = new byte[128 / 8];
                tripleDES.Mode = CipherMode.CBC;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception)
            {
                return input;
            }
        }

        public static string GetPublicKey()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string EncryptionKey = "";
            foreach (NetworkInterface adapter in nics)
            {
                if (EncryptionKey == "")
                {
                    EncryptionKey = adapter.GetPhysicalAddress().ToString();
                }
            }
            return EncryptionKey;
        }

        public static String addEvalDays(double i_days)
        {
            try
            {
                String regKeyPath = @"Software\" + appName;

                RegistryKey regkey = Registry.CurrentUser;
                regkey = regkey.OpenSubKey(regKeyPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (regkey == null)
                {
                    // first time use
                    regkey = Registry.CurrentUser.CreateSubKey(regKeyPath);
                    firstTime(regkey);
                }
                try
                {
                    string Br = Decrypt((string)regkey.GetValue("Last"));
                    DateTime lastDate = DateTime.ParseExact(Br, "ddMMyyyy", CultureInfo.InvariantCulture);
                    lastDate = lastDate.AddDays(i_days);
                    regkey.SetValue("Last", Encrypt(lastDate.ToString("ddMMyyyy")));
                }
                catch (Exception)
                {
                    return "The Software Has Been Tampered. Reset It To Work !!!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";

        }

        public static void delAppKey()
        {
            String regKeyPath = @"Software\" + appName;

            RegistryKey regkey = Registry.CurrentUser;
            try
            {
                regkey.DeleteSubKey(regKeyPath);
            }
            catch (Exception)
            {

            }
        }
    }
}
