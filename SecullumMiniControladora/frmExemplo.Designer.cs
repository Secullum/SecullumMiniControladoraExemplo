using System;

namespace SecullumMiniControladora
{
    partial class frmExemplo
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
            this.btnAcionarRele = new System.Windows.Forms.Button();
            this.btnAcionarPorTempo = new System.Windows.Forms.Button();
            this.btnDesligar = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.comboReles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textIP = new System.Windows.Forms.TextBox();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxLog = new System.Windows.Forms.RichTextBox();
            this.txtTempo = new System.Windows.Forms.TextBox();
            this.lblTempo = new System.Windows.Forms.Label();
            this.btnDesconectar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAcionarRele
            // 
            this.btnAcionarRele.Location = new System.Drawing.Point(37, 211);
            this.btnAcionarRele.Name = "btnAcionarRele";
            this.btnAcionarRele.Size = new System.Drawing.Size(103, 23);
            this.btnAcionarRele.TabIndex = 0;
            this.btnAcionarRele.Text = "Acionar relé";
            this.btnAcionarRele.UseVisualStyleBackColor = true;
            this.btnAcionarRele.Click += new System.EventHandler(this.AcionarRele_Click);
            // 
            // btnAcionarPorTempo
            // 
            this.btnAcionarPorTempo.Location = new System.Drawing.Point(37, 240);
            this.btnAcionarPorTempo.Name = "btnAcionarPorTempo";
            this.btnAcionarPorTempo.Size = new System.Drawing.Size(115, 23);
            this.btnAcionarPorTempo.TabIndex = 2;
            this.btnAcionarPorTempo.Text = "Acionar por tempo";
            this.btnAcionarPorTempo.UseVisualStyleBackColor = true;
            this.btnAcionarPorTempo.Click += new System.EventHandler(this.AcionarRelePorTempo_Click);
            // 
            // btnDesligar
            // 
            this.btnDesligar.Location = new System.Drawing.Point(146, 211);
            this.btnDesligar.Name = "btnDesligar";
            this.btnDesligar.Size = new System.Drawing.Size(75, 23);
            this.btnDesligar.TabIndex = 2;
            this.btnDesligar.Text = "Desligar";
            this.btnDesligar.UseVisualStyleBackColor = true;
            this.btnDesligar.Click += new System.EventHandler(this.DesligarRele_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(102, 120);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(85, 23);
            this.btnConectar.TabIndex = 2;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.Conectar_Click);
            // 
            // comboReles
            // 
            this.comboReles.FormattingEnabled = true;
            this.comboReles.Location = new System.Drawing.Point(132, 173);
            this.comboReles.Name = "comboReles";
            this.comboReles.Size = new System.Drawing.Size(121, 23);
            this.comboReles.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selecione o relé";
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(135, 49);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(113, 23);
            this.textIP.TabIndex = 5;
            // 
            // txtPorta
            // 
            this.txtPorta.Location = new System.Drawing.Point(135, 78);
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(113, 23);
            this.txtPorta.TabIndex = 5;
            this.txtPorta.Text = "1999";
            this.txtPorta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidacaoApenasNumero_Keypress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Porta";
            // 
            // rtxLog
            // 
            this.rtxLog.Location = new System.Drawing.Point(37, 294);
            this.rtxLog.Name = "rtxLog";
            this.rtxLog.ReadOnly = true;
            this.rtxLog.Size = new System.Drawing.Size(305, 129);
            this.rtxLog.TabIndex = 8;
            this.rtxLog.Text = "";
            // 
            // txtTempo
            // 
            this.txtTempo.Location = new System.Drawing.Point(160, 240);
            this.txtTempo.MaxLength = 2;
            this.txtTempo.Name = "txtTempo";
            this.txtTempo.Size = new System.Drawing.Size(27, 23);
            this.txtTempo.TabIndex = 5;
            this.txtTempo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidacaoApenasNumero_Keypress);
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(193, 244);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(58, 15);
            this.lblTempo.TabIndex = 6;
            this.lblTempo.Text = "segundos";
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.Location = new System.Drawing.Point(193, 120);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(82, 23);
            this.btnDesconectar.TabIndex = 9;
            this.btnDesconectar.Text = "Desconectar";
            this.btnDesconectar.UseVisualStyleBackColor = true;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Log de eventos";
            // 
            // frmExemplo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 498);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.txtTempo);
            this.Controls.Add(this.rtxLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPorta);
            this.Controls.Add(this.textIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboReles);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.btnDesligar);
            this.Controls.Add(this.btnAcionarPorTempo);
            this.Controls.Add(this.btnAcionarRele);
            this.Name = "frmExemplo";
            this.Text = "SecullumMiniControladoraExemplo";
            this.Load += new System.EventHandler(this.frmExemplo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAcionarRele;
        private System.Windows.Forms.Button btnAcionarPorTempo;
        private System.Windows.Forms.Button btnDesligar;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.ComboBox comboReles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.TextBox txtPorta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxLog;
        private System.Windows.Forms.TextBox txtTempo;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Button btnDesconectar;
        private System.Windows.Forms.Label label4;
    }
}

