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
         //   ClickOnreferencedItem(window, baseUiMap);
            ClickOnitem(window, baseUiMap);
            //ClickOnCreate(window, baseUiMap);


        }

        private void ClickOnOrder(UIMap map)
        {
            AutomationHelper.TapOnButton(map.UICodedUItestWindow1.UIOrderButton);

        }

        private void ClickOnCreate(XamlWindow window, UIMap map)
        {
           
           // AutomationHelper.TapOnButton(map.UICodedUItestWindow1.UIPersonsListList.UICREATEButton);

        }

        private void ClickOnreferencedItem(XamlWindow window, UIMap map)
        {
            AutomationHelper.TapOnButton(map.UICodedUItestWindow1.UIPersonsListList.UICodedUItestPersonListItem2.UIPressButton);

        }

        private XamlButton _buttonInList;
        private void ClickOnitem(XamlWindow window, UIMap map)
        {
            
                //var list = new XamlList(window);
                //list.SearchProperties[XamlControl.PropertyNames.AutomationId] = automationId;
                //list.WindowTitles.Add(DefaultSettings.MainWindowName);

                //return list;

            var list = UIMap.UICodedUItestWindow1.UIPersonsListList;
            foreach (UITestControl item in list.Items)
            {
                var typedItem = item as UICodedUItestPersonListItem;
                var buttpon = typedItem.UIPressButton;
            
               // AutomationHelper.TapOnButton(typedItem.UIPressButton);
            }
           

            //var control = new XamlControl(window);
            //control.SearchProperties.Add(XamlControl.PropertyNames.AutomationId,"Hello");
            //control.WindowTitles.Add("CodedUItest");

            //control.WaitForControlReady();
        
            //var x = control as XamlButton;

           // x.EnsureClickable();

            //UIPersonsListList listView = map.UICodedUItestWindow1.UIPersonsListList;
            //listView.WaitForControlReady();

            //listView.


            //_buttonInList = new XamlButton(UIMap.UICodedUItestWindow1);
            //_buttonInList.SearchProperties.Add(XamlWindow.PropertyNames.ControlType, "Button");
            //_buttonInList.SearchProperties.Add(XamlWindow.PropertyNames.AutomationId,"Joakim");

            //_buttonInList.WindowTitles.Add(window.Title);

            //AutomationHelper.TapOnButton(_buttonInList);

            //map.UICodedUItestWindow1.UIPersonsListList.SearchProperties.Add
            //    (XamlWindow.PropertyNames.ControlType, "Button");

            //map.UICodedUItestWindow1.UIPersonsListList.SearchProperties.Add(XamlWindow.PropertyNames.AutomationId,
            //    "Joakim");


            //map.UICodedUItestWindow1.UIPersonsListList.SearchProperties.Add
            //    (XamlWindow.PropertyNames.ControlType, "Button");

            //map.UICodedUItestWindow1.UIPersonsListList.SearchProperties.Add(XamlWindow.PropertyNames.AutomationId,
            //    "Joakim");

            //var listView = map.UICodedUItestWindow1.UIPersonsListList;
            //listView.WaitForControlReady();
            
     
            //var mUIYoupiButton1 = new XamlButton(this);
            //#region Search Criteria
            //mUIYoupiButton1.SearchProperties[XamlButton.PropertyNames.Name] = "Youpi !";
            //mUIYoupiButton1.SearchProperties[XamlButton.PropertyNames.Instance] = "2";
            //mUIYoupiButton1.WindowTitles.Add("MainWindow");
            //#endregion

            //return mUIYoupiButton1;
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
