namespace ResponseSystem.WindowsApp
{
    partial class ParseResponse
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            ResponseTxt = new TextBox();
            parsebtn = new Button();
            resulttxt = new TextBox();
            label2 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.60784F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.39216F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 265F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(ResponseTxt, 1, 0);
            tableLayoutPanel1.Controls.Add(parsebtn, 2, 0);
            tableLayoutPanel1.Controls.Add(resulttxt, 3, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Margin = new Padding(5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 263F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 129F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(776, 426);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(247, 97);
            label1.TabIndex = 0;
            label1.Text = "Input Response Message";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ResponseTxt
            // 
            ResponseTxt.AcceptsReturn = true;
            ResponseTxt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ResponseTxt.Location = new Point(256, 3);
            ResponseTxt.Multiline = true;
            ResponseTxt.Name = "ResponseTxt";
            ResponseTxt.Size = new Size(251, 91);
            ResponseTxt.TabIndex = 1;
            // 
            // parsebtn
            // 
            parsebtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            parsebtn.Location = new Point(513, 3);
            parsebtn.Name = "parsebtn";
            parsebtn.Size = new Size(260, 91);
            parsebtn.TabIndex = 2;
            parsebtn.Text = "Parse";
            parsebtn.UseVisualStyleBackColor = true;
            parsebtn.Click += parsebtn_Click;
            // 
            // resulttxt
            // 
            resulttxt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(resulttxt, 3);
            resulttxt.Location = new Point(3, 100);
            resulttxt.Multiline = true;
            resulttxt.Name = "resulttxt";
            resulttxt.Size = new Size(770, 257);
            resulttxt.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label2, 3);
            label2.Location = new Point(3, 360);
            label2.Name = "label2";
            label2.Size = new Size(770, 66);
            label2.TabIndex = 4;
            label2.Text = "Input message valid formats :\r\n The alarm id from video server number X is Y.\r\n Alarm id Y has been received from video server number X.";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ParseResponse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "ParseResponse";
            Text = "Parse Response";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox ResponseTxt;
        private Button parsebtn;
        private TextBox resulttxt;
        private Label label2;
    }
}