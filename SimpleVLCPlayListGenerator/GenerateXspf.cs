using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Configuration;

namespace SimpleVLCPlayListGenerator
{
    internal abstract class GenerateXspf
    {
        public GenerateXspf(){}

        /// <summary>
        /// exeのカレントディレクトリのファイルを対象にしてプレイリストを作成。
        /// Generate playlist(.xspf) with files in exe current directory.
        /// </summary>
        public void Generate()
        {
            XNamespace ns = @"http://xspf.org/ns/0/";
            XNamespace nsVlc = @"http://www.videolan.org/vlc/playlist/ns/0/";

            //xmlファイル作成
            var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "true"),
                            new XElement(ns + "playlist", new XAttribute("xmlns", ns), new XAttribute(XNamespace.Xmlns + "vlc", nsVlc), new XAttribute("version", "1"),
                                new XElement(ns + "title", "プレイリスト"),
                                    new XElement(ns + "trackList",
                                        GetLocationPathList().Select(x =>
                                            new XElement(ns + "track",
                                                new XElement(ns + "location", x))))));

            //xmlファイルをxspfとして保存 ( save xml as xspf. )
            xDoc.Save(ConfigurationManager.AppSettings["PlayListName"] + ".xspf");
        }

        /// <summary>
        /// LocationPathリスト取得
        /// Get files location path
        /// </summary>
        /// <returns>LocationPathリスト</returns>
        protected abstract IEnumerable<string> GetLocationPathList();
    }
}
