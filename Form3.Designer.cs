namespace CleanCache
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.menubar = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.desclbl = new System.Windows.Forms.Label();
            this.fileslist = new System.Windows.Forms.ComboBox();
            this.deleteall = new System.Windows.Forms.Button();
            this.deleteonly = new System.Windows.Forms.Button();
            this.menubar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menubar
            // 
            this.menubar.BackColor = System.Drawing.Color.SlateBlue;
            this.menubar.BackgroundImage = global::CleanCache.Properties.Resources.background;
            this.menubar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menubar.Controls.Add(this.closebtn);
            this.menubar.Controls.Add(this.label3);
            this.menubar.Controls.Add(this.label1);
            this.menubar.Controls.Add(this.pictureBox1);
            this.menubar.Dock = System.Windows.Forms.DockStyle.Top;
            this.menubar.Location = new System.Drawing.Point(0, 0);
            this.menubar.Name = "menubar";
            this.menubar.Size = new System.Drawing.Size(411, 40);
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
            this.closebtn.Location = new System.Drawing.Point(378, 1);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(32, 27);
            this.closebtn.TabIndex = 102;
            this.closebtn.Text = "X";
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.ButtonsClick);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 11F);
            this.label3.ForeColor = System.Drawing.Color.Plum;
            this.label3.Location = new System.Drawing.Point(123, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 15;
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
            this.label1.TabIndex = 14;
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
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(387, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "DESCRIÇÃO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // desclbl
            // 
            this.desclbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.desclbl.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desclbl.ForeColor = System.Drawing.Color.DimGray;
            this.desclbl.Location = new System.Drawing.Point(12, 88);
            this.desclbl.Name = "desclbl";
            this.desclbl.Size = new System.Drawing.Size(387, 102);
            this.desclbl.TabIndex = 3;
            this.desclbl.Text = "Nome do Arquivo:\r\n\r\nTipo:\r\nTamanho:\r\nLocal:";
            this.desclbl.UseCompatibleTextRendering = true;
            // 
            // fileslist
            // 
            this.fileslist.BackColor = System.Drawing.SystemColors.Control;
            this.fileslist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileslist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileslist.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileslist.FormattingEnabled = true;
            this.fileslist.Location = new System.Drawing.Point(134, 87);
            this.fileslist.Name = "fileslist";
            this.fileslist.Size = new System.Drawing.Size(265, 22);
            this.fileslist.TabIndex = 4;
            this.fileslist.SelectedValueChanged += new System.EventHandler(this.FilesListChanged);
            // 
            // deleteall
            // 
            this.deleteall.BackColor = System.Drawing.Color.MediumOrchid;
            this.deleteall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteall.FlatAppearance.BorderSize = 0;
            this.deleteall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.deleteall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteall.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.deleteall.ForeColor = System.Drawing.Color.White;
            this.deleteall.Location = new System.Drawing.Point(297, 199);
            this.deleteall.Name = "deleteall";
            this.deleteall.Size = new System.Drawing.Size(102, 24);
            this.deleteall.TabIndex = 5;
            this.deleteall.Text = "Excluir Todos";
            this.deleteall.UseVisualStyleBackColor = false;
            this.deleteall.Click += new System.EventHandler(this.ButtonsClick);
            // 
            // deleteonly
            // 
            this.deleteonly.BackColor = System.Drawing.Color.SlateBlue;
            this.deleteonly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteonly.FlatAppearance.BorderSize = 0;
            this.deleteonly.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.deleteonly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteonly.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.deleteonly.ForeColor = System.Drawing.Color.White;
            this.deleteonly.Location = new System.Drawing.Point(162, 199);
            this.deleteonly.Name = "deleteonly";
            this.deleteonly.Size = new System.Drawing.Size(129, 24);
            this.deleteonly.TabIndex = 6;
            this.deleteonly.Text = "Excluir Selecionado";
            this.deleteonly.UseVisualStyleBackColor = false;
            this.deleteonly.Click += new System.EventHandler(this.ButtonsClick);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 230);
            this.Controls.Add(this.deleteonly);
            this.Controls.Add(this.deleteall);
            this.Controls.Add(this.fileslist);
            this.Controls.Add(this.desclbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menubar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clean Cache - Descrição";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.menubar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menubar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label desclbl;
        private System.Windows.Forms.ComboBox fileslist;
        private System.Windows.Forms.Button deleteall;
        private System.Windows.Forms.Button deleteonly;
    }
}