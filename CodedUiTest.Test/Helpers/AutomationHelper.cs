using System;
using System.Linq;
using System.Text.RegularExpressions;
using IKEA.SalesCoworker.CodedUI.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;

namespace IKEA.SalesCoworker.CodedUI.Tests.Helpers
{
    //TODO: Use extensions instead
    public static class AutomationHelper
    {
        public static string GetDataRowValue(System.Data.DataRow dataRow, string key)
        {
            var dataRowValue = dataRow[key].ToString();

            //To be able to use special characters
            return dataRowValue.Replace("'", "");
        }

        public static void WaitForListToLoad(XamlList list)
        {
            list.WaitForControlReady();
            list.WaitForControlEnabled();
            list.WaitForControlExist();
        }

        public static bool IsListLoadedAndEmpty(XamlList list)
        {
            WaitForListToLoad(list);
            return !list.Items.Any();
        }

        public static bool HasListItems(XamlList list)
        {
            WaitForListToLoad(list);
          
            list.WaitForControlCondition(x => ((XamlList) x).Items.Any(), (int)TimeSpan.FromMinutes(5).TotalMilliseconds);
            return list.Items.Any();
        }

        public static XamlListItem GetFirstItemInList(XamlList list)
        {
            if (!HasListItems(list))
            {
                return null;
            }
            return list.Items.FirstOrDefault() as XamlListItem;
        }
        

        public static XamlListItem GetItemInList(XamlList list,string text)
        {
            if (!HasListItems(list))
            {
                return null;
            }
            foreach (var item in list.Items)
            {
                var listItem = item as XamlListItem;
                
                if (listItem == null)
                {
                   continue;
                }
                if (ItemExistItemViaText(listItem, text))
                {
                    return listItem;
                }
            }
            return list.Items.FirstOrDefault(i => ItemExistItemViaText(list,text)) as XamlListItem;
        }

        public static XamlControl GetControlInList(XamlList list, string text)
        {
            
            if (!HasListItems(list))
            {
                return null;
            }
            foreach (var item in list.Items)
            {
                var listItem = item as XamlListItem;

                if (listItem == null)
                {
                    continue;
                }
                if (ItemExistItemViaText(listItem, text))
                {
                    return listItem;
                }
            }
            return list.Items.FirstOrDefault(i => ItemExistItemViaText(list, text)) as XamlListItem;
        }

        public static bool TapOnItemInList(XamlList list, XamlListItem listItem)
        {
            if (!HasListItems(list))
            {
                return false;
            }

            if (listItem == null)
            {
                return false;
            }

            listItem.EnsureClickable();
            Gesture.Tap(listItem);
            return true;
        }
        public static void TapOnButton(XamlButton button)
        {
            bool isReady = button.WaitForControlReady(1000);

            button.EnsureClickable();

            if (isReady)
            {
                 Gesture.Tap(button);
            }

        }

        public static void TapOnMenuItem(XamlMenuItem menuItem)
        {
            bool isReady = menuItem.WaitForControlReady(1000);

            menuItem.EnsureClickable();

            if (isReady)
            {
                Gesture.Tap(menuItem);
            }

        }

        public static bool TapOnHyperLink(XamlHyperlink hyperLink)
        {
            bool isReady = hyperLink.WaitForControlReady(1000);

            
            if (!isReady)
            {
                return false;
            }
            hyperLink.EnsureClickable();

            Gesture.Tap(hyperLink);
            return true;
        }

        public static bool ChangeSwitch(XamlToggleSwitch switchControl)
        {
            bool isReady = switchControl.WaitForControlReady(1000);
            if (!isReady)
            {
                return false;
            }
            switchControl.EnsureClickable();
            Gesture.Tap(switchControl);
            return true;
        }

        public static bool SelectPivotItem(XamlPivotItem pivotItem)
        {
            bool isReady = pivotItem.WaitForControlReady(1000);
            if (!isReady)
            {
                return false;
            }
            pivotItem.EnsureClickable();
            pivotItem.Select();
           // Gesture.Tap(pivotItem);

            return true;
        }

        public static void TypeInTextBox(XamlEdit control, string text)
        {
            control.EnsureClickable();
            Keyboard.SendKeys(control, text);
            control.WaitForControlCondition(x => ((XamlEdit)x).Text == text);
            Keyboard.SendKeys(control, "{ENTER}");
        }

