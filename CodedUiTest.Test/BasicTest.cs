using System;
using IKEA.SalesCoworker.CodedUI.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Linq;
using System.Diagnostics;

namespace CodedUiTest.Test
{
    /// <summary>
    /// Summary description for CodedUITest3
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class BasicTest
    {
        public BasicTest()
        {
        }


        [TestMethod]
        public void TestMetest()
        {
            string appId = "44c5756c-9fed-4add-bca4-252fbdffa171_gecswmz8y675e!App";

           
            var window = XamlWindow.Launch(appId);
            window.CloseOnPlaybackCleanup = false;

            var baseUiMap = new UIMap();
            baseUiMap.UICodedUItestWindow.WaitForControlReady();


            ClickOnOrder(baseUiMap);

            ClickOnReferencedListItem(baseUiMap);

            ClickOnitem(baseUiMap);

            ClickOnLastListItem(baseUiMap);

            ClickOnCreate(window, baseUiMap);
        }

        private void ClickOnOrder(UIMap map)
        {
            AutomationHelper.TapOnButton(map.UICodedUItestWindow1.UIOrderButton);
        }

        private void ClickOnCreate(XamlWindow window, UIMap map)
        {
            var parent = UIMap.UICodedUItestWindow1.UIPersonsListList;
            var l = parent as XamlList;

            
            var w = UIMap.UICodedUItestWindow1.BoundingRectangle;

            
       //     Mouse.Click(new Point(964, 915));
            //Mouse.Click(new Point(988, 939));

            //var l = parent as XamlList;

            //int bottom = parent.BoundingRectangle.Bottom;
            //int right = parent.BoundingRectangle.Right;


            //Mouse.Location = new Point(right - 48, bottom -48);

          
            string automationId = "CreateButton";
            var button = AutomationHelper.GetUiTestControl(parent.Container.TopParent, control =>
            {
                var b = control as UITestControl;
                if (b == null)
                {
                    return false;
                }
                Debug.WriteLine(b.Name);

                var x = b as XamlControl;
                if (!x.AutomationId.Equals(automationId, StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
                return true;
            }) as XamlButton;

            //Assert.IsNotNull(button);

            //AutomationHelper.TapOnButton(button);

        }

        private void ClickOnReferencedListItem(UIMap map)
        {
            AutomationHelper.TapOnButton(map.UICodedUItestWindow1.UIPersonsListList.UICodedUItestPersonListItem2.UIPressButton);

        }

        private void ClickOnLastListItem(UIMap map)
        {
            var list = UIMap.UICodedUItestWindow1.UIPersonsListList;
            var lastItem = list.Items.Last();

            var button = AutomationHelper.GetUiTestControl(lastItem, control =>
            {

                var b = control as XamlButton;
                if (b == null)
                {
                    return false;
                }
                return true;
            }) as XamlButton;

            Assert.IsNotNull(button);


            AutomationHelper.TapOnButton(button);

        }

        private void ClickOnitem(UIMap map)
        {
            
            var list = UIMap.UICodedUItestWindow1.UIPersonsListList;

            AutomationHelper.TapOnButtonWithAutomationId(list, "Joakim");
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
