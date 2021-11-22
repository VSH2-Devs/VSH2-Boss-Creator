using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace vsh2_boss_creator
{
    public class FileCreator
    {
        public static void Create()
        {
            if (Data.IsValid())
            {
                string sText = Encoding.UTF8.GetString(Properties.Resources.Sample);
                sText = sText.Replace("{{Author}}", Data.sAuthor);
                sText = sText.Replace("{{BossName}}", Data.sBossTallName);
                sText = sText.Replace("{{BossModel}}", Data.sModel);
                sText = sText.Replace("{{ModelFolder}}", Data.TrimPreText(Data.sModelDir, "models"));
                string sTemp = string.Empty;
                if (Data.IntrosListbox != null)
                {
                    if (Data.IntrosListbox.Count > 0)
                    {
                        foreach (object x in Data.IntrosListbox)
                        {
                            sTemp += "\t" + x.ToString() + ",\n";
                        }
                        sText = sText.Replace("{{Intros}}", sTemp);
                        sTemp = string.Empty;
                    }
                    else
                    {
                        sText = sText.Replace("{{Themes}}", string.Empty);
                    }
                }
                if (Data.ThemesListbox != null)
                {
                    if (Data.ThemesListbox.Count > 0)
                    {
                        foreach (object x in Data.ThemesListbox)
                        {
                            sTemp += "\t" + x.ToString() + ",\n";
                        }
                        sText = sText.Replace("{{Themes}}", sTemp);
                        sTemp = string.Empty;
                    }
                    else
                    {
                        sText = sText.Replace("{{Themes}}", string.Empty);
                    }
                }
                foreach (KeyValuePair<string, decimal> timing in Data.SoundTimings)
                {
                    sTemp += "\t" + timing.Value + ",\n";
                }
                sText = sText.Replace("{{Timings}}", sTemp);
                sTemp = string.Empty;
                string[] files = Directory.GetFiles(Data.sSkinDir);
                if (files.Length > 0)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (i != 0)
                            sTemp += "\t";
                        sTemp += "PrepareMaterial(\"" + Data.TrimPreText(files[i], "materials") + "\");\n";
                    }
                    sText = sText.Replace("{{Skins}}", sTemp);
                    sTemp = String.Empty;
                }
                else
                {
                    sText = sText.Replace("{{Skins}}", string.Empty);
                }
                File.WriteAllText(Data.sBossShortName + ".sp", sText);
            }
            else
            {
                Program.CreateErrorNotification("Invalid data");
            }
        }
    }
}
