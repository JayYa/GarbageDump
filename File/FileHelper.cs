using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 比较文件是否一致
        /// </summary>
        /// <param name="file1">文件1路径</param>
        /// <param name="file2">文件2路径</param>
        /// <returns>文件是否一致</returns>
        public static bool CompareFile(string file1, string file2)
        {
            if (file1 == file2)
            {
                return true;
            }

            using (FileStream fs1 = System.IO.File.Open(file1, FileMode.Open))
            {
                using (FileStream fs2 = System.IO.File.Open(file2, FileMode.Open))
                {
                    if (fs1.Length != fs2.Length)
                    {
                        return false;
                    }

                    const int BYTES_TO_READ = 1024 * 10;

                    byte[] one = new byte[BYTES_TO_READ];
                    byte[] two = new byte[BYTES_TO_READ];
                    while (true)
                    {
                        int len1 = fs1.Read(one, 0, BYTES_TO_READ);
                        int len2 = fs2.Read(two, 0, BYTES_TO_READ);

                        // 字节数组可直接转换为ReadOnlySpan
                        if (!((ReadOnlySpan<byte>)one).SequenceEqual(two))
                        {
                            return false;
                        }

                        // 两个文件都读取到了末尾，未找到不同，退出while循环
                        if (len1 == 0 || len2 == 0)
                        {
                            break;
                        }
                    }
                }
            }

            return true;
        }
    }
}