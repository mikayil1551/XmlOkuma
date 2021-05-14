using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XmlOkuma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        XmlDocument doc;
        XmlNode haberler;
        private void Form1_Load(object sender, EventArgs e)
        {
            doc = new XmlDocument();
            doc.Load("..\\..\\Haberler.xml");
            haberler = doc.SelectSingleNode("haberler");
            //this.Text = haberler.SelectSingleNode("baslik").InnerText;
            lblAciklama.Text = string.Format(@"{0} - {1}", haberler.SelectSingleNode("aciklama").InnerText,
                haberler.SelectSingleNode("tarih").InnerText);

            XmlNodeList haberList = haberler.SelectNodes("haber");
            foreach (XmlNode haber in haberList)
            {
                listBasliklar.Items.Add(haber.SelectSingleNode("baslik").InnerText);                
            }
        }

        private void listBasliklar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string baslik = listBasliklar.SelectedItem.ToString();
            XmlNodeList haberList = haberler.SelectNodes("haber");
            foreach (XmlNode hbr in haberList)
            {
                string bsl = hbr.SelectSingleNode("baslik").InnerText;
                if (bsl==baslik)
                {
                    listAciklamalar.Items.Add(hbr.SelectSingleNode("aciklama").InnerText);
                }

            }

        }
    }
}
