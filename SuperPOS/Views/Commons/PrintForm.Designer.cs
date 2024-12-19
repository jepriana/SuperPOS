namespace SuperPOS.Views.Commons
{
    partial class PrintForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintForm));
            this.crystalReportViewerMain = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerMain
            // 
            this.crystalReportViewerMain.ActiveViewIndex = -1;
            this.crystalReportViewerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerMain.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerMain.Name = "crystalReportViewerMain";
            this.crystalReportViewerMain.Size = new System.Drawing.Size(784, 561);
            this.crystalReportViewerMain.TabIndex = 0;
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.crystalReportViewerMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerMain;
    }
}