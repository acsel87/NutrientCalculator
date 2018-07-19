namespace NC_UI
{
    partial class NC_CreateDayPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NC_CreateDayPlan));
            this.removeFoodButton = new System.Windows.Forms.Button();
            this.foodDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Per100g = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addFoodButton = new System.Windows.Forms.Button();
            this.cancelPlanButton = new System.Windows.Forms.Button();
            this.createPlanButton = new System.Windows.Forms.Button();
            this.planNameTextBox = new System.Windows.Forms.TextBox();
            this.savePlanButton = new System.Windows.Forms.Button();
            this.recipeDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removeRecipeButton = new System.Windows.Forms.Button();
            this.addRecipeButton = new System.Windows.Forms.Button();
            this.addFoodComboBox = new System.Windows.Forms.ComboBox();
            this.addRecipeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.foodDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // removeFoodButton
            // 
            this.removeFoodButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeFoodButton.Location = new System.Drawing.Point(857, 71);
            this.removeFoodButton.Name = "removeFoodButton";
            this.removeFoodButton.Size = new System.Drawing.Size(150, 30);
            this.removeFoodButton.TabIndex = 19;
            this.removeFoodButton.Text = "Remove selected";
            this.removeFoodButton.UseVisualStyleBackColor = true;
            this.removeFoodButton.Click += new System.EventHandler(this.RemoveFoodButton_Click);
            // 
            // foodDataGridView
            // 
            this.foodDataGridView.AllowUserToAddRows = false;
            this.foodDataGridView.AllowUserToDeleteRows = false;
            this.foodDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foodDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Per100g});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.foodDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.foodDataGridView.Location = new System.Drawing.Point(538, 107);
            this.foodDataGridView.Name = "foodDataGridView";
            this.foodDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.foodDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.foodDataGridView.Size = new System.Drawing.Size(469, 256);
            this.foodDataGridView.TabIndex = 18;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Format = "N2";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.FillWeight = 194.9239F;
            this.Column1.HeaderText = "Food";
            this.Column1.MinimumWidth = 300;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Per100g
            // 
            this.Per100g.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Per100g.DefaultCellStyle = dataGridViewCellStyle2;
            this.Per100g.FillWeight = 5.076141F;
            this.Per100g.HeaderText = "Grams";
            this.Per100g.MinimumWidth = 100;
            this.Per100g.Name = "Per100g";
            this.Per100g.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // addFoodButton
            // 
            this.addFoodButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFoodButton.Location = new System.Drawing.Point(183, 71);
            this.addFoodButton.Name = "addFoodButton";
            this.addFoodButton.Size = new System.Drawing.Size(100, 30);
            this.addFoodButton.TabIndex = 17;
            this.addFoodButton.Text = "Add food";
            this.addFoodButton.UseVisualStyleBackColor = true;
            this.addFoodButton.Click += new System.EventHandler(this.AddFoodButton_Click);
            // 
            // cancelPlanButton
            // 
            this.cancelPlanButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelPlanButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelPlanButton.Location = new System.Drawing.Point(907, 716);
            this.cancelPlanButton.Name = "cancelPlanButton";
            this.cancelPlanButton.Size = new System.Drawing.Size(100, 30);
            this.cancelPlanButton.TabIndex = 16;
            this.cancelPlanButton.Text = "Cancel";
            this.cancelPlanButton.UseVisualStyleBackColor = true;
            this.cancelPlanButton.Click += new System.EventHandler(this.CancelPlanButton_Click);
            // 
            // createPlanButton
            // 
            this.createPlanButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.createPlanButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPlanButton.Location = new System.Drawing.Point(183, 716);
            this.createPlanButton.Name = "createPlanButton";
            this.createPlanButton.Size = new System.Drawing.Size(100, 30);
            this.createPlanButton.TabIndex = 15;
            this.createPlanButton.Text = "Create";
            this.createPlanButton.UseVisualStyleBackColor = true;
            this.createPlanButton.Click += new System.EventHandler(this.CreatePlanButton_Click);
            // 
            // planNameTextBox
            // 
            this.planNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.planNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.planNameTextBox.Location = new System.Drawing.Point(199, 12);
            this.planNameTextBox.Name = "planNameTextBox";
            this.planNameTextBox.Size = new System.Drawing.Size(692, 38);
            this.planNameTextBox.TabIndex = 14;
            this.planNameTextBox.Text = "Name of the plan...";
            // 
            // savePlanButton
            // 
            this.savePlanButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.savePlanButton.Enabled = false;
            this.savePlanButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePlanButton.Location = new System.Drawing.Point(526, 716);
            this.savePlanButton.Name = "savePlanButton";
            this.savePlanButton.Size = new System.Drawing.Size(100, 30);
            this.savePlanButton.TabIndex = 22;
            this.savePlanButton.Text = "Save";
            this.savePlanButton.UseVisualStyleBackColor = true;
            this.savePlanButton.Click += new System.EventHandler(this.SavePlanButton_Click);
            // 
            // recipeDataGridView
            // 
            this.recipeDataGridView.AllowUserToAddRows = false;
            this.recipeDataGridView.AllowUserToDeleteRows = false;
            this.recipeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recipeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.recipeDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.recipeDataGridView.Location = new System.Drawing.Point(538, 421);
            this.recipeDataGridView.Name = "recipeDataGridView";
            this.recipeDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.recipeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.recipeDataGridView.Size = new System.Drawing.Size(469, 279);
            this.recipeDataGridView.TabIndex = 23;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Format = "N2";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.FillWeight = 194.9239F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Recipe";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 300;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.FillWeight = 5.076141F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Grams";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // removeRecipeButton
            // 
            this.removeRecipeButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeRecipeButton.Location = new System.Drawing.Point(857, 385);
            this.removeRecipeButton.Name = "removeRecipeButton";
            this.removeRecipeButton.Size = new System.Drawing.Size(150, 30);
            this.removeRecipeButton.TabIndex = 24;
            this.removeRecipeButton.Text = "Remove selected";
            this.removeRecipeButton.UseVisualStyleBackColor = true;
            this.removeRecipeButton.Click += new System.EventHandler(this.RemoveRecipeButton_Click);
            // 
            // addRecipeButton
            // 
            this.addRecipeButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRecipeButton.Location = new System.Drawing.Point(183, 385);
            this.addRecipeButton.Name = "addRecipeButton";
            this.addRecipeButton.Size = new System.Drawing.Size(100, 30);
            this.addRecipeButton.TabIndex = 25;
            this.addRecipeButton.Text = "Add recipe";
            this.addRecipeButton.UseVisualStyleBackColor = true;
            this.addRecipeButton.Click += new System.EventHandler(this.AddRecipeButton_Click);
            // 
            // addFoodComboBox
            // 
            this.addFoodComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.addFoodComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.addFoodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addFoodComboBox.FormattingEnabled = true;
            this.addFoodComboBox.Location = new System.Drawing.Point(183, 107);
            this.addFoodComboBox.Name = "addFoodComboBox";
            this.addFoodComboBox.Size = new System.Drawing.Size(329, 23);
            this.addFoodComboBox.TabIndex = 26;
            // 
            // addRecipeComboBox
            // 
            this.addRecipeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.addRecipeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.addRecipeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addRecipeComboBox.FormattingEnabled = true;
            this.addRecipeComboBox.Location = new System.Drawing.Point(183, 421);
            this.addRecipeComboBox.Name = "addRecipeComboBox";
            this.addRecipeComboBox.Size = new System.Drawing.Size(329, 23);
            this.addRecipeComboBox.TabIndex = 27;
            // 
            // NC_CreateDayPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.addRecipeComboBox);
            this.Controls.Add(this.addFoodComboBox);
            this.Controls.Add(this.addRecipeButton);
            this.Controls.Add(this.removeRecipeButton);
            this.Controls.Add(this.recipeDataGridView);
            this.Controls.Add(this.savePlanButton);
            this.Controls.Add(this.removeFoodButton);
            this.Controls.Add(this.foodDataGridView);
            this.Controls.Add(this.addFoodButton);
            this.Controls.Add(this.cancelPlanButton);
            this.Controls.Add(this.createPlanButton);
            this.Controls.Add(this.planNameTextBox);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NC_CreateDayPlan";
            this.Text = "NC_CreateDayPlan";
            ((System.ComponentModel.ISupportInitialize)(this.foodDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button removeFoodButton;
        private System.Windows.Forms.DataGridView foodDataGridView;
        private System.Windows.Forms.Button addFoodButton;
        private System.Windows.Forms.Button cancelPlanButton;
        private System.Windows.Forms.Button createPlanButton;
        private System.Windows.Forms.TextBox planNameTextBox;
        private System.Windows.Forms.Button savePlanButton;
        private System.Windows.Forms.DataGridView recipeDataGridView;
        private System.Windows.Forms.Button removeRecipeButton;
        private System.Windows.Forms.Button addRecipeButton;
        private System.Windows.Forms.ComboBox addFoodComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Per100g;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ComboBox addRecipeComboBox;
    }
}