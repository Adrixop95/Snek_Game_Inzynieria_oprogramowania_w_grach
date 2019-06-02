namespace Snake.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.fLPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.labelPoints = new System.Windows.Forms.Label();
            this.pictBox = new System.Windows.Forms.PictureBox();
            this.buttonInformations = new System.Windows.Forms.Button();
            this.fLPanelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fLPanelMenu
            // 
            this.fLPanelMenu.Controls.Add(this.buttonStartGame);
            this.fLPanelMenu.Controls.Add(this.buttonInformations);
            this.fLPanelMenu.Controls.Add(this.labelPoints);
            this.fLPanelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.fLPanelMenu.Location = new System.Drawing.Point(0, 0);
            this.fLPanelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.fLPanelMenu.Name = "fLPanelMenu";
            this.fLPanelMenu.Size = new System.Drawing.Size(784, 48);
            this.fLPanelMenu.TabIndex = 0;
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Location = new System.Drawing.Point(4, 4);
            this.buttonStartGame.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(112, 40);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "Start Game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.ButtonStartGame_Click);
            // 
            // labelPoints
            // 
            this.labelPoints.Location = new System.Drawing.Point(244, 4);
            this.labelPoints.Margin = new System.Windows.Forms.Padding(4);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(112, 40);
            this.labelPoints.TabIndex = 1;
            this.labelPoints.Text = "Points: 0";
            this.labelPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictBox
            // 
            this.pictBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictBox.Location = new System.Drawing.Point(0, 48);
            this.pictBox.Name = "pictBox";
            this.pictBox.Size = new System.Drawing.Size(784, 513);
            this.pictBox.TabIndex = 1;
            this.pictBox.TabStop = false;
            // 
            // buttonInformations
            // 
            this.buttonInformations.Location = new System.Drawing.Point(124, 4);
            this.buttonInformations.Margin = new System.Windows.Forms.Padding(4);
            this.buttonInformations.Name = "buttonInformations";
            this.buttonInformations.Size = new System.Drawing.Size(112, 40);
            this.buttonInformations.TabIndex = 2;
            this.buttonInformations.Text = "About";
            this.buttonInformations.UseVisualStyleBackColor = true;
            this.buttonInformations.Click += new System.EventHandler(this.ButtonInformations_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pictBox);
            this.Controls.Add(this.fLPanelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Snake";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.fLPanelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fLPanelMenu;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.PictureBox pictBox;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Button buttonInformations;
    }
}

