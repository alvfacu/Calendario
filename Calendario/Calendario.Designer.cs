namespace Calendario
{
    partial class Calendario
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvEventos = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCambiarCuenta = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEventos
            // 
            this.dgvEventos.AllowUserToAddRows = false;
            this.dgvEventos.AllowUserToDeleteRows = false;
            this.dgvEventos.AllowUserToResizeRows = false;
            this.dgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventos.Location = new System.Drawing.Point(13, 12);
            this.dgvEventos.MultiSelect = false;
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.ReadOnly = true;
            this.dgvEventos.RowHeadersVisible = false;
            this.dgvEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEventos.Size = new System.Drawing.Size(908, 300);
            this.dgvEventos.TabIndex = 2;
            // 
            // btnCambiarCuenta
            // 
            this.btnCambiarCuenta.Image = global::Calendario.Properties.Resources.Users_Change_User_icon;
            this.btnCambiarCuenta.Location = new System.Drawing.Point(461, 318);
            this.btnCambiarCuenta.Name = "btnCambiarCuenta";
            this.btnCambiarCuenta.Size = new System.Drawing.Size(40, 40);
            this.btnCambiarCuenta.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnCambiarCuenta, "Cambiar Cuenta");
            this.btnCambiarCuenta.UseVisualStyleBackColor = true;
            this.btnCambiarCuenta.Click += new System.EventHandler(this.btnCambiarCuenta_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::Calendario.Properties.Resources.Actions_appointment_new_icon;
            this.btnAgregar.Location = new System.Drawing.Point(415, 318);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(40, 40);
            this.btnAgregar.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnAgregar, "Agregar Nuevo Evento");
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::Calendario.Properties.Resources.Calendar_icon;
            this.btnConsultar.Location = new System.Drawing.Point(369, 318);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(40, 40);
            this.btnConsultar.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnConsultar, "Actualizar");
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Calendario.Properties.Resources.Actions_edit_delete_icon__1_;
            this.btnSalir.Location = new System.Drawing.Point(507, 318);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(40, 40);
            this.btnSalir.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnSalir, "Salir");
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Calendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 370);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCambiarCuenta);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.dgvEventos);
            this.Name = "Calendario";
            this.Text = "Eventos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calendario_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEventos;
        private System.Windows.Forms.Button btnCambiarCuenta;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSalir;
    }
}

