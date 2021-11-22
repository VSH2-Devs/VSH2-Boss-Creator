using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace vsh2_boss_creator
{
    public static class Data
    {
        public static string sAuthor = string.Empty;
        public static string sBossName = string.Empty;
        public static string sModelDir = string.Empty;
        public static string sSoundDir = string.Empty;
        public static string sSkinDir = string.Empty;
        public static string sModel = string.Empty;
        public static string sBossShortName = string.Empty;
        public static string sBossTallName = string.Empty;
        public static Dictionary<string, decimal> Intros = new Dictionary<string, decimal>();
        public static Dictionary<string, decimal> Themes = new Dictionary<string, decimal>();
        public static Dictionary<string, decimal> SoundTimings = new Dictionary<string, decimal>();
        public static ListBox.SelectedObjectCollection ThemesListbox;
        public static ListBox.SelectedObjectCollection IntrosListbox;

        private static void FormatData()
        {
            sBossShortName = sBossName.Replace(' ', '_').ToLower(); // replace the spaces with an underscore, The Punisher -> The_Punisher, then lowercases it, The_Punisher -> the_punisher
            sBossTallName = sBossName.Replace(" ", string.Empty); // replace the spaces with an empty string, The Punisher -> ThePunisher
        }

        public static bool IsValid()
        {
            FormatData();
            if (String.IsNullOrEmpty(sAuthor))
                return false;
            if (String.IsNullOrEmpty(sBossName))
                return false;
            if (String.IsNullOrEmpty(sModelDir))
                return false;
            if (String.IsNullOrEmpty(sSoundDir))
                return false;
            if (String.IsNullOrEmpty(sSkinDir))
                return false;
            if (String.IsNullOrEmpty(sModel))
                return false;
            return true;
        }

        public static string TrimPreText(string _from, string _input)
        {
            string ret = string.Empty;
            bool bCap = false;
            for (int i = 0; i < _from.Split('\\').Length; i++)
            {
                string s = _from.Split('\\')[i];
                if (s == _input)
                {
                    bCap = true;
                }
                if (bCap)
                {
                    ret += s;
                    if (i != _from.Split('\\').Length - 1)
                        ret += '/';
                }
            }
            ret = ret.Substring(0, ret.Length);
            return ret;
        }
    }
}
