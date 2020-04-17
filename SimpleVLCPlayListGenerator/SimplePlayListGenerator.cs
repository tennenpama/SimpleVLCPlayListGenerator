using System;
using System.Windows.Forms;

namespace SimpleVLCPlayListGenerator
{
    public partial class SimplePlayListGenerator : Form
    {
        public SimplePlayListGenerator()
        {
            InitializeComponent();
        }

        private void SimplePlayListGenerator_Load(object sender, EventArgs e)
        {
            GenerateXspf xspfGenerator = new GenerateXspfCurrentDirectoryLnk();
            xspfGenerator.Generate();

            MessageBox.Show("プレイリストが作成されました！！", "(´・ω・｀)");

            this.Close();
        }
    }
}
