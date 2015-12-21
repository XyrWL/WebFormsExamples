using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox
{
    public static class StateSaver
    {
        public static bool IsAwaitingNextInput { get; set; }
        public static string CurrentOperation { get; set; } = "=";
        public static double CurrentTotal { get; set; }
    }
}