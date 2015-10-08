using System;
using System.Collections;
using System.IO;
using System.Text;

namespace FECT
{
    internal class EncodeUtils
    {
        //需要转换的文件的编码格式
        private ArrayList encodings = new ArrayList();

        //需要转换的文件扩展名
        private ArrayList extensions = new ArrayList();

        //转换后的编码格式
        private Encoding dEncode = Encoding.Default;

        public EncodeUtils SetEncodings(ArrayList encodings)
        {
            this.encodings = encodings;
            return this;
        }

        public EncodeUtils AddEncode(Encoding encode)
        {
            encodings.Add(encode);
            return this;
        }

        public EncodeUtils SetExtensions(ArrayList extensions)
        {
            this.extensions = extensions;
            return this;
        }

        public EncodeUtils AddExtension(string ext)
        {
            extensions.Add(ext);
            return this;
        }

        public EncodeUtils SetDestEncode(Encoding encode)
        {
            dEncode = encode;
            return this;
        }

        /// <summary>
        /// 转换单个文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="sEncode"></param>
        /// <param name="dEncode"></param>
        /// <returns></returns>
        public bool ConvertFileEncoding(string path, Encoding sEncode)
        {
            bool retVal = true;
            StreamReader sr = null;
            StreamWriter sw = null;

            if (sEncode == null)
            {
                //如果没有指定源文件的编码格式，则获取文件本身的编码格式
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
            return retVal;
        }

        /// <summary>
        /// 处理文件夹
        /// </summary>
        /// <param name="folders"></param>
        /// <param name="encoding"></param>
        /// <param name="extension"></param>
        public void ConvertFolders(ArrayList folders)
        {
            foreach (string folder in folders)
            {
                ConvertFiles(new DirectoryInfo(folder).GetFiles());
            }
        }

        /// <summary>
        /// 判断当前的文件是否是指定编码格式
        /// 如果encodings的个数是0，那么返回true
        /// </summary>
        /// <param name="file"></param>
        /// <param name="encodings"></param>
        /// <returns></returns>
        private bool IsEncoding(FileInfo file)
        {
            bool retVal = true;
            if (encodings.Count > 0 && !encodings.Contains(EncodingType.GetFileEncodeType(file.FullName)))
            {
                retVal = false;
            }
            return retVal;
        }

        /// <summary>
        /// 判断是否当前文件的扩展名
        /// 如果extensions的个数是0，那么返回true
        /// </summary>
        /// <param name="file"></param>
        /// <param name="extensions"></param>
        /// <returns></returns>
        private bool IsExtension(FileInfo file)
        {
            bool retVal = true;
            if (extensions.Count > 0 && !extensions.Contains(file.Extension))
            {
                retVal = false;
            }
            return retVal;
        }

        /// <summary>
        /// 处理多个文件
        /// </summary>
        /// <param name="files"></param>
        /// <param name="encodings"></param>
        /// <param name="extensions"></param>
        public void ConvertFiles(FileInfo[] files)
        {
            foreach (FileInfo file in files)
            {
                if (IsEncoding(file) && IsExtension(file))
                {
                    ConvertFileEncoding(file.FullName, null);
                }
            }
        }
    }
}