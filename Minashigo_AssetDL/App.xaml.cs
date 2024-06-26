﻿using System;
using System.Collections.Generic;
using System.Windows;

namespace Minashigo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string Root = Environment.CurrentDirectory;
        public static string Respath = String.Empty;
        public static int TotalCount = 0;
        public static int glocount = 0;
        public static string version = "2.4.133";
        public static string ServerURL = "https://minasigo-no-shigoto-pd-c-res.orphans-order.com/";
        public static string VersionUrl = "https://minasigo-no-shigoto-web-r-server.orphans-order.com/mnsg/user/getVersion";
        public static List<string> log = new List<string>();
    }
}
