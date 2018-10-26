namespace VxLibraryData.Gui.Dlg
{
   partial class Dlg_ResultInfo
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
         this.m_btnOk = new System.Windows.Forms.Button();
         this.m_txtClass = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.m_txtMethod = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.m_txtFile = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.m_txtLine = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.m_txtLevel = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.m_txtErrorCode = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.m_txtErrorText = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // m_btnOk
         // 
         this.m_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.m_btnOk.Location = new System.Drawing.Point(277, 352);
         this.m_btnOk.Name = "m_btnOk";
         this.m_btnOk.Size = new System.Drawing.Size(75, 23);
         this.m_btnOk.TabIndex = 13;
         this.m_btnOk.Text = "Ok";
         this.m_btnOk.UseVisualStyleBackColor = true;
         // 
         // m_txtClass
         // 
         this.m_txtClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.m_txtClass.Location = new System.Drawing.Point(77, 12);
         this.m_txtClass.Name = "m_txtClass";
         this.m_txtClass.ReadOnly = true;
         this.m_txtClass.Size = new System.Drawing.Size(275, 20);
         this.m_txtClass.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(27, 15);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(44, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Klasse :";
         // 
         // m_txtMethod
         // 
         this.m_txtMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.m_txtMethod.Location = new System.Drawing.Point(77, 38);
         this.m_txtMethod.Name = "m_txtMethod";
         this.m_txtMethod.ReadOnly = true;
         this.m_txtMethod.Size = new System.Drawing.Size(275, 20);
         this.m_txtMethod.TabIndex = 3;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(16, 41);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(55, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Methode :";
         // 
         // m_txtFile
         // 
         this.m_txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.m_txtFile.Location = new System.Drawing.Point(77, 64);
         this.m_txtFile.Name = "m_txtFile";
         this.m_txtFile.ReadOnly = true;
         this.m_txtFile.Size = new System.Drawing.Size(275, 20);
         this.m_txtFile.TabIndex = 5;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(42, 67);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(29, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "File :";
         // 
         // m_txtLine
         // 
         this.m_txtLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.m_txtLine.Location = new System.Drawing.Point(77, 90);
         this.m_txtLine.Name = "m_txtLine";
         this.m_txtLine.ReadOnly = true;
         this.m_txtLine.Size = new System.Drawing.Size(275, 20);
         this.m_txtLine.TabIndex = 7;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(38, 93);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(33, 13);
         this.label4.TabIndex = 6;
         this.label4.Text = "Line :";
         // 
         // m_txtLevel
         // 
         this.m_txtLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.m_txtLevel.Location = new System.Drawing.Point(77, 116);
         this.m_txtLevel.Name = "m_txtLevel";
         this.m_txtLevel.ReadOnly = true;
         this.m_txtLevel.Size = new System.Drawing.Size(275, 20);
         this.m_txtLevel.TabIndex = 9;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(32, 119);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(39, 13);
         this.label5.TabIndex = 8;
         this.label5.Text = "Level :";
         // 
         // m_txtErrorCode
         // 
         this.m_txtErrorCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.m_txtErrorCode.Location = new System.Drawing.Point(77, 142);
         this.m_txtErrorCode.Name = "m_txtErrorCode";
         this.m_txtErrorCode.ReadOnly = true;
         this.m_txtErrorCode.Size = new System.Drawing.Size(275, 20);
         this.m_txtErrorCode.TabIndex = 11;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(12, 145);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(59, 13);
         this.label6.TabIndex = 10;
         this.label6.Text = "Errorcode :";
         // 
         // m_txtErrorText
         // 
         this.m_txtErrorText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.m_txtErrorText.Location = new System.Drawing.Point(77, 168);
         this.m_txtErrorText.Multiline = true;
         this.m_txtErrorText.Name = "m_txtErrorText";
         this.m_txtErrorText.ReadOnly = true;
         this.m_txtErrorText.Size = new System.Drawing.Size(275, 178);
         this.m_txtErrorText.TabIndex = 12;
         // 
         // Dlg_ResultInfo
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(364, 387);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.m_txtErrorText);
         this.Controls.Add(this.m_txtErrorCode);
         this.Controls.Add(this.m_txtLevel);
         this.Controls.Add(this.m_txtLine);
         this.Controls.Add(this.m_txtFile);
         this.Controls.Add(this.m_txtMethod);
         this.Controls.Add(this.m_txtClass);
         this.Controls.Add(this.m_btnOk);
         this.Name = "Dlg_ResultInfo";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Es ist ein Fehler aufgetreten!";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button m_btnOk;
      private System.Windows.Forms.TextBox m_txtClass;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox m_txtMethod;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox m_txtFile;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox m_txtLine;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox m_txtLevel;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox m_txtErrorCode;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox m_txtErrorText;
   }
}