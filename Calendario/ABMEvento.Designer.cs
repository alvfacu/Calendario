namespace Calendario
{
    partial class ABMEvento
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRepetir = new System.Windows.Forms.ComboBox();
            this.chkRepetir = new System.Windows.Forms.CheckBox();
            this.chkHora = new System.Windows.Forms.CheckBox();
            this.grHora = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.mHoraFin = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.mFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.mTitulo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mNotas = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grHora.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnCrear);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.mNotas);
            this.groupBox1.Controls.Add(this.cmbRepetir);
            this.groupBox1.Controls.Add(this.chkRepetir);
            this.groupBox1.Controls.Add(this.chkHora);
            this.groupBox1.Controls.Add(this.grHora);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.mTitulo);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 315);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo Evento";
            // 
            // cmbRepetir
            // 
            this.cmbRepetir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRepetir.Enabled = false;
            this.cmbRepetir.FormattingEnabled = true;
            this.cmbRepetir.Items.AddRange(new object[] {
            "No se repite",
            "Todos los días",
            "Todas las semanas",
            "Todos los meses",
            "Todos los años"});
            this.cmbRepetir.Location = new System.Drawing.Point(87, 164);
            this.cmbRepetir.Name = "cmbRepetir";
            this.cmbRepetir.Size = new System.Drawing.Size(122, 21);
            this.cmbRepetir.TabIndex = 10;
            // 
            // chkRepetir
            // 
            this.chkRepetir.AutoSize = true;
            this.chkRepetir.Location = new System.Drawing.Point(18, 166);
            this.chkRepetir.Name = "chkRepetir";
            this.chkRepetir.Size = new System.Drawing.Size(63, 17);
            this.chkRepetir.TabIndex = 9;
            this.chkRepetir.Text = "Repetir:";
            this.chkRepetir.UseVisualStyleBackColor = true;
            this.chkRepetir.CheckedChanged += new System.EventHandler(this.chkRepetir_CheckedChanged);
            // 
            // chkHora
            // 
            this.chkHora.AutoSize = true;
            this.chkHora.Location = new System.Drawing.Point(220, 59);
            this.chkHora.Name = "chkHora";
            this.chkHora.Size = new System.Drawing.Size(15, 14);
            this.chkHora.TabIndex = 8;
            this.chkHora.UseVisualStyleBackColor = true;
            this.chkHora.CheckedChanged += new System.EventHandler(this.chkHora_CheckedChanged);
            // 
            // grHora
            // 
            this.grHora.Controls.Add(this.label4);
            this.grHora.Controls.Add(this.label5);
            this.grHora.Controls.Add(this.mHoraInicio);
            this.grHora.Controls.Add(this.mHoraFin);
            this.grHora.Enabled = false;
            this.grHora.Location = new System.Drawing.Point(240, 56);
            this.grHora.Name = "grHora";
            this.grHora.Size = new System.Drawing.Size(171, 92);
            this.grHora.TabIndex = 7;
            this.grHora.TabStop = false;
            this.grHora.Text = "Hora";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Inicio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fin:";
            // 
            // mHoraInicio
            // 
            this.mHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.mHoraInicio.Location = new System.Drawing.Point(64, 25);
            this.mHoraInicio.Name = "mHoraInicio";
            this.mHoraInicio.Size = new System.Drawing.Size(82, 20);
            this.mHoraInicio.TabIndex = 2;
            this.mHoraInicio.Value = new System.DateTime(2017, 5, 18, 0, 0, 0, 0);
            // 
            // mHoraFin
            // 
            this.mHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.mHoraFin.Location = new System.Drawing.Point(64, 57);
            this.mHoraFin.Name = "mHoraFin";
            this.mHoraFin.Size = new System.Drawing.Size(82, 20);
            this.mHoraFin.TabIndex = 4;
            this.mHoraFin.Value = new System.DateTime(2017, 5, 18, 0, 0, 0, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.mFechaInicio);
            this.groupBox2.Controls.Add(this.mFechaFin);
            this.groupBox2.Location = new System.Drawing.Point(18, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 92);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Inicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fin:";
            // 
            // mFechaInicio
            // 
            this.mFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mFechaInicio.Location = new System.Drawing.Point(64, 25);
            this.mFechaInicio.Name = "mFechaInicio";
            this.mFechaInicio.Size = new System.Drawing.Size(97, 20);
            this.mFechaInicio.TabIndex = 2;
            // 
            // mFechaFin
            // 
            this.mFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mFechaFin.Location = new System.Drawing.Point(64, 57);
            this.mFechaFin.Name = "mFechaFin";
            this.mFechaFin.Size = new System.Drawing.Size(97, 20);
            this.mFechaFin.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Título Evento:";
            // 
            // mTitulo
            // 
            this.mTitulo.Location = new System.Drawing.Point(96, 25);
            this.mTitulo.Name = "mTitulo";
            this.mTitulo.Size = new System.Drawing.Size(315, 20);
            this.mTitulo.TabIndex = 0;
            this.mTitulo.Tag = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Descripción:";
            // 
            // mNotas
            // 
            this.mNotas.Location = new System.Drawing.Point(87, 205);
            this.mNotas.Multiline = true;
            this.mNotas.Name = "mNotas";
            this.mNotas.Size = new System.Drawing.Size(324, 51);
            this.mNotas.TabIndex = 13;
            this.mNotas.Tag = "";
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Calendario.Properties.Resources.Actions_edit_delete_icon__1_;
            this.btnSalir.Location = new System.Drawing.Point(381, 268);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 30);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Image = global::Calendario.Properties.Resources.Actions_dialog_ok_apply_icon__1_;
            this.btnCrear.Location = new System.Drawing.Point(345, 268);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(30, 30);
            this.btnCrear.TabIndex = 16;
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // ABMEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 343);
            this.Controls.Add(this.groupBox1);
            this.Name = "ABMEvento";
            this.Text = "Crear Nuevo Evento";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grHora.ResumeLayout(false);
            this.grHora.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox mTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker mFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker mFechaInicio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grHora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker mHoraInicio;
        private System.Windows.Forms.DateTimePicker mHoraFin;
        private System.Windows.Forms.CheckBox chkHora;
        private System.Windows.Forms.CheckBox chkRepetir;
        private System.Windows.Forms.ComboBox cmbRepetir;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mNotas;
    }
}