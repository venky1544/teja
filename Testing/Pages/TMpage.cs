using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Testing.Utilities;





namespace Testing.Pages
{
    public class TMpage
    {
       
        public void CreateTM(IWebDriver driver)
        {
            IWebElement createnewbutton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createnewbutton.Click();

            // select material from TypeCode dropdown

            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            IWebElement materialoption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));

            //identify Code textbox and input code
            IWebElement Codetextbox = driver.FindElement(By.Id("Code"));
            Codetextbox.SendKeys("Teja");

            // identify Description textbox and input description

            IWebElement Descriptiontextbox = driver.FindElement(By.Id("Description"));
            Descriptiontextbox.SendKeys("Testing");

            // identify Price per unit textbox
            IWebElement Priceperunit = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            Priceperunit.SendKeys("1401");

            // ckick Save button
            IWebElement Savebutton = driver.FindElement(By.Id("SaveButton"));
            Savebutton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 20);

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 20);
            
            // click on Go to last page button


            IWebElement Gotolastpagebutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));

            Gotolastpagebutton.Click();

            
            //check if the record created present in the table and has expected values

           
        }


        public string Getcode(IWebDriver driver)
        {
            IWebElement Actualcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return Actualcode.Text;
        }
        public string GetTypecode(IWebDriver driver)
        {
            IWebElement ActualTypecode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));

            return ActualTypecode.Text;
        }

        public string GetDescription(IWebDriver driver)
        {
            IWebElement ActualDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));

            return ActualDescription.Text;
        }
        public string GetPrice(IWebDriver driver)
        {
            IWebElement ActualPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return ActualPrice.Text;
        }




        public void EditTM(IWebDriver driver, string Description, string Code, string Price)

        {
            // Wait until the entire TM page is displayed


            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 20);



            // click on Go to last page button


            IWebElement Gotolastpagebutton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));

            Gotolastpagebutton1.Click();

            Thread.Sleep(4000);
            


            // Find the Created Record

            IWebElement Createdrecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (Createdrecord.Text == "Teja")
            {

             IWebElement SelectEdit = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr/td[5]/a[1]"));
             SelectEdit.Click();
            }
            else
            {
                Assert.That(Createdrecord.Text == "Test Failed");

            }

            // identify code textbox

            IWebElement EditedCode = driver.FindElement(By.Id("Code"));
            EditedCode.Clear();

            EditedCode.SendKeys(Code);

            //Edit Description Textbox

            IWebElement EditDescription = driver.FindElement(By.Id("Description"));
            EditDescription.Clear();
            EditDescription.SendKeys(Description);

            //Edit Pric per Unit Textbox

            IWebElement EditPriceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement PriceTextbox = driver.FindElement(By.Id("Price"));

            EditPriceTag.Click();

            PriceTextbox.Clear();

            EditPriceTag.Click();

            PriceTextbox.SendKeys(Price);


            // Click on Save button

            IWebElement SaveEdit = driver.FindElement(By.Id("SaveButton"));
            SaveEdit.Click();

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 20);

            //Go to last page
            IWebElement Gotolastpageicon = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));

            Gotolastpageicon.Click();

            //Check if the Created record is edited or not


            IWebElement EditedTypecode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));





            Assert.That(EditedTypecode.Text == "M", "Actual Typecode do not match");





        }

        public string GetEditDescription(IWebDriver driver)
        {
            IWebElement EditedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return EditedDescription.Text;
        }
        public string GetEditCode(IWebDriver driver)
        {
            IWebElement Editedcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return Editedcode.Text;
        }
        public string GetEditPrice(IWebDriver driver)
        {
            IWebElement EditedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return EditedPrice.Text;
        }




        public void DeleteTM(IWebDriver driver)
        {
            //Delete the Created page


            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 20);

            // click on Go To last page 

            IWebElement Gotolastpagebutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));

            Gotolastpagebutton.Click();

            // Find the Created Record

            IWebElement FindtheEditedrecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (FindtheEditedrecord.Text == "Mangam")
            {
                // click on delete button

                IWebElement Deletebutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                Deletebutton.Click();

                driver.SwitchTo().Alert().Accept();
            }
            else
            {
                Assert.Fail("Record to be deleted hasn't found. Record not deleted");

            }
            // Assert that the edit record has been deleted

            driver.Navigate().Refresh();

            IWebElement Gotolastpageicon = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));

            Gotolastpageicon.Click();

            //Check if the Created record is deleted or not

            // IWebElement Editedcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            //IWebElement EditedTypecode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            // IWebElement EditedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            // IWebElement EditedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));


            // Assert.That(Editedcode.Text != "Mangam", "Actual code hasn't been deleted");
            // Assert.That(EditedTypecode.Text != "M", "Actual Typecode hasn't been deleted");
            //Assert.That(EditedDescription.Text != "NewTest", "Actual Description hasn't been deleted");
            //Assert.That(EditedPrice.Text != "$123.00", "Actual Price hasn't been deleted");
























        }


    }
}
   


