namespace CleanCache
{
    partial class configs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configs));
            this.menubar = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.Button();
            this.minbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboopc = new System.Windows.Forms.ComboBox();
            this.configopc3 = new System.Windows.Forms.PictureBox();
            this.configopc2 = new System.Windows.Forms.PictureBox();
            this.configopc1 = new System.Windows.Forms.PictureBox();
            this.logsbtn = new System.Windows.Forms.Button();
            this.menubar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configopc3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configopc2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configopc1)).BeginInit();
            this.SuspendLayout();
            // 
            // menubar
            // 
            this.menubar.BackColor = System.Drawing.Color.SlateBlue;
            this.menubar.BackgroundImage = global::CleanCache.Properties.Resources.background;
            this.menubar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menubar.Controls.Add(this.closebtn);
            this.menubar.Controls.Add(this.minbtn);
            this.menubar.Controls.Add(this.label3);
            this.menubar.Controls.Add(this.label1);
            this.menubar.Controls.Add(this.pictureBox1);
            this.menubar.Dock = System.Windows.Forms.DockStyle.Top;
            this.menubar.Location = new System.Drawing.Point(0, 0);
            this.menubar.Name = "menubar";
            this.menubar.Size = new System.Drawing.Size(406, 40);
            this.menubar.TabIndex = 0;
            this.menubar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menubar_MouseDown);
            this.menubar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menubar_MouseMove);
            this.menubar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.menubar_MouseUp);
            // 
            // closebtn
            // 
            this.closebtn.BackColor = System.Drawing.Color.Transparent;
            this.closebtn.FlatAppearance.BorderSize = 0;
            this.closebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.ForeColor = System.Drawing.Color.White;
            this.closebtn.Location = new System.Drawing.Point(373, 1);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(32, 27);
            this.closebtn.TabIndex = 107;
            this.closebtn.Text = "X";
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.ButtonsClick);
            // 
            // minbtn
            // 
            this.minbtn.BackColor = System.Drawing.Color.Transparent;
            this.minbtn.FlatAppearance.BorderSize = 0;
            this.minbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
            this.minbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minbtn.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minbtn.ForeColor = System.Drawing.Color.White;
            this.minbtn.Location = new System.Drawing.Point(337, 1);
            this.minbtn.Name = "minbtn";
            this.minbtn.Size = new System.Drawing.Size(32, 27);
            this.minbtn.TabIndex = 108;
            this.minbtn.Text = "─";
            this.minbtn.UseVisualStyleBackColor = false;
            this.minbtn.Click += new System.EventHandler(this.ButtonsClick);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 11F);
            this.label3.ForeColor = System.Drawing.Color.Plum;
            this.label3.Location = new System.Drawing.Point(123, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 106;
            this.label3.Text = "|  Beta";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 105;
            this.label1.Text = "Clean Cache";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CleanCache.Properties.Resources.clean;
            this.pictureBox1.Location = new System.Drawing.Point(9, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 104;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 158);
            this.label2.TabIndex = 1;
            this.label2.Text = "Iniciar com o Windows\r\n\r\nIniciar Minimizado\r\n\r\nLimpar Automáticamente\r\n\r\nVarredur" +
    "a Automática\r\n\r\nLogs\r\n";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(12, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(382, 19);
            this.label4.TabIndex = 106;
            this.label4.Text = "DEFINIÇÕES";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboopc
            // 
            this.comboopc.BackColor = System.Drawing.SystemColors.Control;
            this.comboopc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboopc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboopc.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboopc.FormattingEnabled = true;
            this.comboopc.Items.AddRange(new object[] {
            "Diáriamente",
            "Semanalmente",
            "Mensalmente"});
            this.comboopc.Location = new System.Drawing.Point(293, 177);
            this.comboopc.Name = "comboopc";
            this.comboopc.Size = new System.Drawing.Size(101, 23);
            this.comboopc.TabIndex = 110;
            this.comboopc.SelectedIndexChanged += new System.EventHandler(this.VarreduraConfigChanged);
            // 
            // configopc3
            // 
            this.configopc3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.configopc3.Image = global::CleanCache.Properties.Resources.off_button;
            this.configopc3.Location = new System.Drawing.Point(358, 142);
            this.configopc3.Name = "configopc3";
            this.configopc3.Size = new System.Drawing.Size(36, 19);
            this.configopc3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.configopc3.TabIndex = 109;
            this.configopc3.TabStop = false;
            this.configopc3.Tag = "OFF";
            this.configopc3.Click += new System.EventHandler(this.ButtonsClick);
            // 
            // configopc2
            // 
            this.configopc2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.configopc2.Image = global::CleanCache.Properties.Resources.off_button;
            this.configopc2.Location = new System.Drawing.Point(357, 112);
            this.configopc2.Name = "configopc2";
            this.configopc2.Size = new System.Drawing.Size(36, 19);
            this.configopc2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.configopc2.TabIndex = 108;
            this.configopc2.TabStop = false;
            this.configopc2.Tag = "OFF";
            this.configopc2.Click += new System.EventHandler(this.ButtonsClick);
            // 
            // configopc1
            // 
            this.configopc1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.configopc1.Image = global::CleanCache.Properties.Resources.off_button;
            this.configopc1.Location = new System.Drawing.Point(357, 82);
            this.configopc1.Name = "configopc1";
            this.configopc1.Size = new System.Drawing.Size(36, 19);
            this.configopc1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.configopc1.TabIndex = 107;
            this.configopc1.TabStop = false;
            this.configopc1.Tag = "OFF";
            this.configopc1.Click += new System.EventHandler(this.ButtonsClick);
            // 
            // logsbtn
            // 
            this.logsbtn.BackColor = System.Drawing.Color.MediumOrchid;
            this.logsbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logsbtn.FlatAppearance.BorderSize = 0;
            this.logsbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.logsbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logsbtn.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.logsbtn.ForeColor = System.Drawing.Color.White;
            this.logsbtn.Location = new System.Drawing.Point(320, 210);
            this.logsbtn.Name = "logsbtn";
            this.logsbtn.Size = new System.Drawing.Size(74, 19);
            this.logsbtn.TabIndex = 111;
            this.logsbtn.Tag = "";
            this.logsbtn.Text = "Exibir";
            this.logsbtn.UseVisualStyleBackColor = false;
            this.logsbtn.Click += new System.EventHandler(this.ButtonsClick);
            // 
            // configs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 249);
            this.Controls.Add(this.logsbtn);
            this.Controls.Add(this.comboopc);
            this.Controls.Add(this.configopc3);
            this.Controls.Add(this.configopc2);
            this.Controls.Add(this.configopc1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menubar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "configs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clean Cache - Definições";
            this.Load += new System.EventHandler(this.configs_Load);
            this.menubar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configopc3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configopc2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configopc1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menubar;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button minbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox configopc1;
        private System.Windows.Forms.PictureBox configopc2;
        private System.Windows.Forms.PictureBox configopc3;
        private System.Windows.Forms.ComboBox comboopc;
        public System.Windows.Forms.Button logsbtn;
    }
}