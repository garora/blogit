using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogit.utility
{
    public class HashTable
    {
        public static Hashtable Htable = new Hashtable();

        public static string FindKey(string Value, Hashtable HT)
        {
            string Key = "";
            IDictionaryEnumerator e = HT.GetEnumerator();
            while (e.MoveNext())
            {
                if (e.Value.ToString().Equals(Value))
                {
                    Key = e.Key.ToString();
                }
            }
            return Key;
        }

        public static string FindSingleValue(string Key, Hashtable HT)
        {
            string strRes = string.Empty;
            if ((Key != null) && (HT.ContainsKey(Key)))
                strRes = HT[Key].ToString();
            return strRes;
        }
        public static bool MatchKey(string Key, Hashtable HT)
        {
            bool blnRes = false;
            if ((Key != null) && (HT.ContainsKey(Key)))
                blnRes = true;
            return blnRes;

        }
        public static bool MatchKey(string[] Keys, Hashtable HT)
        {
            bool blnRes = false;
            int length = Keys.Length;
            for (int i = 0; i < length; i++)
            {
                if ((Keys[i] != null) && (HT.ContainsKey(Keys[i])))
                    blnRes = true;
            }

            return blnRes;

        }

        public static void RemoveItem(string Key, Hashtable HT)
        {
            HT.Remove(Key);
        }
    }
}
