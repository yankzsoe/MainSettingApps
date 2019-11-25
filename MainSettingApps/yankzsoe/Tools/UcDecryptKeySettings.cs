using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainSettingApps.yankzsoe.Tools {
    public partial class UcDecryptKeySettings : UserControl {
        public UcDecryptKeySettings() {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e) {
            try {
                txtPlainText.Text = AesEncryption.DecryptString(EncryptedSettings.Key, txtCipherText.Text);
            } catch (Exception es) {
                MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
