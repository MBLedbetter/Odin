using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdinModels
{
    public static class DbUtil
    {
        #region Methods

        /// <summary>
        ///     Alphabetizes list of strings
        /// </summary>
        /// <param name="var">list of strings</param>
        /// <returns>alphabetized list of strings</returns>
        public static List<string> Alphabetize(List<string> var)
        {
            List<string> values = new List<string>();
            var.Sort();
            foreach (string s in var)
            {
                values.Add(s);
            }
            return values;
        }

        /// <summary>
        ///     Returns msrp as decimal, if msrp (in case of CAN) is null default to US msrp
        /// </summary>
        /// <param name="msrp"></param>
        /// <param name="msrp2"></param>
        /// <returns></returns>
        public static decimal AssignMsrp(string msrp, string msrp2)
        {
            if (string.IsNullOrEmpty(msrp))
            {
                return Convert.ToDecimal(msrp2);
            }
            else return Convert.ToDecimal(msrp);
        }

        public static string Char10(string value)
        {
            string str10 = value;
            if (value.Length > 10)
            {
                str10 = value.Substring(0, 9);
            }
            return str10;
        }

        public static string Char30(string value)
        {
            string str30 = value;
            if (value.Length > 30)
            {
                str30 = value.Substring(0, 29);
            }
            return str30;
        }

        public static string Char60(string value)
        {
            string str60 = value;
            if (value.Length > 60)
            {
                str60 = value.Substring(0, 59);
            }
            return str60;
        }
        /// <summary>
        ///     Checks if a given value is greater than 0.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if greater than 0</returns>
        public static bool CheckGreaterThanZero(string value)
        {
            if (decimal.TryParse(value, out decimal valueDec))
            {
                if (valueDec > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Checks length of string without whitespaces. Returns false if string excedes the maximum limit
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minLength"></param>
        /// <returns></returns>
        public static bool CheckMaximum(string value, int maxLength)
        {
            string noSpaceValue = value.Replace(" ", "");
            int length = noSpaceValue.Length;

            if (length > maxLength)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Checks length of string without whitespaces. Returns false if string doesn't have minimum character amount
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minLength"></param>
        /// <returns></returns>
        public static bool CheckMinimum(string value, int minLength)
        {
            string noSpaceValue = value.Replace(" ", "");
            int length = noSpaceValue.Length;

            if (length < minLength)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Checks that input only conatins letters
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ContainsOnlyAZ(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (!(value[i] >= 'A' && value[i] <= 'Z'))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///     Checks input for non alphanumeric values
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ContainsOnlyAZ09(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (!((value[i] >= '0' && value[i] <= '9') || (value[i] >= 'A' && value[i] <= 'Z')))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///     Converts Y or N into bool
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ConvertToBool(string value)
        {
            if (value.Trim().ToUpper() == "Y")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Converts items weight from lbs to mls
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertToMilliliters(string weight)
        {
            string result = string.Empty;

            if (DbUtil.IsNumber(weight))
            {
                double num = Convert.ToDouble(weight);
                num = num / 0.002204622621848776;
                num = Math.Round(num, 4);
                result = num.ToString();
            }
            else
            {
                result = "Is Not Number";
            }
            return result;
        }

        /// <summary>
        ///     Converts bool into Y or N
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertYN(bool value)
        {
            if(value)
            {
                return "Y";
            }
            return "N";
        }

        /// <summary>
        ///     Removes the time from the end of the datetime.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DateTrim(string date)
        {
            string[] x = date.Split(' ');
            return x[0];
        }

        /// <summary>
        ///     Checks if the value is a number (int or decimal)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumber(string value)
        {
            bool returnValue = false;
            
            if (int.TryParse(value, out int valueInt))
            {
                returnValue = true;
            }

            if (decimal.TryParse(value, out decimal valueDec))
            {
                returnValue = true;
            }
            return returnValue;
        }

        /// <summary>
        ///     Puts Language values in order for uniformity and validation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string OrderLanguage(string value)
        {
            string output = string.Empty;
            if (!string.IsNullOrEmpty(value))
            {
                if (value.ToUpper().Contains("ENG") || value.ToUpper().Contains("ENGLISH")) { output += "ENG/"; }
                if (value.ToUpper().Contains("FRA") || value.ToUpper().Contains("FRE") || value.ToUpper().Contains("FRENCH")) { output += "FRA/"; }
                if (value.ToUpper().Contains("SPA") || value.ToUpper().Contains("SPANISH")) { output += "SPA/"; }
                if (output.Length > 1)
                {
                    output = output.Remove(output.Length - 1);
                }
            }
            if(output == string.Empty)
            {
                output = value;
            }
            return output;
        }

        /// <summary>
        ///     Puts Territory values in order for uniformity and validation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string OrderTerritory(string value)
        {
            if (string.IsNullOrEmpty(value)) { return ""; }
            string output = string.Empty;
            if (!string.IsNullOrEmpty(value))
            {
                if (value.ToUpper() == "WW" || value.ToUpper() == "WORLDWIDE") { return "WW"; }

                if (value.ToUpper().Contains("USA") || value.ToUpper() == "UNITED STATES") { output += "USA/"; }
                if (value.ToUpper().Contains("CAN") || value.ToUpper() == "CANADA") { output += "CAN/"; }
                if (value.ToUpper().Contains("MEX") || value.ToUpper() == "MEXICO") { output += "MEX/"; }
                if (value.ToUpper().Contains("AUS") || value.ToUpper() == "AUSTRALIA") { output += "AUS/"; }
                if (value.ToUpper().Contains("NZL") || value.ToUpper() == "NEW ZEALAND") { output += "NZL/"; }
                if (output.Length > 1)
                {
                    output = output.Remove(output.Length - 1);
                }
            }
            if (output == string.Empty)
            {
                output = value;
            }
            return output;
        }

        /// <summary>
        ///     Breaks up string of numerical Ids by ',' and returns list of matched category values
        /// </summary>
        /// <param name="list">List of category strings</param>
        /// <returns></returns>
        public static List<string> ParseCategories(string list)
        {
            List<string> Categories = new List<string>();
            string[] categoryIds = list.Split(',');
            foreach (string key in categoryIds)
            {
                if (GlobalData.WebCategoryList.ContainsKey(key))
                {
                    Categories.Add(GlobalData.WebCategoryList[key]);
                }
            }
            return Categories;
        }

        /// <summary>
        ///     Splits comma deliminated string into list of child elements
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static ObservableCollection<ChildElement> ParseChildElements(string parentId, string list)
        {
            ObservableCollection<ChildElement> result = new ObservableCollection<ChildElement>();
            if (!string.IsNullOrEmpty(list))
            {
                string[] groupings = list.Split(',');
                foreach (string childString in groupings)
                {
                    string[] z = childString.Split('&');
                    int amount = 1;
                    if (IsNumber(z[1]))
                    {
                        z[1] = z[1].Replace(".0000", "");
                        amount = Convert.ToInt32(z[1]);
                    }
                    ChildElement child = new ChildElement(z[0].Trim(), parentId, amount);
                    result.Add(child);
                }
            }
            return result;
        }

        /// <summary>
        ///     Replace fancy quotes and apostrophes with regular quotes and apostrophes.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReplaceCharacters(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                string newValue;
                newValue = text.Replace("“", "''");
                newValue = text.Replace("\"", "''");
                newValue = newValue.Replace("”", "''");
                newValue = newValue.Replace("‘", "'");
                newValue = newValue.Replace("’", "'");
                newValue = newValue.Replace('–', '-');
                return newValue;
            }
            return text;
        }

        /// <summary>
        ///     Converts quotes to double apostrophes
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        public static string ReplaceQuotes(string var)
        {
            return var.Replace("\"", "''");
        }

        /// <summary>
        ///     Rounds values to 2 decimal places
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string RoundValue2Dec(string i)
        {
            if (string.IsNullOrEmpty(i)) { return ""; }
            string num = "";
            string dec = "";
            if (i.Contains('.'))
            {
                string[] split = i.Split('.');
                num = split[0];
                if (split[1].Count() > 2)
                {
                    dec = split[1].Substring(0, 2);
                    return num + "." + dec;
                }
            }
            return i;
        }

        /// <summary>
        ///     Rounds values to 4 decimal places
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string RoundValue4Dec(string i)
        {
            if (string.IsNullOrEmpty(i)) { return ""; }
            string num = "";
            string dec = "";
            if (i.Contains('.'))
            {
                string[] split = i.Split('.');
                num = split[0];
                if (split[1].Count() > 4)
                {
                    dec = split[1].Substring(0, 4);
                    return num + "." + dec;
                }
            }
            return i;
        }
        
        /// <summary>
        ///     Remove the time from datatime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string StripDateTime(string date)
        {
            if (date != "")
            {
                string[] x = date.Split(' ');
                return x[0];
            }
            else return "";
        }

        public static decimal ToDecimal(string value)
        {
            if (IsNumber(value))
            {
                return !string.IsNullOrEmpty(value) ? Convert.ToDecimal(value) : 0.00m;
            }
            else
            {
                return 0.00m;
            }
        }

        /// <summary>
        ///     Converts the given value to a short. Returns 0 if value is empty.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short ToShort(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return 0;
            }
            return Convert.ToInt16(value);
        }

        /// <summary>
        ///     Strips the time off the end of datetime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime StripTime(object value)
        {
            DateTime date = Convert.ToDateTime(value);
            return date.Date;
            
            /*
            string date = string.Empty;
            if (value != DBNull.Value)
            {
                date = value.ToString();
                if(date.Length>10)
                {
                    return date.Substring(0,10);
                }
                return date;
            }
            return "";
            */
        }

        /// <summary>
        ///     Uppercases the first character of a string, lowercases the rest
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="text"></param>
        /// <param name="zeroCount">number of 0's to leave</param>
        /// <returns></returns>
        public static string ZeroTrim(string text, int zeroCount)
        {
            if(text == "") { return text; }
            string value = text.Trim();
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Contains("."))
                {
                    while (value.EndsWith("0"))
                    {
                        value = value.Remove(value.Length - 1, 1);
                    }
                    if (value.EndsWith("."))
                    {
                        if (zeroCount == 1)
                        {
                            value += "0";
                        }
                        else
                        {
                            value += "00";
                        }
                    }
                    if ((value.Length - value.IndexOf(".") - 1) == 1 && zeroCount == 2)
                    {
                        value += "0";
                    }
                }
                else
                {
                    if (zeroCount == 1)
                    {
                        value += ".0";
                    }
                    else
                    {
                        value += ".00";
                    }
                }

            }
            return value;
        }

        #endregion // Methods
    }
}