        public static bool TextLabelContains(XamlText control, string text)
        {
            control.WaitForControlEnabled();
            control.EnsureClickable();
            return control.DisplayText.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static int GetItemCountFromList(XamlList list)
        {
            if (HasListItems(list))
            {
                return 0;
            }
            return list.Items.Count;
        }

        public static XamlListItem GetItemFromIndexInList(XamlList list, int index)
        {
            if (HasListItems(list))
            {
                return null;
            }
            int itemsCount = GetItemCountFromList(list);
            if((itemsCount-1 < index))
            {
                return null;
            }
            return list.Items[index] as XamlListItem;
        }


        public static bool SelectExactValueInComboBox(XamlComboBox comboBox,string value)
        {
            comboBox.EnsureClickable();
            return SelectValueInComboBox(comboBox, x => x.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        public static bool SelectValueInComboBox(XamlComboBox comboBox, Func<string,bool> match  )
        {
            comboBox.EnsureClickable();
            return SelectValueInComboBox(comboBox, listItem => match(listItem?.DisplayText));
        }

        public static bool SelectValueInComboBox(XamlComboBox comboBox, Func<XamlListItem, bool> match)
        {
            if (!comboBox.WaitForReady())
            {
                return false;
            }
            if (!comboBox.WaitForControlEnabled())
            {
                return false;
            }
            comboBox.EnsureClickable();
            var itemToSelect = comboBox.Items.FirstOrDefault(c =>
            {
                var listItem = c as XamlListItem;
                return listItem != null && match(listItem);
            });

            if (itemToSelect == null)
            {
                return false;
            }
            comboBox.SelectedItem = (itemToSelect as XamlListItem)?.DisplayText;

            //TODO : Remove!
            Playback.Wait(2000);

            return true;
        }

        public static XamlListItem GetListItemFromGroupedListByText(XamlList groupedList, string searchFor)
        {
            WaitForListToLoad(groupedList);

            var groupChildren = groupedList.GetChildren();

            if (groupChildren == null)
            {
                return null;
            }

            foreach (var group in groupChildren)
            {
                var listItemChildren = group.GetChildren();


                foreach (var listItemChild in listItemChildren)
                {
                    var currentItem = listItemChild as XamlListItem;
                    
                    if (ItemExistItemViaText(currentItem, searchFor))
                    {
                        return currentItem;
                    }
                }
            }

            return null;
        }

        //public static UITestControl GetControlByAutomationId(string automationId, UITestControl parent)
        //{
        //    foreach (var child in parent.GetChildren())
        //    {
        //        foreach (var subChild in child.GetChildren())
        //        {
        //            var controlToSearchFor = new UITestControl(subChild)
        //            {
        //                TechnologyName = "UIA"
        //            };


        //            // controlToSearchFor.SearchProperties.Add("ControlType", "Text");
        //            controlToSearchFor.SearchProperties.Add("AutomationId", automationId);
        //            controlToSearchFor.SearchProperties.Add("FrameworkId", "XAML");

        //            var match = controlToSearchFor.Exists;

        //            if (match)
        //            {
        //                return controlToSearchFor;
        //            }
        //        }
        //    }

        //    return null;
        //}

        //public static XamlControl GetControlByText(string searchFor, XamlList parent)
        //{
        //    var childItems = parent.Items;

        //    foreach (var item in childItems)
        //    {
        //        var currentItem = item as XamlListItem;
        //        var control = GetControlFromItem(item, searchFor);
        //        if(control == null)
        //        {
        //            continue;
        //        }
        //        return control;
        //    }
        //    return null;
        //}

        //public static XamlListItem GetListItemByText(string searchFor, XamlList parent, bool useRegex)
        //{
        //    var childItems = parent.Items;

        //    foreach (var item in childItems)
        //    {
        //        var currentItem = item as XamlListItem;
        //        if (ItemExistItemViaText(item, searchFor))
        //        {
        //            return currentItem;
        //        }
        //    }
        //    return null;
        //}

        //public static XamlListItem GetListGroupListItem(XamlList list, string groupName)
        //{
        //    WaitForListToLoad(list);
     
        //    if (!list.WaitForControlReady())
        //    {
        //        return null;
        //    }
        //    return GetListItemByText(groupName, list, false);
        //}

        public static bool IsMatch(string text, string pattern, bool useRegex)
        {
            if (useRegex)
            {
                return Regex.IsMatch(text, pattern);
            }
            return string.Equals(text, pattern, StringComparison.CurrentCultureIgnoreCase) || text.ToLower().Contains(pattern.ToLower());
        }

       

       public static bool TapOnButtonWithAutomationId(UITestControl parent, string automationId)
        {
            var button = GetUiTestControl(parent, control =>
            {
                var b = control as XamlButton;
                if (b == null)
                {
                    return false;
                }
                if (!b.AutomationId.Equals(automationId,StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }
                return true;
            }) as XamlButton;

            if(button == null)
            {
                return false;
            }

            TapOnButton(button);
            return true;
        }

        public static UITestControl GetUiTestControl(UITestControl control,
             Func<UITestControl,bool> validation)
        {
            if(control == null)
            {
                return null;
            }
            bool result = validation(control);
            if(result)
            {
                return control;
            }
            var childControls = control.GetChildren();
            if(childControls == null)
            {
                return null;
            }
            if (childControls.Count > 0)
            {
                foreach (UITestControl childControl in childControls)
                {
                    var resultFromLoop = GetUiTestControl(childControl, validation);
                    if (resultFromLoop == null)
                    {
                        continue;
                    }
                    return resultFromLoop;

                }
            }
            return null;
        }


        public static bool ItemExistItemViaText(UITestControl parentControl,string searchFor)
        {
            var textBox = parentControl as XamlText;
            if (textBox != null)
            {
                if (IsMatch(textBox.DisplayText, searchFor, false))
                {
                    return true;
                }
            }
            var hyperLink = parentControl as XamlHyperlink;
            if (hyperLink != null)
            {
                if (IsMatch(hyperLink.Name, searchFor, false))
                {
                    return true;
                }
            }
            else
            {
                var childControls = parentControl.GetChildren();
                if (childControls.Count > 0)
                {
                    foreach (var childControl in childControls)
                    {
                        if (ItemExistItemViaText(childControl,searchFor))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
 