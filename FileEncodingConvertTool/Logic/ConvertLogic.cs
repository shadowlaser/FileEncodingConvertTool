using FECT.OutputHandler;
using FECT.ParameterHandler;
using System;
using System.Collections;
using System.IO;
using System.Text;

namespace FECT
{
    internal class ConvertLogic
    {
        ////需要转换的文件的编码格式
        //private ArrayList encodings = new ArrayList();

        ////需要转换的文件扩展名
        //private ArrayList extensions = new ArrayList();

        ////转换后的编码格式
        //private Encoding dEncode = Encoding.Default;

        ////备份标记
        //private bool bakFlag = false;

        private IOutput msg;

        private readonly IParameters p;

        public ConvertLogic(IParameters p, IOutput msg)
        {
            this.p = p;
            this.msg = msg;
        }

        //public ConvertLogic SetFiles(string[] files)
        //{
        //    if (files != null)
        //    {
        //        this.files = new ArrayList(files);
        //    }
        //    return this;
        //}

        //public ConvertLogic SetDirs(string[] folders)
        //{
        //    if (folders != null)
        //    {
        //        this.folders = new ArrayList(folders);
        //    }
        //    return this;
        //}

        //public ConvertLogic BackupOriginFiles(bool isBak)
        //{
        //    this.bakFlag = isBak;
        //    return this;
        //}

        ///// <summary>
        ///// 设置需要转化的文件的编码格式集合
        ///// </summary>
        ///// <param name="encodings"></param>
        ///// <returns></returns>
        //public ConvertLogic SetEncodings(ArrayList encodings)
        //{
        //    this.encodings = encodings;
        //    return this;
        //}

        ///// <summary>
        ///// 添加转化的文件的编码格式
        ///// </summary>
        ///// <param name="encode"></param>
        ///// <returns></returns>
        //public ConvertLogic AddEncode(Encoding encode)
        //{
        //    encodings.Add(encode);
        //    return this;
        //}

        ///// <summary>
        ///// 设置需要转换的文件扩展名的集合
        ///// </summary>
        ///// <param name="extensions"></param>
        ///// <returns></returns>
        //public ConvertLogic SetExtensions(string[] extensions)
        //{
        //    if (extensions != null)
        //    {
        //        this.extensions = new ArrayList(extensions);
        //    }
        //    return this;
        //}

        ///// <summary>
        ///// 添加需要转换的文件的扩展名
        ///// </summary>
        ///// <param name="ext"></param>
        ///// <returns></returns>
        //public ConvertLogic AddExtension(string ext)
        //{
        //    extensions.Add(ext);
        //    return this;
        //}

        ///// <summary>
        ///// 设置要转化成的目标文件格式
        ///// </summary>
        ///// <param name="encode"></param>
        ///// <returns></returns>
        //public ConvertLogic SetDestEncode(Encoding encode)
        //{
        //    dEncode = encode;
        //    return this;
        //}

        /// <summary>
        /// 转换单个文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="sEncode"></param>
        /// <param name="dEncode"></param>
        /// <returns></returns>
        public bool ConvertFileEncoding(string path, string dPath, Encoding sEncode = null)
        {
            bool retVal = true;

            if (sEncode == null)
            {
                //如果没有指定源文件的编码格式，则获取文件本身的编码格式
                sEncode = EncodingType.GetFileEncodeType(path);
            }
            //文件的格式和指定格式不一致
            if (sEncode != EncodingType.Encode(p.GetDestEncode()))
            {
                retVal = ConvertStream(path, sEncode, dPath);
            }
            return retVal;
        }

        /// <summary>
        /// 源文件到目标文件转换
        /// </summary>
        /// <param name="sPath"></param>
        /// <param name="sEncode"></param>
        /// <param name="dPath"></param>
        /// <returns></returns>
        private bool ConvertStream(string sPath, Encoding sEncode, string dPath)
        {
            bool retVal = true;
            StreamReader sr = null;
            StreamWriter sw = null;
            try
            {
                sr = new StreamReader(sPath, sEncode);
                sw = new StreamWriter(dPath, true, EncodingType.Encode(p.GetDestEncode()));
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
        /// 判断当前的文件是否是指定编码格式
        /// 如果encodings的个数是0，那么返回true
        /// </summary>
        /// <param name="file"></param>
        /// <param name="encodings"></param>
        /// <returns></returns>
        private bool IsEncoding(FileInfo file)
        {
            bool retVal = true;
            ArrayList srcEncodes = p.GetSrcEncodes();
            if (srcEncodes.Count > 0 && !srcEncodes.Contains(EncodingType.GetFileEncodeType(file.FullName)))
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
            ArrayList extensions = p.GetExts();
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
                ConvertFile(file);
            }
        }

        public void ConvertFiles(ArrayList files)
        {
            foreach (string strFile in files)
            {
                FileInfo file = new FileInfo(strFile);
                ConvertFile(file);
            }
        }

        public void ConvertFile(FileInfo file)
        {
            string dFilePath = file.FullName + ".tmp";
            string sFilePath = file.FullName;
            if (IsEncoding(file) && IsExtension(file))
            {
                bool convertFlag = ConvertFileEncoding(sFilePath, dFilePath, null);

                //转换成功
                if (convertFlag)
                {
                    if (p.GetBackUp())//备份
                    {
                        File.Move(sFilePath, sFilePath + ".bak");
                    }
                    else
                    {
                        File.Delete(sFilePath);
                    }
                    File.Move(dFilePath, sFilePath);
                    msg.WriteMsg(string.Format("[成功]：{0}", file.FullName));
                }
                else
                {
                    msg.WriteMsg(string.Format("[失败]：{0}", file.FullName));
                }
            }
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

        public void Convert()
        {
            ArrayList files = p.GetFiles();
            if (files.Count > 0)
            {
                ConvertFiles(files);
            }
            ArrayList folders = p.GetDirectorys();
            if (folders.Count > 0)
            {
                ConvertFolders(folders);
            }
        }
    }
}