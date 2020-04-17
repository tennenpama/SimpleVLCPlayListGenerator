using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;

namespace SimpleVLCPlayListGenerator
{
    internal class GenerateXspfCurrentDirectoryLnk : GenerateXspf
    {
        /// <summary>
        /// カレントディレクトリに含まれる対象ファイルのLoacationPathリストを取得する
        /// </summary>
        /// <returns>LoacationPathリスト</returns>
        protected override IEnumerable<string> GetLocationPathList()
        {
            string[] extensions = { ".lnk" };

            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());

            IEnumerable<FileInfo> fileInfoList = di.GetFiles("*.*", SearchOption.AllDirectories).Where(x => extensions.Contains(x.Extension));

            List<string> filePath = new List<string>();

            foreach (var item in fileInfoList)
            {
                //LoacationPathに変換
                filePath.Add(LocationPath.Encode(GetLinkPath(item.FullName)));
            }

            return filePath;
        }

        /// <summary>
        /// ショートカットファイルのリンクPathを取得する。(´・ω・｀)
        /// </summary>
        /// <param name="fullPath">ファイルPath</param>
        /// <returns>ファイルPath</returns>
        private string GetLinkPath(string fullPath)
        {
            dynamic shell = null;   // IWshRuntimeLibrary.WshShell
            dynamic lnk = null;     // IWshRuntimeLibrary.IWshShortcut
            try
            {
                var type = Type.GetTypeFromProgID("WScript.Shell");
                shell = Activator.CreateInstance(type);
                lnk = shell.CreateShortcut(fullPath);

                return lnk.TargetPath;
            }
            finally
            {
                if (lnk != null) Marshal.ReleaseComObject(lnk);
                if (shell != null) Marshal.ReleaseComObject(shell);
            }
        }

    }
}
