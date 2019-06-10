using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Notification
{
    public partial class Kufar_Note : Form
    {
        IWebDriver Browser;


        public Kufar_Note()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("https://re.kufar.by/");

            
            //while(true)
            //{ 
            WebDriverWait ww = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));

            

            IWebElement SearchCity = Browser.FindElement(By.CssSelector("[value]"));
            SearchCity.SendKeys("Минск");

            //System.Threading.Thread.Sleep(5000);

            IWebElement element = ww.Until(ExpectedConditions.ElementIsVisible(By.Id("react-autowhatever-1--item-1")));
            element.Click();

            IWebElement price = ww.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[data-name='price_filter']")));
            price.Click();

            IWebElement max_price = Browser.FindElement(By.Id("prc_max"));
            max_price.SendKeys("86000");


            IWebElement search_select = Browser.FindElement(By.CssSelector("[data-name='button_search']"));
            search_select.Click();

            List<IWebElement> Flat = Browser.FindElements(By.CssSelector("#content> div._3OvBa._2SxM3 > div.t1n7P > div.atMFB._3OvBa._17d3o._2wUH0")).ToList();

            for (int i=0; i<Flat.Count;i++)
            {
                
                    textBox1.AppendText(Flat[i].Text + '\r' + '\n');
               
            }
                //System.Threading.Thread.Sleep(10000);
                //Browser.Navigate().GoToUrl("https://re.kufar.by/");
                
            }


        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
