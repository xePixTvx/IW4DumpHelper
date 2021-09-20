using System;

namespace IW4DumpHelperGUI
{
    class Program
    {
        private static IW4DumpHelper DumpHelperApp;

        static void Main(string[] args)
        {
            DumpHelperApp = new IW4DumpHelper("data", "GUI TESTING YAY!", 1280, 720);
            DumpHelperApp.Start();
        }
    }
}
