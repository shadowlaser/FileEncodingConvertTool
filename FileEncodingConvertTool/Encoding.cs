using System.Collections;
using System.IO;

namespace FECT
{
    internal class BossyEncoding
    {
        public int ConvertSrcFileEncoding2DestFileEncoding(string path, System.Text.Encoding src, System.Text.Encoding dest, bool bakFlag)
        {
            int retVal = 0;
            StreamReader sr = null;
            StreamWriter sw = null;
            try
            {
                if (src == null)
                {
                    src = GetFileEncoding(path);
                }
                sr = new StreamReader(path, src);
                sw = new StreamWriter(path + ".Bossy.tmp", true, dest);
                string oneline = sr.ReadLine();
                while (oneline != null)
                {
                    sw.WriteLine(oneline);
                    oneline = sr.ReadLine();
                }
            }
            catch (System.Exception)
            {
                retVal = -1;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
                try
                {
                    if (!bakFlag)
                    {
                        File.Delete(path);
                    }
                    else
                    {
                        File.Move(path, path + ".Bossy.bak");
                    }
                    File.Move(path + ".Bossy.tmp", path);
                }
                catch (System.Exception)
                {
                    retVal = -2;
                }
            }

            return retVal;
        }

        private System.Text.Encoding GetFileEncoding(string path)
        {
            throw new System.NotImplementedException();
        }

        public int ConvertFolder(string folderpath, ArrayList fileExtension, ArrayList srcEncodinglist, System.Text.Encoding destEncoding,bool bakFlag)
        {
            int retVal = 0;

            FileInfo[] filelist = new DirectoryInfo(folderpath).GetFiles();
            bool searchSrcEncoding = true;
            if (srcEncodinglist != null && srcEncodinglist.Count > 0)
            {
                searchSrcEncoding = true;
            }
            else
            {
                searchSrcEncoding = false;
            }

            foreach (FileInfo file in filelist)
            {
                if (searchSrcEncoding)
                {
                    if (fileExtension.Contains(Path.GetExtension(file.FullName)))
                    {

                        System.Text.Encoding srcEncoding = GetEncoding(file.FullName,srcEncodinglist);
                        if (srcEncoding != null)
                        {
                            ConvertSrcFileEncoding2DestFileEncoding(file.FullName, srcEncoding, destEncoding, bakFlag);
                        }
                    }
                }
                else
                {
                    ConvertSrcFileEncoding2DestFileEncoding(file.FullName, null, destEncoding, bakFlag);
                }
            }

            return retVal;
        }

        private System.Text.Encoding GetEncoding(string path, ArrayList srcEncodinglist)
        {
            System.Text.Encoding fileEncoding = null;
            fileEncoding = GetFileEncoding(path);
            bool pass = false;
            foreach (string enc in srcEncodinglist)
            {
                if (fileEncoding== GetStrEncodingRetEncoding(enc))
                {
                    pass = true;
                    break;
                }
            }
            if (!pass)
            {
                fileEncoding = null;
            }
            return fileEncoding;
        }

        private System.Text.Encoding GetStrEncodingRetEncoding(string enc)
        {
            System.Text.Encoding retVal;
            switch (enc.Trim().ToLower())
            {
                case "gb2312":
                    retVal = System.Text.Encoding.GetEncoding("gb2312");
                    break;
                case "utf8":
                case "utf-8"://有bom和无bom都可以出力
                    retVal = System.Text.Encoding.UTF8;
                    break;
                default:
                    retVal = System.Text.Encoding.Default;
                    break;
            }
            return retVal;
        }

 
    }
}