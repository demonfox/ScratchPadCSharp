using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ScratchPad
{
    class Subnet
    {
        string Address;
        int Prefix;

        public Subnet(string address, int prefix)
        {
            Address = address;
            Prefix = prefix;

            try
            {
                // Validate that the subnet was created correctly
                var subnet = GetSubnetMaskAddressFromPrefixLength(Prefix);
                if (Address.Equals(GetMaskedAddress(IPAddress.Parse(Address), subnet).ToString()) == false)
                {
                    throw new ArgumentException("Invalid address specified for the prefix");
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid subnet specified", e);
            }
        }

        public Subnet(string subnet)
        {
            bool validSubnet = false;
            if (!string.IsNullOrEmpty(subnet))
            {
                string[] subnetParts = subnet.Split(new char[] { '/' });
                if (subnetParts.Length == 2)
                {
                    IPAddress address;
                    int prefix;
                    if ((IPAddress.TryParse(subnetParts[0], out address)) &&
                        (int.TryParse(subnetParts[1], out prefix)) &&
                        (prefix >= 0 && prefix <= 32))
                    {
                        this.Address = subnetParts[0];
                        this.Prefix = prefix;
                        validSubnet = true;
                    }
                }
            }
            if (!validSubnet)
            {
                throw new ArgumentException("Invalid subnet specified");
            }
        }

        public static IPAddress GetSubnetMaskAddressFromPrefixLength(int prefix)
        {
            if (prefix <= 0 || prefix > 32)
            {
                throw new ArgumentException("Invalid prefix length {0} ", prefix.ToString());
            }

            byte[] mask = new byte[4];

            for (int i = 0; i < 4 && prefix > 0; i++)
            {
                byte flag = 0xff;
                if (prefix > 8)
                {
                    mask[i] |= flag;
                }
                else
                {
                    mask[i] |= (byte)(flag << (8 - prefix));
                }
                prefix -= 8;
            }

            return new IPAddress(mask);
        }

        public static IPAddress GetMaskedAddress(IPAddress address, IPAddress subnet)
        {
            byte[] addressBytes = address.GetAddressBytes();
            byte[] subnetBytes = subnet.GetAddressBytes();

            byte[] nwAddress = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                nwAddress[i] = (byte)(addressBytes[i] & (subnetBytes[i]));
            }
            return new IPAddress(nwAddress);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            //EinsteinProblem.Run();

            //int result = 1024 / 5 + 1024 / 25 + 1024 / 125 + 1024 / 625;

            //long num = 34534594058;
            //long mark = 0x1;

            //int i = -1000;
            //Console.WriteLine(Convert.ToString(i, 2));
            //Console.WriteLine(Convert.ToString(i >> 3, 2));
            //Console.WriteLine(i >> 3);

            //StringBuilder result = new StringBuilder();

            MissingTerm.FindMissingTerm();

            //Tree t = new Tree();
            //t.InitTree();
            //t.PrintVTree();
            //t.BuildTree(new int[] { 1, 2, 3, 5, 7, 10, 12, 17, 24 });
            //t.FindLevelLinkList();
            //t.PrintVTree();
            //Console.WriteLine(result);
            //double result = Power.Run(2.0, 32);
            //Console.WriteLine("Result: {0}, Complexity: {1}", result, Power.totalNumMultiplication);
            //FileRenamer.Run("Z:\\TV\\科教\\大国崛起", new string[] { ".the.rise.of.great.nations.2006.bluray.720p.x264.ac3-hdiy" });
            //Subnet test = new Subnet("192.168.201.1/24");
            //test.ToString();
            //string testString = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Cisco>ASR</Cisco>";
            //Stream vpnDeviceConfigScriptStream = new MemoryStream(Encoding.UTF8.GetBytes(testString.ToCharArray()));
            //vpnDeviceConfigScriptStream.Position = 0;
            //StreamReader vpnDeviceConfigScriptReader = new StreamReader(vpnDeviceConfigScriptStream);
            //string configScript = vpnDeviceConfigScriptReader.ReadToEnd();
            //Console.WriteLine(configScript);
//            Log.WriteLine("Stream returned by the method is - {0}", configScript);

        }
    }
}
