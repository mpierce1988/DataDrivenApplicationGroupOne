namespace HotelApp
{
    partial class Rooms
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
            this.cboHotel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cboRoomType = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblSelectedRoomType = new System.Windows.Forms.Label();
            this.btnCancelDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // cboHotel
            // 
            this.cboHotel.Enabled = false;
            this.cboHotel.FormattingEnabled = true;
            this.cboHotel.Location = new System.Drawing.Point(120, 43);
            this.cboHotel.Name = "cboHotel";
            this.cboHotel.Size = new System.Drawing.Size(121, 24);
            this.cboHotel.TabIndex = 0;
            this.cboHotel.SelectionChangeCommitted += new System.EventHandler(this.cboHotel_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hotel:";
            // 
            // dgvRooms
            // 
            this.dgvRooms.AllowUserToAddRows = false;
            this.dgvRooms.AllowUserToDeleteRows = false;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Location = new System.Drawing.Point(12, 187);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.ReadOnly = true;
            this.dgvRooms.RowHeadersWidth = 51;
            this.dgvRooms.RowTemplate.Height = 24;
            this.dgvRooms.Size = new System.Drawing.Size(776, 127);
            this.dgvRooms.TabIndex = 2;
            this.dgvRooms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.HandleCellClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(130, 356);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 63);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(277, 356);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(100, 63);
            this.btnModify.TabIndex = 4;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(424, 356);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 63);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cboRoomType
            // 
            this.cboRoomType.FormattingEnabled = true;
            this.cboRoomType.Location = new System.Drawing.Point(303, 131);
            this.cboRoomType.Name = "cboRoomType";
            this.cboRoomType.Size = new System.Drawing.Size(169, 24);
            this.cboRoomType.TabIndex = 6;
            this.cboRoomType.SelectionChangeCommitted += new System.EventHandler(this.cboRoomType_SelectionChangeCommitted);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(489, 131);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(217, 22);
            this.txtDescription.TabIndex = 7;
            // 
            // lblSelectedRoomType
            // 
            this.lblSelectedRoomType.AutoSize = true;
            this.lblSelectedRoomType.Location = new System.Drawing.Point(147, 134);
            this.lblSelectedRoomType.Name = "lblSelectedRoomType";
            this.lblSelectedRoomType.Size = new System.Drawing.Size(139, 16);
            this.lblSelectedRoomType.TabIndex = 8;
            this.lblSelectedRoomType.Text = "Selected Room Type:";
            // 
            // btnCancelDelete
            // 
            this.btnCancelDelete.Location = new System.Drawing.Point(571, 356);
            this.btnCancelDelete.Name = "btnCancelDelete";
            this.btnCancelDelete.Size = new System.Drawing.Size(100, 63);
            this.btnCancelDelete.TabIndex = 9;
            this.btnCancelDelete.Text = "Cancel";
            this.btnCancelDelete.UseVisualStyleBackColor = true;
            this.btnCancelDelete.Click += new System.EventHandler(this.btnCancelDelete_Click);
            // 
            // Rooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelDelete);
            this.Controls.Add(this.lblSelectedRoomType);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cboRoomType);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboHotel);
            this.Name = "Rooms";
            this.Text = "Rooms";
            this.Load += new System.EventHandler(this.Rooms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboHotel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox cboRoomType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblSelectedRoomType;
        private System.Windows.Forms.Button btnCancelDelete;
    }
}