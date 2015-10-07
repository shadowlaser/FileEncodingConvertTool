using System;
using System.Collections;
using System.IO;
using System.Text;

namespace FECT
{
    internal class EncodeUtils
    {
        private Encoding sE = null;
        private Encoding dE = null;

        
        public static bool ConvertFileEncoding(string path, Encoding sEncode, Encoding dEncode)
        {
            bool retVal = true;
            StreamReader sr = null;
            StreamWriter sw = null;

            if (sEncode == null)
            {
                sEncode = EncodingType.GetFileEncodeType(path);
            }
            try
            {
                sr = new StreamReader(path, sEncode);
                sw = new StreamWriter(path + ".Bossy.tmp", true, dEncode);
                string oneline = sr.ReadLine();
                while (oneline != null)
                {
                    sw.WriteLine(oneline);
                    oneline = sr.ReadLine();
                }
            }
            catch (Exception ex)
            {
                retVal = false;
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
            }

            //File.Move(path + ".Bossy.tmp", path);

            return retVal;
        }

        //public int ConvertFolder(string folderpath, ArrayList fileExtension, ArrayList srcEncodinglist, Encoding destEncoding, bool bakFlag)
        //{
        //    int retVal = 0;

        //    FileInfo[] filelist = new DirectoryInfo(folderpath).GetFiles();
        //    bool searchSrcEncoding = true;
        //    if (srcEncodinglist != null && srcEncodinglist.Count > 0)
        //    {
        //        searchSrcEncoding = true;
        //    }
        //    else
        //    {
        //        searchSrcEncoding = false;
        //    }

        //    foreach (FileInfo file in filelist)
        //    {
        //        if (searchSrcEncoding)
        //        {
        //            if (fileExtension.Contains(Path.GetExtension(file.FullName)))
        //            {
        //                Encoding srcEncoding = GetEncoding(file.FullName, srcEncodinglist);
        //                if (srcEncoding != null)
        //                {
        //                    ConvertFileEncoding(file.FullName, srcEncoding, destEncoding);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ConvertFileEncoding(file.FullName, null, destEncoding);
        //        }
        //        if (!bakFlag)
        //        {
        //            File.Delete(file.FullName);
        //        }
        //        else
        //        {
        //            File.Move(file.FullName, file.FullName + ".Bossy.bak");
        //        }
        //    }

        //    return retVal;
        //}


        private Encoding GetStrEncodingRetEncoding(string enc)
        {
            Encoding retVal;
            switch (enc.Trim().ToLower())
            {
                case "gb2312":
                    retVal = Encoding.GetEncoding("gb2312");
                    break;

                case "utf8":
                case "utf-8"://有bom和无bom都可以出力
                    retVal = Encoding.UTF8;
                    break;

                default:
                    retVal = Encoding.Default;
                    break;
            }
            return retVal;
        }
    }
}