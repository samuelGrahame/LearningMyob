using Bridge.Html5;
using ExpressCraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myob
{
    public class Program
    {
        public static void Main()
        {
            Settings.AllowCloseWithoutQuestion = true;
            Document.Body.Style.BackgroundColor = "rgb(172, 172, 172)";
            Document.Head.AppendChild(new HTMLStyleElement() {
                InnerHTML =
@".myob-btn
{
    height: 100% !important;
    width: auto;
    background-color: Transparent;
    border-color: Transparent;
    border-radius: 0;
}
.myob-btn:hover
{
    background-color: rgb(179, 215, 243);
    border-color: rgb(0, 120, 215);
    filter: none !important;
}

"
            });

            Application.Run(new frmSales());
        }
    }
}
