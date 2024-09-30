namespace Proyecto.Formularios
{
    partial class fmrAgendarCita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmrAgendarCita));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTerminar2 = new System.Windows.Forms.Button();
            this.dgvReasignar = new System.Windows.Forms.DataGridView();
            this.Elegirr = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdCitaa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.btnReasig = new System.Windows.Forms.Button();
            this.btnCanCita = new System.Windows.Forms.Button();
            this.dgvCancelarCitas = new System.Windows.Forms.DataGridView();
            this.Elegir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdCita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraCita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpBoton = new System.Windows.Forms.GroupBox();
            this.rdbSI = new System.Windows.Forms.RadioButton();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.cmbHorasAtención = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnReagendar = new System.Windows.Forms.Button();
            this.btnCancelarCita = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTipodeConsulta = new System.Windows.Forms.TextBox();
            this.cmbListaDoctores = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroDocumento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mtcFecha = new System.Windows.Forms.MonthCalendar();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReasignar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelarCitas)).BeginInit();
            this.grpBoton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(981, 42);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(288, 430);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // btnTerminar2
            // 
            this.btnTerminar2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar2.Location = new System.Drawing.Point(780, 347);
            this.btnTerminar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTerminar2.Name = "btnTerminar2";
            this.btnTerminar2.Size = new System.Drawing.Size(85, 30);
            this.btnTerminar2.TabIndex = 76;
            this.btnTerminar2.Text = "Terminar";
            this.btnTerminar2.UseVisualStyleBackColor = true;
            this.btnTerminar2.Visible = false;
            this.btnTerminar2.Click += new System.EventHandler(this.btnTerminar2_Click_1);
            // 
            // dgvReasignar
            // 
            this.dgvReasignar.AllowUserToAddRows = false;
            this.dgvReasignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReasignar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Elegirr,
            this.IdCitaa});
            this.dgvReasignar.Location = new System.Drawing.Point(645, 209);
            this.dgvReasignar.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReasignar.Name = "dgvReasignar";
            this.dgvReasignar.RowHeadersVisible = false;
            this.dgvReasignar.RowHeadersWidth = 51;
            this.dgvReasignar.Size = new System.Drawing.Size(240, 130);
            this.dgvReasignar.TabIndex = 75;
            this.dgvReasignar.Visible = false;
            this.dgvReasignar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReasignar_CellContentClick_1);
            // 
            // Elegirr
            // 
            this.Elegirr.HeaderText = "Elegir";
            this.Elegirr.MinimumWidth = 4;
            this.Elegirr.Name = "Elegirr";
            this.Elegirr.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Elegirr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Elegirr.Width = 90;
            // 
            // IdCitaa
            // 
            this.IdCitaa.HeaderText = "Codigo Cita";
            this.IdCitaa.MinimumWidth = 6;
            this.IdCitaa.Name = "IdCitaa";
            this.IdCitaa.Width = 125;
            // 
            // btnTerminar
            // 
            this.btnTerminar.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar.Location = new System.Drawing.Point(780, 346);
            this.btnTerminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(85, 30);
            this.btnTerminar.TabIndex = 74;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Visible = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click_1);
            // 
            // btnReasig
            // 
            this.btnReasig.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReasig.Location = new System.Drawing.Point(635, 347);
            this.btnReasig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReasig.Name = "btnReasig";
            this.btnReasig.Size = new System.Drawing.Size(108, 30);
            this.btnReasig.TabIndex = 73;
            this.btnReasig.Text = "Reasignar";
            this.btnReasig.UseVisualStyleBackColor = true;
            this.btnReasig.Visible = false;
            this.btnReasig.Click += new System.EventHandler(this.btnReasig_Click_1);
            // 
            // btnCanCita
            // 
            this.btnCanCita.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCanCita.Location = new System.Drawing.Point(649, 346);
            this.btnCanCita.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCanCita.Name = "btnCanCita";
            this.btnCanCita.Size = new System.Drawing.Size(85, 31);
            this.btnCanCita.TabIndex = 72;
            this.btnCanCita.Text = "Cancelar";
            this.btnCanCita.UseVisualStyleBackColor = true;
            this.btnCanCita.Visible = false;
            this.btnCanCita.Click += new System.EventHandler(this.btnCanCita_Click_1);
            // 
            // dgvCancelarCitas
            // 
            this.dgvCancelarCitas.AllowUserToAddRows = false;
            this.dgvCancelarCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCancelarCitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Elegir,
            this.IdCita,
            this.FechaCita,
            this.HoraCita});
            this.dgvCancelarCitas.Location = new System.Drawing.Point(531, 208);
            this.dgvCancelarCitas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCancelarCitas.Name = "dgvCancelarCitas";
            this.dgvCancelarCitas.RowHeadersVisible = false;
            this.dgvCancelarCitas.RowHeadersWidth = 51;
            this.dgvCancelarCitas.Size = new System.Drawing.Size(451, 130);
            this.dgvCancelarCitas.TabIndex = 71;
            this.dgvCancelarCitas.Visible = false;
            // 
            // Elegir
            // 
            this.Elegir.HeaderText = "Elegir";
            this.Elegir.MinimumWidth = 4;
            this.Elegir.Name = "Elegir";
            this.Elegir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Elegir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Elegir.Width = 90;
            // 
            // IdCita
            // 
            this.IdCita.HeaderText = "Codigo Cita";
            this.IdCita.MinimumWidth = 6;
            this.IdCita.Name = "IdCita";
            this.IdCita.Width = 125;
            // 
            // FechaCita
            // 
            this.FechaCita.HeaderText = "Fecha";
            this.FechaCita.MinimumWidth = 6;
            this.FechaCita.Name = "FechaCita";
            this.FechaCita.Width = 150;
            // 
            // HoraCita
            // 
            this.HoraCita.HeaderText = "Hora";
            this.HoraCita.MinimumWidth = 6;
            this.HoraCita.Name = "HoraCita";
            this.HoraCita.Width = 125;
            // 
            // grpBoton
            // 
            this.grpBoton.Controls.Add(this.rdbSI);
            this.grpBoton.Controls.Add(this.rdbNo);
            this.grpBoton.Location = new System.Drawing.Point(685, 98);
            this.grpBoton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBoton.Name = "grpBoton";
            this.grpBoton.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBoton.Size = new System.Drawing.Size(200, 41);
            this.grpBoton.TabIndex = 70;
            this.grpBoton.TabStop = false;
            // 
            // rdbSI
            // 
            this.rdbSI.AutoSize = true;
            this.rdbSI.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSI.Location = new System.Drawing.Point(32, 11);
            this.rdbSI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbSI.Name = "rdbSI";
            this.rdbSI.Size = new System.Drawing.Size(42, 24);
            this.rdbSI.TabIndex = 33;
            this.rdbSI.TabStop = true;
            this.rdbSI.Text = "Si";
            this.rdbSI.UseVisualStyleBackColor = true;
            this.rdbSI.CheckedChanged += new System.EventHandler(this.rdbSI_CheckedChanged);
            // 
            // rdbNo
            // 
            this.rdbNo.AutoSize = true;
            this.rdbNo.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNo.Location = new System.Drawing.Point(117, 11);
            this.rdbNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(50, 24);
            this.rdbNo.TabIndex = 34;
            this.rdbNo.TabStop = true;
            this.rdbNo.Text = "No";
            this.rdbNo.UseVisualStyleBackColor = true;
            this.rdbNo.CheckedChanged += new System.EventHandler(this.rdbNo_CheckedChanged);
            // 
            // cmbHorasAtención
            // 
            this.cmbHorasAtención.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHorasAtención.FormattingEnabled = true;
            this.cmbHorasAtención.Items.AddRange(new object[] {
            "6:00 AM",
            "7:00 AM",
            "8:00 AM",
            "9:00 AM",
            "10:00 AM",
            "11:00 AM",
            "12:00 M",
            "1:00 PM",
            "2:00 PM",
            "3:00 PM",
            "4:00 PM",
            "5:00 PM",
            "6:00 PM",
            "7:00 PM"});
            this.cmbHorasAtención.Location = new System.Drawing.Point(361, 281);
            this.cmbHorasAtención.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbHorasAtención.Name = "cmbHorasAtención";
            this.cmbHorasAtención.Size = new System.Drawing.Size(121, 25);
            this.cmbHorasAtención.TabIndex = 69;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(359, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 17);
            this.label8.TabIndex = 68;
            this.label8.Text = "Horas Disponibles:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(663, 505);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 32);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(488, 505);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(108, 32);
            this.btnGuardar.TabIndex = 66;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // btnReagendar
            // 
            this.btnReagendar.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReagendar.Location = new System.Drawing.Point(801, 159);
            this.btnReagendar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReagendar.Name = "btnReagendar";
            this.btnReagendar.Size = new System.Drawing.Size(121, 32);
            this.btnReagendar.TabIndex = 65;
            this.btnReagendar.Text = "Reagendar cita";
            this.btnReagendar.UseVisualStyleBackColor = true;
            this.btnReagendar.Click += new System.EventHandler(this.btnReagendar_Click_1);
            // 
            // btnCancelarCita
            // 
            this.btnCancelarCita.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarCita.Location = new System.Drawing.Point(649, 159);
            this.btnCancelarCita.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarCita.Name = "btnCancelarCita";
            this.btnCancelarCita.Size = new System.Drawing.Size(108, 32);
            this.btnCancelarCita.TabIndex = 64;
            this.btnCancelarCita.Text = "Cancelar cita";
            this.btnCancelarCita.UseVisualStyleBackColor = true;
            this.btnCancelarCita.Click += new System.EventHandler(this.btnCancelarCita_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(484, 106);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 19);
            this.label7.TabIndex = 63;
            this.label7.Text = "Confirmación de la cita:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(527, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 19);
            this.label6.TabIndex = 62;
            this.label6.Text = "Tipo de consulta:";
            // 
            // txtTipodeConsulta
            // 
            this.txtTipodeConsulta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipodeConsulta.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipodeConsulta.Location = new System.Drawing.Point(663, 65);
            this.txtTipodeConsulta.Margin = new System.Windows.Forms.Padding(4);
            this.txtTipodeConsulta.Name = "txtTipodeConsulta";
            this.txtTipodeConsulta.Size = new System.Drawing.Size(271, 27);
            this.txtTipodeConsulta.TabIndex = 61;
            // 
            // cmbListaDoctores
            // 
            this.cmbListaDoctores.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbListaDoctores.FormattingEnabled = true;
            this.cmbListaDoctores.Location = new System.Drawing.Point(663, 25);
            this.cmbListaDoctores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbListaDoctores.Name = "cmbListaDoctores";
            this.cmbListaDoctores.Size = new System.Drawing.Size(272, 28);
            this.cmbListaDoctores.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(540, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 19);
            this.label4.TabIndex = 59;
            this.label4.Text = "Asignar doctor:";
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroDocumento.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDocumento.Location = new System.Drawing.Point(164, 31);
            this.txtNroDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(271, 26);
            this.txtNroDocumento.TabIndex = 58;
            this.txtNroDocumento.TextChanged += new System.EventHandler(this.txtNroDocumento_TextChanged);
            this.txtNroDocumento.Leave += new System.EventHandler(this.txtNroDocumento_Leave_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 19);
            this.label5.TabIndex = 57;
            this.label5.Text = "Documento paciente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 196);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 19);
            this.label1.TabIndex = 56;
            this.label1.Text = "Seleccione fecha y hora:";
            // 
            // mtcFecha
            // 
            this.mtcFecha.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.mtcFecha.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtcFecha.Location = new System.Drawing.Point(23, 239);
            this.mtcFecha.Name = "mtcFecha";
            this.mtcFecha.TabIndex = 55;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(164, 138);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(271, 26);
            this.txtTelefono.TabIndex = 54;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(79, 144);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 19);
            this.label11.TabIndex = 53;
            this.label11.Text = "Telefono:";
            // 
            // txtApellidos
            // 
            this.txtApellidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidos.Enabled = false;
            this.txtApellidos.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.Location = new System.Drawing.Point(164, 100);
            this.txtApellidos.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(271, 26);
            this.txtApellidos.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 51;
            this.label3.Text = "Apellidos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 50;
            this.label2.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(164, 65);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(271, 26);
            this.txtNombre.TabIndex = 49;
            // 
            // fmrAgendarCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 562);
            this.Controls.Add(this.btnTerminar2);
            this.Controls.Add(this.dgvReasignar);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.btnReasig);
            this.Controls.Add(this.btnCanCita);
            this.Controls.Add(this.dgvCancelarCitas);
            this.Controls.Add(this.grpBoton);
            this.Controls.Add(this.cmbHorasAtención);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnReagendar);
            this.Controls.Add(this.btnCancelarCita);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTipodeConsulta);
            this.Controls.Add(this.cmbListaDoctores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNroDocumento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtcFecha);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fmrAgendarCita";
            this.Text = "Agendar Cita";
            this.Load += new System.EventHandler(this.fmrAgendarCita_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReasignar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelarCitas)).EndInit();
            this.grpBoton.ResumeLayout(false);
            this.grpBoton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnTerminar2;
        private System.Windows.Forms.DataGridView dgvReasignar;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.Button btnReasig;
        private System.Windows.Forms.Button btnCanCita;
        private System.Windows.Forms.DataGridView dgvCancelarCitas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Elegir;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCita;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCita;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraCita;
        private System.Windows.Forms.GroupBox grpBoton;
        private System.Windows.Forms.RadioButton rdbSI;
        private System.Windows.Forms.RadioButton rdbNo;
        private System.Windows.Forms.ComboBox cmbHorasAtención;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnReagendar;
        private System.Windows.Forms.Button btnCancelarCita;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTipodeConsulta;
        private System.Windows.Forms.ComboBox cmbListaDoctores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNroDocumento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar mtcFecha;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Elegirr;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCitaa;
    }
}