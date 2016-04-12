namespace WinFormsExample
{
    partial class FrmMain
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
            this.txtNewTodo = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstTodos = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClearCompleted = new System.Windows.Forms.Button();
            this.btnFilterAll = new System.Windows.Forms.Button();
            this.btnFilterActive = new System.Windows.Forms.Button();
            this.btnFilterCompleted = new System.Windows.Forms.Button();
            this.lblItemsLeft = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNewTodo
            // 
            this.txtNewTodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewTodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewTodo.Location = new System.Drawing.Point(13, 13);
            this.txtNewTodo.Name = "txtNewTodo";
            this.txtNewTodo.Size = new System.Drawing.Size(402, 20);
            this.txtNewTodo.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(421, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lstTodos
            // 
            this.lstTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTodos.CheckBoxes = true;
            this.lstTodos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colDescription});
            this.lstTodos.GridLines = true;
            this.lstTodos.Location = new System.Drawing.Point(13, 40);
            this.lstTodos.Name = "lstTodos";
            this.lstTodos.Size = new System.Drawing.Size(483, 354);
            this.lstTodos.TabIndex = 2;
            this.lstTodos.UseCompatibleStateImageBehavior = false;
            this.lstTodos.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 413;
            // 
            // btnClearCompleted
            // 
            this.btnClearCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCompleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCompleted.Location = new System.Drawing.Point(391, 400);
            this.btnClearCompleted.Name = "btnClearCompleted";
            this.btnClearCompleted.Size = new System.Drawing.Size(105, 23);
            this.btnClearCompleted.TabIndex = 3;
            this.btnClearCompleted.Text = "Clear Completed";
            this.btnClearCompleted.UseVisualStyleBackColor = true;
            // 
            // btnFilterAll
            // 
            this.btnFilterAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilterAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterAll.Location = new System.Drawing.Point(127, 400);
            this.btnFilterAll.Name = "btnFilterAll";
            this.btnFilterAll.Size = new System.Drawing.Size(79, 23);
            this.btnFilterAll.TabIndex = 4;
            this.btnFilterAll.Text = "All";
            this.btnFilterAll.UseVisualStyleBackColor = true;
            // 
            // btnFilterActive
            // 
            this.btnFilterActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilterActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterActive.Location = new System.Drawing.Point(212, 400);
            this.btnFilterActive.Name = "btnFilterActive";
            this.btnFilterActive.Size = new System.Drawing.Size(79, 23);
            this.btnFilterActive.TabIndex = 5;
            this.btnFilterActive.Text = "Active";
            this.btnFilterActive.UseVisualStyleBackColor = true;
            // 
            // btnFilterCompleted
            // 
            this.btnFilterCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilterCompleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterCompleted.Location = new System.Drawing.Point(297, 400);
            this.btnFilterCompleted.Name = "btnFilterCompleted";
            this.btnFilterCompleted.Size = new System.Drawing.Size(79, 23);
            this.btnFilterCompleted.TabIndex = 6;
            this.btnFilterCompleted.Text = "Completed";
            this.btnFilterCompleted.UseVisualStyleBackColor = true;
            // 
            // lblItemsLeft
            // 
            this.lblItemsLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItemsLeft.AutoSize = true;
            this.lblItemsLeft.Location = new System.Drawing.Point(12, 405);
            this.lblItemsLeft.Name = "lblItemsLeft";
            this.lblItemsLeft.Size = new System.Drawing.Size(57, 13);
            this.lblItemsLeft.TabIndex = 7;
            this.lblItemsLeft.Text = "0 items left";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 433);
            this.Controls.Add(this.lblItemsLeft);
            this.Controls.Add(this.btnFilterAll);
            this.Controls.Add(this.btnFilterCompleted);
            this.Controls.Add(this.btnFilterActive);
            this.Controls.Add(this.btnClearCompleted);
            this.Controls.Add(this.lstTodos);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNewTodo);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Todo App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewTodo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lstTodos;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.Button btnClearCompleted;
        private System.Windows.Forms.Button btnFilterAll;
        private System.Windows.Forms.Button btnFilterActive;
        private System.Windows.Forms.Button btnFilterCompleted;
        private System.Windows.Forms.Label lblItemsLeft;
    }
}

