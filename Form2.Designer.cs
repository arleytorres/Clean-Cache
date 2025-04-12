namespace CleanCache
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.listpanel = new System.Windows.Forms.Panel();
            this.maintitle = new System.Windows.Forms.Label();
            this.selectedchecks = new System.Windows.Forms.CheckBox();
            this.cleanallbtn = new System.Windows.Forms.Button();
            this.deleteclonesbtn = new System.Windows.Forms.Button();
            this.opcwindow = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.deleteallbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.Button();
            this.minbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.opcwindow.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listpanel
            // 
            this.listpanel.AutoScroll = true;
            this.listpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.listpanel.Location = new System.Drawing.Point(1, 74);
            this.listpanel.Name = "listpanel";
            this.listpanel.Size = new System.Drawing.Size(687, 269);
            this.listpanel.TabIndex = 1;
            this.listpanel.Click += new System.EventHandler(this.listpanel_Click);
            // 
            // maintitle
            // 
            this.maintitle.BackColor = System.Drawing.Color.Transparent;
            this.maintitle.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold);
            this.maintitle.ForeColor = System.Drawing.Color.DimGray;
            this.maintitle.Location = new System.Drawing.Point(216, 43);
            this.maintitle.Name = "maintitle";
            this.maintitle.Size = new System.Drawing.Size(256, 28);
            this.maintitle.TabIndex = 12;
            this.maintitle.Text = "Documentos";
            this.maintitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectedchecks
            // 
            this.selectedchecks.AutoSize = true;
            this.selectedchecks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectedchecks.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedchecks.ForeColor = System.Drawing.Color.SlateBlue;
            this.selectedchecks.Location = new System.Drawing.Point(12, 48);
            this.selectedchecks.Name = "selectedchecks";
            this.selectedchecks.Size = new System.Drawing.Size(121, 19);
            this.selectedchecks.TabIndex = 14;
            this.selectedchecks.Text = "0 Selecionado(s)";
            this.selectedchecks.UseVisualStyleBackColor = true;
            this.selectedchecks.Visible = false;
            this.selectedchecks.CheckedChanged += new System.EventHandler(this.SelectAllFiles);
            // 
            // cleanallbtn
            // 
            this.cleanallbtn.BackColor = System.Drawing.Color.MediumOrchid;
            this.cleanallbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cleanallbtn.FlatAppearance.BorderSize = 0;
            this.cleanallbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.cleanallbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cleanallbtn.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cleanallbtn.ForeColor = System.Drawing.Color.White;
            this.cleanallbtn.Location = new System.Drawing.Point(560, 47);
            this.cleanallbtn.Name = "cleanallbtn";
            this.cleanallbtn.Size = new System.Drawing.Size(117, 20);
            this.cleanallbtn.TabIndex = 41;
            this.cleanallbtn.Tag = "";
            this.cleanallbtn.Text = "Excluir Selecionado(s)";
            this.cleanallbtn.UseVisualStyleBackColor = false;
            this.cleanallbtn.Visible = false;
            this.cleanallbtn.Click += new System.EventHandler(this.ButtonsClick);
            // 
            // deleteclonesbtn
            // 
            this.deleteclonesbtn.BackColor = System.Drawing.Color.MediumOrchid;
            this.deleteclonesbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteclonesbtn.FlatAppearance.BorderSize = 0;
            this.deleteclonesbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.deleteclonesbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteclonesbtn.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteclonesbtn.ForeColor = System.Drawing.Color.White;
            this.deleteclonesbtn.Location = new System.Drawing.Point(12, 28);
            this.deleteclonesbtn.Name = "deleteclonesbtn";
            this.deleteclonesbtn.Size = new System.Drawing.Size(110, 20);
            this.deleteclonesbtn.TabIndex = 42;
            this.deleteclonesbtn.Tag = "";
            this.deleteclonesbtn.Text = "Excluir Duplicata(s)";
            this.deleteclonesbtn.UseVisualStyleBackColor = false;
            this.deleteclonesbtn.Click += new System.EventHandler(this.ButtonsClick);
            // 
            // opcwindow
            // 
            this.opcwindow.BackColor = System.Drawing.Color.SlateBlue;
            this.opcwindow.Controls.Add(this.label2);
            this.opcwindow.Controls.Add(this.deleteallbtn);
            this.opcwindow.Controls.Add(this.deleteclonesbtn);
            this.opcwindow.Location = new System.Drawing.Point(551, 73);
            this.opcwindow.Name = "opcwindow";
            this.opcwindow.Size = new System.Drawing.Size(134, 83);
            this.opcwindow.TabIndex = 0;
            this.opcwindow.Tag = "15";
            this.opcwindow.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 44;
            this.label2.Text = "OPÇÕES";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deleteallbtn
            // 
            this.deleteallbtn.BackColor = System.Drawing.Color.MediumOrchid;
            this.deleteallbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteallbtn.FlatAppearance.BorderSize = 0;
            this.deleteallbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.deleteallbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteallbtn.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteallbtn.ForeColor = System.Drawing.Color.White;
            this.deleteallbtn.Location = new System.Drawing.Point(12, 53);
            this.deleteallbtn.Name = "deleteallbtn";
            this.deleteallbtn.Size = new System.Drawing.Size(110, 20);
            this.deleteallbtn.TabIndex = 43;
            this.deleteallbtn.Tag = "";
            this.deleteallbtn.Text = "Excluir Todos";
            this.deleteallbtn.UseVisualStyleBackColor = false;
            this.deleteallbtn.Click += new System.EventHandler(this.ButtonsClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateBlue;
            this.panel1.BackgroundImage = global::CleanCache.Properties.Resources.background;
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.minbtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 40);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // closebtn
            // 
            this.closebtn.BackColor = System.Drawing.Color.Transparent;
            this.closebtn.FlatAppearance.BorderSize = 0;
            this.closebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.ForeColor = System.Drawing.Color.White;
            this.closebtn.Location = new System.Drawing.Point(656, 1);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(32, 27);
            this.closebtn.TabIndex = 100;
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
            this.minbtn.Location = new System.Drawing.Point(620, 1);
            this.minbtn.Name = "minbtn";
            this.minbtn.Size = new System.Drawing.Size(32, 27);
            this.minbtn.TabIndex = 101;
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
            this.label3.TabIndex = 12;
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
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 11;
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
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(689, 346);
            this.Controls.Add(this.opcwindow);
            this.Controls.Add(this.selectedchecks);
            this.Controls.Add(this.cleanallbtn);
            this.Controls.Add(this.maintitle);
            this.Controls.Add(this.listpanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clean Cache - Duplicados";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.opcwindow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button minbtn;
        private System.Windows.Forms.Panel listpanel;
        private System.Windows.Forms.Label maintitle;
        private System.Windows.Forms.CheckBox selectedchecks;
        public System.Windows.Forms.Button cleanallbtn;
        private System.Windows.Forms.Panel opcwindow;
        public System.Windows.Forms.Button deleteclonesbtn;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button deleteallbtn;
    }
}