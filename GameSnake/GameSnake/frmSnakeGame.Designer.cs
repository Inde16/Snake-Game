namespace GameSnake
{
    partial class frmSnakeGame
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
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBoard.BackColor = System.Drawing.SystemColors.Window;
            this.pnlBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBoard.Location = new System.Drawing.Point(22, 26);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(504, 306);
            this.pnlBoard.TabIndex = 0;
            this.pnlBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBoard_Paint);
            this.pnlBoard.Resize += new System.EventHandler(this.pnlBoard_Resize);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.Location = new System.Drawing.Point(12, 347);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(326, 34);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "lblInfo";            
            // 
            // lblPosition
            // 
            this.lblPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosition.Location = new System.Drawing.Point(424, 347);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(102, 24);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "lblPosition";
            // 
            // frmSnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(540, 386);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.pnlBoard);
            this.Name = "frmSnakeGame";
            this.Text = "Snake";
            this.Activated += new System.EventHandler(this.frmSnakeGame_Activated);
            this.Deactivate += new System.EventHandler(this.frmSnakeGame_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSnakeGame_FormClosing);
            this.Load += new System.EventHandler(this.frmSnakeGame_Load);
            this.Shown += new System.EventHandler(this.frmSnakeGame_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSnakeGame_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblPosition;
    }
}

