using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVLCPlayListGenerator
{
    public static class LocationPath
    {
        /// <summary>
        /// Location用のファイルPath変換
        /// </summary>
        /// <param name="path">ファイルpath</param>
        /// <returns>Location用のファイルPath</returns>
        public static string Encode(string path)
        {
            return Uri.EscapeUriString(("file:///" + path).Replace('\\', '/')); //本当はutf8に変換するのが正しいっぽい
        }
    }

}
