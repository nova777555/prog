namespace Ping_Pong
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pic = new System.Windows.Forms.PictureBox();
            this.score = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LScore = new System.Windows.Forms.Label();
            this.RScore = new System.Windows.Forms.Label();
            this.StartText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(-1, 37);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(802, 413);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.score.Location = new System.Drawing.Point(203, 9);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(381, 24);
            this.score.TabIndex = 1;
            this.score.Text = "Игрок 1:                                              Игрок2:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LScore
            // 
            this.LScore.AutoSize = true;
            this.LScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LScore.Location = new System.Drawing.Point(286, 9);
            this.LScore.Name = "LScore";
            this.LScore.Size = new System.Drawing.Size(23, 25);
            this.LScore.TabIndex = 3;
            this.LScore.Text = "0";
            // 
            // RScore
            // 
            this.RScore.AutoSize = true;
            this.RScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RScore.Location = new System.Drawing.Point(604, 8);
            this.RScore.Name = "RScore";
            this.RScore.Size = new System.Drawing.Size(23, 25);
            this.RScore.TabIndex = 4;
            this.RScore.Text = "0";
            // 
            // StartText
            // 
            this.StartText.AutoSize = true;
            this.StartText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartText.Location = new System.Drawing.Point(211, 156);
            this.StartText.Name = "StartText";
            this.StartText.Size = new System.Drawing.Size(445, 145);
            this.StartText.TabIndex = 5;
            this.StartText.Text = "Управление:\r\nЛевый игрок: клавиши w s\r\nПравый игрок: стрелки вверх вниз\r\n\r\nНажмит" +
    "е Enter, чтобы начать ...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StartText);
            this.Controls.Add(this.RScore);
            this.Controls.Add(this.LScore);
            this.Controls.Add(this.score);
            this.Controls.Add(this.pic);
            this.Name = "Form1";
            this.Text = "Ping-Pong";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LScore;
        private System.Windows.Forms.Label RScore;
        private System.Windows.Forms.Label StartText;
    }
}

