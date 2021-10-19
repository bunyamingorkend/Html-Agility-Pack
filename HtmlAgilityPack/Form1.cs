using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
namespace HtmlAgilityPack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string link = "http://emreakkaya.com.tr/";
            Uri url = new Uri(link);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);

            var secilenhtml = @"//*[@id=""categories-3""]/ul";
            StringBuilder st = new StringBuilder();
            var secilenHrmlList = document.DocumentNode.SelectNodes(secilenhtml);

            foreach (var items in secilenHrmlList)
            {
                foreach (var innerItem in items.SelectNodes("li"))
                {
                    foreach (var item in innerItem.SelectNodes("a//span"))
                    {
                        var classValue = item.Attributes["class"] == null ? null : item.Attributes["class"].Value;
                        st.AppendLine(item.InnerText);
                    }

                }
            }
            resultTxt.Text = st.ToString();
        }
        

    }
    
}

