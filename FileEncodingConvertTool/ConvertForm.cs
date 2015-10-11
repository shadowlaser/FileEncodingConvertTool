using System.Windows.Forms;

namespace FECT
{
    public partial class ConvertForm : Form
    {
        public ConvertForm()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, System.EventArgs e)
        {
            if (txtFolder.Text.Trim() == "")
            {
                MessageBox.Show("文件夹路径不能为空！", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDEncode.Text.Trim() == "")
            {
                MessageBox.Show("目标编码格式不能为空！", null, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EncodeUtils eu = new EncodeUtils();
            eu.SetDestEncode(EncodingType.Encode(txtDEncode.Text.Trim()))
               .BackupOriginFiles(backup.Checked)
               .SetDirs(new string[]{txtFolder.Text.Trim()});

            eu.Convert();
        }
    }
}