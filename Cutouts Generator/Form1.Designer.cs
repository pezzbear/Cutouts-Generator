namespace Cutouts_Generator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_generate = new Button();
            label1 = new Label();
            pBox_display = new PictureBox();
            pnl_controls = new Panel();
            btn_openCoverageImg = new Button();
            btn_importCoordList = new Button();
            btn_removeCoord = new Button();
            btn_addCoord = new Button();
            label8 = new Label();
            label7 = new Label();
            num_yCoord = new NumericUpDown();
            num_xCoord = new NumericUpDown();
            label6 = new Label();
            btn_setExportPath = new Button();
            lst_coordList = new ListBox();
            num_delay = new NumericUpDown();
            num_gifSize = new NumericUpDown();
            num_numOfImg = new NumericUpDown();
            txt_exportFilePath = new TextBox();
            btn_openSourceImg = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lbl_status = new Label();
            groupBox1 = new GroupBox();
            rbtn_none = new RadioButton();
            rbtn_nftCoverage = new RadioButton();
            rbtn_coverageImg = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)pBox_display).BeginInit();
            pnl_controls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_yCoord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_xCoord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_delay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_gifSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_numOfImg).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_generate
            // 
            btn_generate.Enabled = false;
            btn_generate.Location = new Point(120, 168);
            btn_generate.Name = "btn_generate";
            btn_generate.Size = new Size(75, 23);
            btn_generate.TabIndex = 0;
            btn_generate.Text = "Generate";
            btn_generate.UseVisualStyleBackColor = true;
            btn_generate.Click += btn_generate_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(16, 16);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 1;
            label1.Text = "Cutouts Generator";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.UseMnemonic = false;
            // 
            // pBox_display
            // 
            pBox_display.BorderStyle = BorderStyle.Fixed3D;
            pBox_display.Location = new Point(8, 8);
            pBox_display.Name = "pBox_display";
            pBox_display.Size = new Size(1112, 688);
            pBox_display.SizeMode = PictureBoxSizeMode.Zoom;
            pBox_display.TabIndex = 2;
            pBox_display.TabStop = false;
            // 
            // pnl_controls
            // 
            pnl_controls.BorderStyle = BorderStyle.Fixed3D;
            pnl_controls.Controls.Add(btn_openCoverageImg);
            pnl_controls.Controls.Add(btn_importCoordList);
            pnl_controls.Controls.Add(btn_removeCoord);
            pnl_controls.Controls.Add(btn_addCoord);
            pnl_controls.Controls.Add(label8);
            pnl_controls.Controls.Add(label7);
            pnl_controls.Controls.Add(num_yCoord);
            pnl_controls.Controls.Add(num_xCoord);
            pnl_controls.Controls.Add(label6);
            pnl_controls.Controls.Add(btn_setExportPath);
            pnl_controls.Controls.Add(lst_coordList);
            pnl_controls.Controls.Add(num_delay);
            pnl_controls.Controls.Add(num_gifSize);
            pnl_controls.Controls.Add(num_numOfImg);
            pnl_controls.Controls.Add(txt_exportFilePath);
            pnl_controls.Controls.Add(btn_openSourceImg);
            pnl_controls.Controls.Add(label4);
            pnl_controls.Controls.Add(label3);
            pnl_controls.Controls.Add(label2);
            pnl_controls.Controls.Add(lbl_status);
            pnl_controls.Controls.Add(btn_generate);
            pnl_controls.Controls.Add(label1);
            pnl_controls.Location = new Point(1128, 8);
            pnl_controls.Name = "pnl_controls";
            pnl_controls.Size = new Size(208, 688);
            pnl_controls.TabIndex = 3;
            // 
            // btn_openCoverageImg
            // 
            btn_openCoverageImg.Location = new Point(16, 72);
            btn_openCoverageImg.Name = "btn_openCoverageImg";
            btn_openCoverageImg.Size = new Size(176, 23);
            btn_openCoverageImg.TabIndex = 26;
            btn_openCoverageImg.Text = "Open Coverage Image";
            btn_openCoverageImg.UseVisualStyleBackColor = true;
            btn_openCoverageImg.Click += btn_openCoverageImg_Click;
            // 
            // btn_importCoordList
            // 
            btn_importCoordList.Location = new Point(16, 464);
            btn_importCoordList.Name = "btn_importCoordList";
            btn_importCoordList.Size = new Size(176, 23);
            btn_importCoordList.TabIndex = 25;
            btn_importCoordList.Text = "Import Coordinates";
            btn_importCoordList.UseVisualStyleBackColor = true;
            btn_importCoordList.Click += btn_importCoordList_Click;
            // 
            // btn_removeCoord
            // 
            btn_removeCoord.Location = new Point(16, 496);
            btn_removeCoord.Name = "btn_removeCoord";
            btn_removeCoord.Size = new Size(176, 23);
            btn_removeCoord.TabIndex = 24;
            btn_removeCoord.Text = "Remove Coordinate";
            btn_removeCoord.UseVisualStyleBackColor = true;
            btn_removeCoord.Click += btn_removeCoord_Click;
            // 
            // btn_addCoord
            // 
            btn_addCoord.Location = new Point(16, 432);
            btn_addCoord.Name = "btn_addCoord";
            btn_addCoord.Size = new Size(176, 23);
            btn_addCoord.TabIndex = 23;
            btn_addCoord.Text = "Add Coordinate";
            btn_addCoord.UseVisualStyleBackColor = true;
            btn_addCoord.Click += btn_addCoord_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(112, 400);
            label8.Name = "label8";
            label8.Size = new Size(20, 15);
            label8.TabIndex = 22;
            label8.Text = "Y: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 400);
            label7.Name = "label7";
            label7.Size = new Size(20, 15);
            label7.TabIndex = 21;
            label7.Text = "X :";
            // 
            // num_yCoord
            // 
            num_yCoord.Location = new Point(136, 400);
            num_yCoord.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            num_yCoord.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_yCoord.Name = "num_yCoord";
            num_yCoord.Size = new Size(56, 23);
            num_yCoord.TabIndex = 20;
            num_yCoord.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // num_xCoord
            // 
            num_xCoord.Location = new Point(48, 400);
            num_xCoord.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            num_xCoord.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_xCoord.Name = "num_xCoord";
            num_xCoord.Size = new Size(56, 23);
            num_xCoord.TabIndex = 19;
            num_xCoord.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 296);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 18;
            label6.Text = "1/1 Coordinates : ";
            // 
            // btn_setExportPath
            // 
            btn_setExportPath.Location = new Point(16, 104);
            btn_setExportPath.Name = "btn_setExportPath";
            btn_setExportPath.Size = new Size(176, 23);
            btn_setExportPath.TabIndex = 15;
            btn_setExportPath.Text = "Set Export Path";
            btn_setExportPath.UseVisualStyleBackColor = true;
            btn_setExportPath.Click += btn_setExportPath_Click;
            // 
            // lst_coordList
            // 
            lst_coordList.FormattingEnabled = true;
            lst_coordList.ItemHeight = 15;
            lst_coordList.Location = new Point(16, 320);
            lst_coordList.Name = "lst_coordList";
            lst_coordList.Size = new Size(176, 64);
            lst_coordList.TabIndex = 14;
            lst_coordList.SelectedIndexChanged += lst_coordList_SelectedIndexChanged;
            // 
            // num_delay
            // 
            num_delay.Location = new Point(136, 272);
            num_delay.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            num_delay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_delay.Name = "num_delay";
            num_delay.Size = new Size(56, 23);
            num_delay.TabIndex = 13;
            num_delay.Value = new decimal(new int[] { 6, 0, 0, 0 });
            num_delay.ValueChanged += delay_ValueChanged;
            // 
            // num_gifSize
            // 
            num_gifSize.Location = new Point(136, 240);
            num_gifSize.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            num_gifSize.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            num_gifSize.Name = "num_gifSize";
            num_gifSize.Size = new Size(56, 23);
            num_gifSize.TabIndex = 12;
            num_gifSize.Value = new decimal(new int[] { 200, 0, 0, 0 });
            num_gifSize.ValueChanged += gifSize_ValueChanged;
            // 
            // num_numOfImg
            // 
            num_numOfImg.Location = new Point(136, 208);
            num_numOfImg.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_numOfImg.Name = "num_numOfImg";
            num_numOfImg.Size = new Size(56, 23);
            num_numOfImg.TabIndex = 11;
            num_numOfImg.Value = new decimal(new int[] { 5, 0, 0, 0 });
            num_numOfImg.ValueChanged += numOfImg_ValueChanged;
            // 
            // txt_exportFilePath
            // 
            txt_exportFilePath.Location = new Point(16, 136);
            txt_exportFilePath.Name = "txt_exportFilePath";
            txt_exportFilePath.ReadOnly = true;
            txt_exportFilePath.Size = new Size(176, 23);
            txt_exportFilePath.TabIndex = 10;
            txt_exportFilePath.Text = "...";
            // 
            // btn_openSourceImg
            // 
            btn_openSourceImg.Location = new Point(16, 40);
            btn_openSourceImg.Name = "btn_openSourceImg";
            btn_openSourceImg.Size = new Size(176, 23);
            btn_openSourceImg.TabIndex = 9;
            btn_openSourceImg.Text = "Open Source Image";
            btn_openSourceImg.UseVisualStyleBackColor = true;
            btn_openSourceImg.Click += btn_openSourceImg_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 208);
            label4.Name = "label4";
            label4.Size = new Size(114, 15);
            label4.TabIndex = 6;
            label4.Text = "Number Of Images :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 272);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 5;
            label3.Text = "FPS : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 240);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 4;
            label2.Text = "Gif Size :";
            // 
            // lbl_status
            // 
            lbl_status.Anchor = AnchorStyles.Top;
            lbl_status.AutoSize = true;
            lbl_status.Location = new Point(16, 176);
            lbl_status.Name = "lbl_status";
            lbl_status.Size = new Size(79, 15);
            lbl_status.TabIndex = 2;
            lbl_status.Text = " Standby (•_•)";
            lbl_status.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbtn_none);
            groupBox1.Controls.Add(rbtn_nftCoverage);
            groupBox1.Controls.Add(rbtn_coverageImg);
            groupBox1.Location = new Point(1144, 544);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(176, 128);
            groupBox1.TabIndex = 27;
            groupBox1.TabStop = false;
            groupBox1.Text = "Overlay";
            // 
            // rbtn_none
            // 
            rbtn_none.AutoSize = true;
            rbtn_none.Location = new Point(16, 96);
            rbtn_none.Name = "rbtn_none";
            rbtn_none.Size = new Size(54, 19);
            rbtn_none.TabIndex = 1;
            rbtn_none.TabStop = true;
            rbtn_none.Text = "None";
            rbtn_none.UseVisualStyleBackColor = true;
            // 
            // rbtn_nftCoverage
            // 
            rbtn_nftCoverage.AutoSize = true;
            rbtn_nftCoverage.Location = new Point(16, 64);
            rbtn_nftCoverage.Name = "rbtn_nftCoverage";
            rbtn_nftCoverage.Size = new Size(99, 19);
            rbtn_nftCoverage.TabIndex = 0;
            rbtn_nftCoverage.TabStop = true;
            rbtn_nftCoverage.Text = "NFT Coverage";
            rbtn_nftCoverage.UseVisualStyleBackColor = true;
            // 
            // rbtn_coverageImg
            // 
            rbtn_coverageImg.AutoSize = true;
            rbtn_coverageImg.Location = new Point(16, 32);
            rbtn_coverageImg.Name = "rbtn_coverageImg";
            rbtn_coverageImg.Size = new Size(111, 19);
            rbtn_coverageImg.TabIndex = 0;
            rbtn_coverageImg.TabStop = true;
            rbtn_coverageImg.Text = "Coverage Image";
            rbtn_coverageImg.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1345, 708);
            Controls.Add(groupBox1);
            Controls.Add(pnl_controls);
            Controls.Add(pBox_display);
            Name = "Form1";
            Text = "Form1";
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)pBox_display).EndInit();
            pnl_controls.ResumeLayout(false);
            pnl_controls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_yCoord).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_xCoord).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_delay).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_gifSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_numOfImg).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_generate;
        private Label label1;
        private PictureBox pBox_display;
        private Panel pnl_controls;
        private Label lbl_status;
        private Label label2;
        private Label label4;
        private Label label3;
        private TextBox txt_exportFilePath;
        private Button btn_openSourceImg;
        private NumericUpDown num_delay;
        private NumericUpDown num_gifSize;
        private NumericUpDown num_numOfImg;
        private ListBox lst_coordList;
        private Button btn_setExportPath;
        private Label label6;
        private Label label8;
        private Label label7;
        private NumericUpDown num_yCoord;
        private NumericUpDown num_xCoord;
        private Button btn_removeCoord;
        private Button btn_addCoord;
        private Button btn_importCoordList;
        private Button btn_openCoverageImg;
        private GroupBox groupBox1;
        private RadioButton rbtn_nftCoverage;
        private RadioButton rbtn_coverageImg;
        private RadioButton rbtn_none;
    }
}
