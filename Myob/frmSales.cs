using ExpressCraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myob
{
    public class frmSales : Form
    {
        public SimpleButton btnClose;
        public SimpleButton btnPrint;
        public SimpleButton btnSendTo;
        public SimpleButton btnJournal;
        public SimpleButton btnLayout;
        public SimpleButton btnRegister;
        public EnumSearchInput comboSalesLookup;
        public SearchInput comboCustomerLookup;

        public Control ButtonPanel;
        public Control DataPanel;
        public Control InnerDataPanel;
        public Control InternalPanel;
        public Control RefPanel;


        public frmSales()
        {
            this.Text = "Sales - New Service";
            this.Size = new Vector2(875, 630);
            this.MinHeight = 630;
            this.MinWidth = 875;
            
            btnClose = new SimpleButton();
            btnClose.Text = "Close";
            btnClose.Size = new Vector2(73, 21);
            btnClose.Location = new Vector2("(100% - 89px)", "(100% - 31px)");

            ButtonPanel = new Control();
            ButtonPanel.Style.BackgroundColor = "white";
            ButtonPanel.Bounds = new Vector4(0, 0, "100%", 31);

            btnPrint = new SimpleButton() { Text = "Print", Enabled = false };
            btnPrint.ClassList.Remove("control");
            btnPrint.ClassList.Add("myob-btn");


            btnSendTo = new SimpleButton() { Text = "Send To", Enabled = false };
            btnSendTo.ClassList.Remove("control");
            btnSendTo.ClassList.Add("myob-btn");
            
            btnJournal = new SimpleButton() { Text = "Journal" };
            btnJournal.ClassList.Remove("control");
            btnJournal.ClassList.Add("myob-btn");

            btnRegister = new SimpleButton() { Text = "Register" };
            btnRegister.ClassList.Remove("control");
            btnRegister.ClassList.Add("myob-btn");

            ButtonPanel.AppendChildren(btnPrint, btnSendTo, btnJournal, btnRegister);

            StartPosition = FormStartPosition.Center;
            //112, 20
            comboSalesLookup = new EnumSearchInput(typeof(SalesType)) { Bounds = new Vector4(92, 44, 112, 20) };
            comboSalesLookup.SetValue((long)SalesType.Invoice, nameof(SalesType.Invoice));
            this.Body.AppendChild(Label("Sales Type:", 28, 47));

            // 822, 474
            DataPanel = new Control() { Bounds = new Vector4(16, 73, "(100% - 32px)", "(100% - 119px)") };
            DataPanel.ClassList.Add("form-base");
            DataPanel.Style.BorderRadius = "3px";
            DataPanel.Style.BackgroundColor = "white";
            DataPanel.Style.BorderColor = "rgb(192, 192, 192)";

            InnerDataPanel = new Control();
            InnerDataPanel.Style.Background = "linear-gradient(to bottom, #edf7ff 0%,#cee7fc 51%,#b8dbf9 100%)";
            InnerDataPanel.Style.BorderRadius = "3px";
            InnerDataPanel.Bounds = new Vector4(3, 3, "(100% - 8px)", "(100% - 8px)");            
            InnerDataPanel.Style.Border = "solid 1px rgb(192, 192, 192)";

            comboSalesLookup.OnTextChanged = (ti) => {
                if((ti.Text + "").Trim().ToLower() == nameof(SalesType.Quote).ToLower())
                {
                    InnerDataPanel.Style.Background = "linear-gradient(to bottom, #fedee1 0%,#faccd1 52%,#f6b7bf 100%)";
                }
                else
                {
                    InnerDataPanel.Style.Background = "linear-gradient(to bottom, #edf7ff 0%,#cee7fc 51%,#b8dbf9 100%)";
                }
            };

            comboCustomerLookup = new SearchInput();
            comboCustomerLookup.Location = new Vector2(167, 9);
            comboCustomerLookup.Size = new Vector2(250, 21);

            InternalPanel = new Control();
            InternalPanel.Style.BorderRadius = "1px";
            InternalPanel.Style.Border = "solid 1px rgb(192, 192, 192)";
            InternalPanel.Style.BackgroundColor = "white";
            InternalPanel.Bounds = new Vector4(19, 37, "(100% - 40px)", "(100% - 190px)" );


            RefPanel = new Control();
            RefPanel.Style.BorderRadius = "1px";
            RefPanel.Style.Border = "solid 1px rgb(192, 192, 192)";
            RefPanel.Style.BackgroundColor = "rgb(249, 242, 245)";
            RefPanel.Bounds = new Vector4(19, "(100% - 135px)", "(100% - 40px)", 96);

            InnerDataPanel.AppendChildren(comboCustomerLookup, InternalPanel, RefPanel);

            DataPanel.AppendChild(InnerDataPanel);
            
            this.AppendChildren(ButtonPanel, comboSalesLookup, DataPanel, btnClose);
        }
    }
}
