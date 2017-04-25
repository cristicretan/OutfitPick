namespace Clothes_Pick
{
    partial class PickMyClothes
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
            this.Back = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.Previous = new System.Windows.Forms.Button();
            this.OverTop = new System.Windows.Forms.PictureBox();
            this.UnderTop = new System.Windows.Forms.PictureBox();
            this.Bot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.OverTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnderTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bot)).BeginInit();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Image = global::Clothes_Pick.Properties.Resources.back140i;
            this.Back.Location = new System.Drawing.Point(0, 0);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(52, 45);
            this.Back.TabIndex = 0;
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(379, 267);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(89, 34);
            this.Next.TabIndex = 1;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Previous
            // 
            this.Previous.Location = new System.Drawing.Point(12, 267);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(89, 34);
            this.Previous.TabIndex = 2;
            this.Previous.Text = "Previous";
            this.Previous.UseVisualStyleBackColor = true;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // OverTop
            // 
            this.OverTop.Location = new System.Drawing.Point(156, 45);
            this.OverTop.Name = "OverTop";
            this.OverTop.Size = new System.Drawing.Size(157, 154);
            this.OverTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OverTop.TabIndex = 3;
            this.OverTop.TabStop = false;
            this.OverTop.Visible = false;
            // 
            // UnderTop
            // 
            this.UnderTop.Location = new System.Drawing.Point(156, 205);
            this.UnderTop.Name = "UnderTop";
            this.UnderTop.Size = new System.Drawing.Size(157, 154);
            this.UnderTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UnderTop.TabIndex = 4;
            this.UnderTop.TabStop = false;
            this.UnderTop.Visible = false;
            // 
            // Bot
            // 
            this.Bot.Location = new System.Drawing.Point(156, 365);
            this.Bot.Name = "Bot";
            this.Bot.Size = new System.Drawing.Size(157, 239);
            this.Bot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Bot.TabIndex = 5;
            this.Bot.TabStop = false;
            this.Bot.Visible = false;
            // 
            // PickMyClothes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.Controls.Add(this.Bot);
            this.Controls.Add(this.UnderTop);
            this.Controls.Add(this.OverTop);
            this.Controls.Add(this.Previous);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Back);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "PickMyClothes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.OverTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnderTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.PictureBox OverTop;
        private System.Windows.Forms.PictureBox UnderTop;
        private System.Windows.Forms.PictureBox Bot;
    }
}