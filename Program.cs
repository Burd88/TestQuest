using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace TestQuest
{
    class Program
    {
        private static IWebDriver driver = new ChromeDriver();
        private static readonly By _logInButton = By.XPath("//span[text()='Личный кабинет']");
        private static readonly By _demobutton = By.XPath("//a[text()='Демо-версия']");
        private static readonly By _linkImage = By.XPath("//a[@class='UserInfo_photo__2bWyM']");
        private static readonly By _image = By.XPath("//*[@class='UserInfo_defaultAvatar__3dWDS']");
        private static readonly By _summ = By.XPath("//span[@class='nowrap main-page_title_sum']");
        
        static void Main(string[] args)
        {
            Step1();
            Thread.Sleep(1000);
            Step2();
            Thread.Sleep(1000);
            Step3();
            Thread.Sleep(1000);
            Step4();
            Thread.Sleep(1000);
            Step41();
            Thread.Sleep(1000);
            Step5();
            Thread.Sleep(1000);
            Step6();
            Console.ReadLine();
        }
        
        private static void Step1()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.nalog.ru/");
                driver.Manage().Window.Maximize();
                Console.WriteLine("Step1 Succses");

            }
            catch(Exception e)
            {
                Console.WriteLine("Step1 Fail");
                Console.WriteLine(e.Message);
            }
            
        }

        private static void Step2()
        {
            try
            {
                var logIn = driver.FindElement(_logInButton);
                logIn.Click();
                Console.WriteLine("Step2 Succses");
            }
            catch (Exception e)
            {
                Console.WriteLine("Step2 Fail");
                Console.WriteLine(e.Message);
            }

        }
        private static void Step3()
        {
            try
            {
                var demo = driver.FindElement(_demobutton);
                demo.Click();
                Console.WriteLine("Step3 Succses");
            }
            catch (Exception e)
            {
                Console.WriteLine("Step3 Fail");
                Console.WriteLine(e.Message);
            }

        }

        private static void Step4()//Размер ссылки-кнопки
        {
            try
            {
                var image = driver.FindElement(_linkImage);
               var imageWidth = Convert.ToInt32(image.GetCssValue("width").Replace("px",""));
                var imageHeight = Convert.ToInt32(image.GetCssValue("height").Replace("px", ""));
                if (imageWidth == 31 && imageHeight == 31)
                {
                    Console.WriteLine("Step4 Succses");
                }
                else
                {
                    Console.WriteLine($"Step4 fail. Incorrect image size: {imageWidth}x{imageHeight}");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Step4 Fail");
                Console.WriteLine(e.Message);
            }

        }
        private static void Step41()//Размер изображения
        {
            try
            {
                var image = driver.FindElement(_image);
                var imageWidth = Convert.ToInt32(image.GetAttribute("width"));
                var imageHeight = Convert.ToInt32(image.GetAttribute("height"));
                if (imageWidth == 31 && imageHeight == 31)
                {
                    Console.WriteLine("Step41 Succses");
                }
                else
                {
                    Console.WriteLine($"Step41 fail. Incorrect image size: {imageWidth}x{imageHeight}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Step41 Fail");
                Console.WriteLine(e.Message);
            }

        }

        private static void Step5()
        {
            try
            {
                var summa = driver.FindElement(_summ);
                
                double summStr = Convert.ToDouble(summa.Text.Replace(" ", "").Replace(".",","));
               
                if (summStr < 200000.00 && summStr > 0)
                {
                    Console.WriteLine("Step5 Succses");
                }
                else
                {
                    Console.WriteLine("Step5 Fail" + "/nSumm not correct" + summStr);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Step5 Fail");
                Console.WriteLine(e.Message);
            }

        }
        private static void Step6()
        {
            try
            {
               driver.Close();
               driver.Quit();
                
                var check = isCheckProcess("chrome");
                if (!check == true)
                {
                    Console.WriteLine("Step6 Succses");
                }
                else
                {
                    Console.WriteLine("Step6 Fail ");
                }
                    
              

            }
            catch (Exception e)
            {
                Console.WriteLine("Step6 Fail");
                Console.WriteLine(e.Message);
            }

        }

        private static bool isCheckProcess(string pName)
        {
            Process[] pList = Process.GetProcesses();
            foreach (Process myProcess in pList)
            {
                if (myProcess.ProcessName == pName)
                    return true;
            }
            return false;
        }
       
    }
}
