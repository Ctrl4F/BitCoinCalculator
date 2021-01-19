using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitCoinCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(currencyMenu.SelectedItem.ToString() == "EUR")
            {
                resultLbl.Visable = true;
                Result.Visable = true;
                BitCoinRate resultRates = GetRates();
                int userCoins = Int32.Parse(amountOfBtc.Text);
                float currentRate = resultRates.bpi.EUR.rate_float;
                float btc btcResult = userCoins * currentRate;
                Result.Text = $"{btcResult} {resultRates.bpi.EUR.code}";
            }
        }
        public static BitCoinRate GetRate()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request = (HttWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            BitCoinRate bitcoin;
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseSteam();
            using(var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<BitCoinRate>(response);
            }
            return bitcoin;
        }
    }
}
