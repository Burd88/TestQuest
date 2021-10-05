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
            Test1();
            Thread.Sleep(1000);
            Test2();
            Thread.Sleep(1000);
            Test3();
            Thread.Sleep(1000);
            Test4();
            Thread.Sleep(1000);
            Test41();
            Thread.Sleep(1000);
            Test5();
            Thread.Sleep(1000);
            Test6();
            Console.ReadLine();
        }
        
        private static void Test1()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.nalog.ru/");
                driver.Manage().Window.Maximize();
                Console.WriteLine("Test1 Succses");

            }
            catch(Exception e)
            {
                Console.WriteLine("Test1 Fail");
                Console.WriteLine(e.Message);
            }
            
        }

        private static void Test2()
        {
            try
            {
                var logIn = driver.FindElement(_logInButton);
                logIn.Click();
                Console.WriteLine("Test2 Succses");
            }
            catch (Exception e)
            {
                Console.WriteLine("Test2 Fail");
                Console.WriteLine(e.Message);
            }

        }
        private static void Test3()
        {
            try
            {
                var demo = driver.FindElement(_demobutton);
                demo.Click();
                Console.WriteLine("Test3 Succses");
            }
            catch (Exception e)
            {
                Console.WriteLine("Test3 Fail");
                Console.WriteLine(e.Message);
            }

        }

        private static void Test4()//Размер ссылки-кнопки
        {
            try
            {
                var image = driver.FindElement(_linkImage);
               var imageWidth = Convert.ToInt32(image.GetCssValue("width").Replace("px",""));
                var imageHeight = Convert.ToInt32(image.GetCssValue("height").Replace("px", ""));
                if (imageWidth == 31 && imageHeight == 31)
                {
                    Console.WriteLine("Test4 Succses");
                }
                else
                {
                    Console.WriteLine($"Test4 fail. Incorrect image size: {imageWidth}x{imageHeight}");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Test4 Fail");
                Console.WriteLine(e.Message);
            }

        }
        private static void Test41()//Размер изображения
        {
            try
            {
                var image = driver.FindElement(_image);
                var imageWidth = Convert.ToInt32(image.GetAttribute("width"));
                var imageHeight = Convert.ToInt32(image.GetAttribute("height"));
                if (imageWidth == 31 && imageHeight == 31)
                {
                    Console.WriteLine("Test41 Succses");
                }
                else
                {
                    Console.WriteLine($"Test41 fail. Incorrect image size: {imageWidth}x{imageHeight}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Test41 Fail");
                Console.WriteLine(e.Message);
            }

        }

        private static void Test5()
        {
            try
            {
                var summa = driver.FindElement(_summ);
                
                double summStr = Convert.ToDouble(summa.Text.Replace(" ", "").Replace(".",","));
               
                if (summStr < 200000.00 && summStr > 0)
                {
                    Console.WriteLine("Test5 Succses");
                }
                else
                {
                    Console.WriteLine("Test5 Fail" + "/nSumm not correct" + summStr);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Test5 Fail");
                Console.WriteLine(e.Message);
            }

        }
        private static void Test6()
        {
            try
            {
               driver.Close();
               driver.Quit();
                
                var check = isCheckProcess("chrome");
                if (!check == true)
                {
                    Console.WriteLine("Test6 Succses");
                }
                else
                {
                    Console.WriteLine("Test6 Fail");
                }
                    
              

            }
            catch (Exception e)
            {
                Console.WriteLine("Test6 Fail");
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
