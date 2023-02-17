namespace ComputerVision
{
    partial class MainForm
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
            this.panelSource = new System.Windows.Forms.Panel();
            this.panelDestination = new System.Windows.Forms.Panel();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.split_merge = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.valoareT = new System.Windows.Forms.TextBox();
            this.btnGabor = new System.Windows.Forms.Button();
            this.btnFreiChen = new System.Windows.Forms.Button();
            this.btnPrewits = new System.Windows.Forms.Button();
            this.btnKitsh2 = new System.Windows.Forms.Button();
            this.btnUnMak = new System.Windows.Forms.Button();
            this.trece_sus = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMakarov = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttZgomot = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBReflex = new System.Windows.Forms.ComboBox();
            this.reflexBox = new System.Windows.Forms.TextBox();
            this.btnEqualize = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.trackHisto = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.trackLight = new System.Windows.Forms.TrackBar();
            this.btnNeg = new System.Windows.Forms.Button();
            this.buttonGrayscale = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackHisto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLight)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSource
            // 
            this.panelSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelSource.Location = new System.Drawing.Point(12, 12);
            this.panelSource.Name = "panelSource";
            this.panelSource.Size = new System.Drawing.Size(445, 219);
            this.panelSource.TabIndex = 0;
            this.panelSource.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSource_Paint);
            this.panelSource.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelSource_MouseClick);
            // 
            // panelDestination
            // 
            this.panelDestination.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDestination.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDestination.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelDestination.Location = new System.Drawing.Point(550, 12);
            this.panelDestination.Name = "panelDestination";
            this.panelDestination.Size = new System.Drawing.Size(438, 219);
            this.panelDestination.TabIndex = 1;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 439);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.split_merge);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.valoareT);
            this.panel1.Controls.Add(this.btnGabor);
            this.panel1.Controls.Add(this.btnFreiChen);
            this.panel1.Controls.Add(this.btnPrewits);
            this.panel1.Controls.Add(this.btnKitsh2);
            this.panel1.Controls.Add(this.btnUnMak);
            this.panel1.Controls.Add(this.trece_sus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnMakarov);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.buttZgomot);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBReflex);
            this.panel1.Controls.Add(this.reflexBox);
            this.panel1.Controls.Add(this.btnEqualize);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.trackHisto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.trackLight);
            this.panel1.Controls.Add(this.btnNeg);
            this.panel1.Controls.Add(this.buttonGrayscale);
            this.panel1.Location = new System.Drawing.Point(348, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 190);
            this.panel1.TabIndex = 3;
            // 
            // split_merge
            // 
            this.split_merge.Location = new System.Drawing.Point(529, 74);
            this.split_merge.Name = "split_merge";
            this.split_merge.Size = new System.Drawing.Size(93, 24);
            this.split_merge.TabIndex = 37;
            this.split_merge.Text = "SplitMerge2";
            this.split_merge.UseVisualStyleBackColor = true;
            this.split_merge.Click += new System.EventHandler(this.split_merge_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(525, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Segmentare";
            // 
            // valoareT
            // 
            this.valoareT.Location = new System.Drawing.Point(515, 28);
            this.valoareT.Name = "valoareT";
            this.valoareT.Size = new System.Drawing.Size(124, 20);
            this.valoareT.TabIndex = 35;
            // 
            // btnGabor
            // 
            this.btnGabor.Location = new System.Drawing.Point(578, 166);
            this.btnGabor.Name = "btnGabor";
            this.btnGabor.Size = new System.Drawing.Size(75, 23);
            this.btnGabor.TabIndex = 33;
            this.btnGabor.Text = "Gabor";
            this.btnGabor.UseVisualStyleBackColor = true;
            this.btnGabor.Click += new System.EventHandler(this.btnGabor_Click);
            // 
            // btnFreiChen
            // 
            this.btnFreiChen.Location = new System.Drawing.Point(382, 138);
            this.btnFreiChen.Name = "btnFreiChen";
            this.btnFreiChen.Size = new System.Drawing.Size(80, 23);
            this.btnFreiChen.TabIndex = 32;
            this.btnFreiChen.Text = "FreiChen";
            this.btnFreiChen.UseVisualStyleBackColor = true;
            this.btnFreiChen.Click += new System.EventHandler(this.btnFreiChen_Click);
            // 
            // btnPrewits
            // 
            this.btnPrewits.Location = new System.Drawing.Point(475, 138);
            this.btnPrewits.Name = "btnPrewits";
            this.btnPrewits.Size = new System.Drawing.Size(75, 23);
            this.btnPrewits.TabIndex = 31;
            this.btnPrewits.Text = "Prewits";
            this.btnPrewits.UseVisualStyleBackColor = true;
            this.btnPrewits.Click += new System.EventHandler(this.btnPrewits_Click);
            // 
            // btnKitsh2
            // 
            this.btnKitsh2.Location = new System.Drawing.Point(564, 137);
            this.btnKitsh2.Name = "btnKitsh2";
            this.btnKitsh2.Size = new System.Drawing.Size(75, 23);
            this.btnKitsh2.TabIndex = 30;
            this.btnKitsh2.Text = "Kitsh_var2";
            this.btnKitsh2.UseVisualStyleBackColor = true;
            this.btnKitsh2.Click += new System.EventHandler(this.btnKitsh2_Click);
            // 
            // btnUnMak
            // 
            this.btnUnMak.Location = new System.Drawing.Point(325, 167);
            this.btnUnMak.Name = "btnUnMak";
            this.btnUnMak.Size = new System.Drawing.Size(80, 23);
            this.btnUnMak.TabIndex = 29;
            this.btnUnMak.Text = "Unsharp Marking";
            this.btnUnMak.UseVisualStyleBackColor = true;
            this.btnUnMak.Click += new System.EventHandler(this.btnUnMak_Click);
            // 
            // trece_sus
            // 
            this.trece_sus.Location = new System.Drawing.Point(492, 166);
            this.trece_sus.Name = "trece_sus";
            this.trece_sus.Size = new System.Drawing.Size(80, 23);
            this.trece_sus.TabIndex = 28;
            this.trece_sus.Text = "Filtru trece sus";
            this.trece_sus.UseVisualStyleBackColor = true;
            this.trece_sus.Click += new System.EventHandler(this.trece_sus_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(417, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 25);
            this.label5.TabIndex = 27;
            this.label5.Text = "Filtre de zgomot";
            // 
            // btnMakarov
            // 
            this.btnMakarov.Location = new System.Drawing.Point(411, 166);
            this.btnMakarov.Name = "btnMakarov";
            this.btnMakarov.Size = new System.Drawing.Size(75, 23);
            this.btnMakarov.TabIndex = 26;
            this.btnMakarov.Text = "Markarov";
            this.btnMakarov.UseVisualStyleBackColor = true;
            this.btnMakarov.Click += new System.EventHandler(this.btnMakarov_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Zgomot";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 24;
            // 
            // buttZgomot
            // 
            this.buttZgomot.Location = new System.Drawing.Point(159, 16);
            this.buttZgomot.Name = "buttZgomot";
            this.buttZgomot.Size = new System.Drawing.Size(75, 23);
            this.buttZgomot.TabIndex = 23;
            this.buttZgomot.Text = "Zgomot";
            this.buttZgomot.UseVisualStyleBackColor = true;
            this.buttZgomot.Click += new System.EventHandler(this.buttZgomot_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Reflexie";
            // 
            // comboBReflex
            // 
            this.comboBReflex.FormattingEnabled = true;
            this.comboBReflex.Items.AddRange(new object[] {
            "vertical",
            "orizontal"});
            this.comboBReflex.Location = new System.Drawing.Point(341, 77);
            this.comboBReflex.Name = "comboBReflex";
            this.comboBReflex.Size = new System.Drawing.Size(121, 21);
            this.comboBReflex.TabIndex = 21;
            this.comboBReflex.SelectedIndexChanged += new System.EventHandler(this.comboBReflex_SelectedIndexChanged);
            // 
            // reflexBox
            // 
            this.reflexBox.Location = new System.Drawing.Point(341, 51);
            this.reflexBox.Name = "reflexBox";
            this.reflexBox.Size = new System.Drawing.Size(100, 20);
            this.reflexBox.TabIndex = 20;
            this.reflexBox.TextChanged += new System.EventHandler(this.reflexBox_TextChanged);
            // 
            // btnEqualize
            // 
            this.btnEqualize.Location = new System.Drawing.Point(173, 155);
            this.btnEqualize.Name = "btnEqualize";
            this.btnEqualize.Size = new System.Drawing.Size(75, 23);
            this.btnEqualize.TabIndex = 19;
            this.btnEqualize.Text = "Equalize";
            this.btnEqualize.UseVisualStyleBackColor = true;
            this.btnEqualize.Click += new System.EventHandler(this.btnEqualize_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Histograma";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // trackHisto
            // 
            this.trackHisto.Location = new System.Drawing.Point(-1, 53);
            this.trackHisto.Maximum = 130;
            this.trackHisto.Minimum = -130;
            this.trackHisto.Name = "trackHisto";
            this.trackHisto.Size = new System.Drawing.Size(320, 45);
            this.trackHisto.TabIndex = 15;
            this.trackHisto.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Brightness";
            // 
            // trackLight
            // 
            this.trackLight.Location = new System.Drawing.Point(-1, 104);
            this.trackLight.Maximum = 255;
            this.trackLight.Minimum = -255;
            this.trackLight.Name = "trackLight";
            this.trackLight.Size = new System.Drawing.Size(320, 45);
            this.trackLight.TabIndex = 15;
            this.trackLight.ValueChanged += new System.EventHandler(this.trackLight_ValueChanged);
            // 
            // btnNeg
            // 
            this.btnNeg.Location = new System.Drawing.Point(88, 155);
            this.btnNeg.Name = "btnNeg";
            this.btnNeg.Size = new System.Drawing.Size(79, 23);
            this.btnNeg.TabIndex = 14;
            this.btnNeg.Text = "Negate";
            this.btnNeg.UseVisualStyleBackColor = true;
            this.btnNeg.Click += new System.EventHandler(this.btnNeg_Click);
            // 
            // buttonGrayscale
            // 
            this.buttonGrayscale.Location = new System.Drawing.Point(7, 155);
            this.buttonGrayscale.Name = "buttonGrayscale";
            this.buttonGrayscale.Size = new System.Drawing.Size(75, 23);
            this.buttonGrayscale.TabIndex = 13;
            this.buttonGrayscale.Text = "Grayscale";
            this.buttonGrayscale.UseVisualStyleBackColor = true;
            this.buttonGrayscale.Click += new System.EventHandler(this.buttonGrayscale_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 473);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.panelDestination);
            this.Controls.Add(this.panelSource);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackHisto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackLight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSource;
        private System.Windows.Forms.Panel panelDestination;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonGrayscale;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnNeg;
        private System.Windows.Forms.TrackBar trackLight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackHisto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEqualize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBReflex;
        private System.Windows.Forms.TextBox reflexBox;
        private System.Windows.Forms.Button buttZgomot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMakarov;
        private System.Windows.Forms.Button trece_sus;
        private System.Windows.Forms.Button btnUnMak;
        private System.Windows.Forms.Button btnKitsh2;
        private System.Windows.Forms.Button btnPrewits;
        private System.Windows.Forms.Button btnFreiChen;
        private System.Windows.Forms.Button btnGabor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox valoareT;
        private System.Windows.Forms.Button split_merge;
    }
}

