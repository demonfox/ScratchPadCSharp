using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ScratchPadCSharp
{
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
