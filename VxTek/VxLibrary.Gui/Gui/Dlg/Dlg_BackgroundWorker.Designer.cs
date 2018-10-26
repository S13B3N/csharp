namespace VxLibraryData.Gui.Gui.Dlg
{
   partial class Dlg_BackgroundWorker
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose ( bool disposing )
      {
         if ( disposing && ( components != null ) )
         {
            components.Dispose ();
         }
         base.Dispose ( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent ()
      {
         this.m_pbProgress = new System.Windows.Forms.ProgressBar();
         this.m_btnAbort = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // m_pbProgress
         // 
         this.m_pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.m_pbProgress.Location = new System.Drawing.Point(12, 12);
         this.m_pbProgress.Name = "m_pbProgress";
         this.m_pbProgress.Size = new System.Drawing.Size(338, 30);
         this.m_pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
         this.m_pbProgress.TabIndex = 0;
         // 
         // m_btnAbort
         // 
         this.m_btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.m_btnAbort.Location = new System.Drawing.Point(275, 48);
         this.m_btnAbort.Name = "m_btnAbort";
         this.m_btnAbort.Size = new System.Drawing.Size(75, 23);
         this.m_btnAbort.TabIndex = 1;
         this.m_btnAbort.Text = "Abbrechen";
         this.m_btnAbort.UseVisualStyleBackColor = true;
         this.m_btnAbort.Click += new System.EventHandler(this.m_btnAbort_Click);
         // 
         // Dlg_BackgroundWorker
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(362, 83);
         this.Controls.Add(this.m_btnAbort);
         this.Controls.Add(this.m_pbProgress);
         this.Name = "Dlg_BackgroundWorker";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Dlg_BackgroundWorker";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ProgressBar m_pbProgress;
      private System.Windows.Forms.Button m_btnAbort;
   }
}