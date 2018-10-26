namespace VxLibraryData.Gui.Gui.Ctrl
{
   partial class UsrCtrl_FileSystemTree
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent ()
      {
         this.m_tvFileTree = new System.Windows.Forms.TreeView();
         this.SuspendLayout();
         // 
         // m_tvFileTree
         // 
         this.m_tvFileTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.m_tvFileTree.Location = new System.Drawing.Point(0, 0);
         this.m_tvFileTree.Margin = new System.Windows.Forms.Padding(0);
         this.m_tvFileTree.Name = "m_tvFileTree";
         this.m_tvFileTree.Size = new System.Drawing.Size(664, 515);
         this.m_tvFileTree.TabIndex = 0;
         // 
         // UsrCtrl_FileSystemTree
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.m_tvFileTree);
         this.Name = "UsrCtrl_FileSystemTree";
         this.Size = new System.Drawing.Size(664, 515);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TreeView m_tvFileTree;
   }
}
