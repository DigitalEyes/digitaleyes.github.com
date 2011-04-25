using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DigitalEyes
{
    public class Tag
    {
        public string pathNext, pathLast, contDirNext, contDirLast, content;
        public string name;
        public string type;

        public Tag()
        {
            pathNext = "";
            pathLast = "";
            contDirNext = "";
            contDirLast = "";
            content = "";
            type = "";
        }
        public Tag(string n)
        {
            name = n;
            content = "";
            pathNext = "";
            pathLast = "";
            contDirLast = "";
            contDirNext = "";
            type = "";
        }
        public Tag(string n, string nextDir, string lastDir)
        {
            name = n;
            nextDir = pathNext;
            lastDir = pathLast;
            contDirNext = "";
            contDirLast = "";
            content = "";
            type = "";
        }
    }
}
