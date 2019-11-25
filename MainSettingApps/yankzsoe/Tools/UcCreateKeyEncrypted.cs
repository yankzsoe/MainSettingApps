using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainSettingApps.yankzsoe.Tools {
    public partial class UcCreateKeyEncrypted : UserControl {
        public UcCreateKeyEncrypted() {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e) {
            try {
                txtCipherText.Text = AesEncryption.EncryptString(EncryptedSettings.Key, txtPlainText.Text);
            } catch (Exception es) {
                MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
