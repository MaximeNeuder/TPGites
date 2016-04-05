namespace requetesLinq
{
    partial class Fm_principal
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_requete = new System.Windows.Forms.ComboBox();
            this.bt_ok = new System.Windows.Forms.Button();
            this.tb_resultat = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cb_requete
            // 
            this.cb_requete.FormattingEnabled = true;
            this.cb_requete.Location = new System.Drawing.Point(12, 26);
            this.cb_requete.Name = "cb_requete";
            this.cb_requete.Size = new System.Drawing.Size(659, 21);
            this.cb_requete.TabIndex = 0;
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(718, 26);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 1;
            this.bt_ok.Text = "ok";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // tb_resultat
            // 
            this.tb_resultat.Location = new System.Drawing.Point(12, 66);
            this.tb_resultat.Name = "tb_resultat";
            this.tb_resultat.Size = new System.Drawing.Size(659, 169);
            this.tb_resultat.TabIndex = 2;
            this.tb_resultat.Text = "";
            // 
            // Fm_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 274);
            this.Controls.Add(this.tb_resultat);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.cb_requete);
            this.Name = "Fm_principal";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_requete;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.RichTextBox tb_resultat;
    }
}

