namespace NC_UI
{
    partial class NC_CreateRecipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NC_CreateRecipe));
            this.cancelRecipeButton = new System.Windows.Forms.Button();
            this.createRecipeButton = new System.Windows.Forms.Button();
            this.recipeNameTextBox = new System.Windows.Forms.TextBox();
            this.addFoodButton = new System.Windows.Forms.Button();
            this.foodDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Per100g = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removeFoodButton = new System.Windows.Forms.Button();
            this.saveRecipeButton = new System.Windows.Forms.Button();
            this.addFoodComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.foodDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelRecipeButton
            // 
            this.cancelRecipeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelRecipeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelRecipeButton.Location = new System.Drawing.Point(863, 696);
            this.cancelRecipeButton.Name = "cancelRecipeButton";
            this.cancelRecipeButton.Size = new System.Drawing.Size(144, 41);
            this.cancelRecipeButton.TabIndex = 9;
            this.cancelRecipeButton.Text = "Cancel";
            this.cancelRecipeButton.UseVisualStyleBackColor = true;
            this.cancelRecipeButton.Click += new System.EventHandler(this.CancelRecipeButton_Click);
            // 
            // createRecipeButton
            // 
            this.createRecipeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.createRecipeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createRecipeButton.Location = new System.Drawing.Point(152, 696);
            this.createRecipeButton.Name = "createRecipeButton";
            this.createRecipeButton.Size = new System.Drawing.Size(144, 41);
            this.createRecipeButton.TabIndex = 8;
            this.createRecipeButton.Text = "Create";
            this.createRecipeButton.UseVisualStyleBackColor = true;
            this.createRecipeButton.Click += new System.EventHandler(this.CreateRecipeButton_Click);
            // 
            // recipeNameTextBox
            // 
            this.recipeNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recipeNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipeNameTextBox.Location = new System.Drawing.Point(323, 12);
            this.recipeNameTextBox.Name = "recipeNameTextBox";
            this.recipeNameTextBox.Size = new System.Drawing.Size(495, 38);
            this.recipeNameTextBox.TabIndex = 5;
            this.recipeNameTextBox.Tag = "Name of the recipe...";
            this.recipeNameTextBox.Text = "Name of the recipe...";
            this.recipeNameTextBox.Enter += new System.EventHandler(this.RecipeNameTextBox_Enter);
            this.recipeNameTextBox.Leave += new System.EventHandler(this.RecipeNameTextBox_Leave);
            // 
            // addFoodButton
            // 
            this.addFoodButton.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFoodButton.Location = new System.Drawing.Point(260, 75);
            this.addFoodButton.Name = "addFoodButton";
            this.addFoodButton.Size = new System.Drawing.Size(141, 41);
            this.addFoodButton.TabIndex = 10;
            this.addFoodButton.Text = "Add food";
            this.addFoodButton.UseVisualStyleBackColor = true;
            this.addFoodButton.Click += new System.EventHandler(this.AddFoodButton_Click);
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.foodDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.foodDataGridView.Location = new System.Drawing.Point(507, 133);
            this.foodDataGridView.Name = "foodDataGridView";
            this.foodDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.foodDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.foodDataGridView.Size = new System.Drawing.Size(500, 540);
            this.foodDataGridView.TabIndex = 11;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Format = "N2";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.FillWeight = 149.2386F;
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
            this.Per100g.FillWeight = 50.76144F;
            this.Per100g.HeaderText = "Grams";
            this.Per100g.MinimumWidth = 50;
            this.Per100g.Name = "Per100g";
            this.Per100g.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // removeFoodButton
            // 
            this.removeFoodButton.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeFoodButton.Location = new System.Drawing.Point(656, 75);
            this.removeFoodButton.Name = "removeFoodButton";
            this.removeFoodButton.Size = new System.Drawing.Size(216, 41);
            this.removeFoodButton.TabIndex = 12;
            this.removeFoodButton.Text = "Remove selected";
            this.removeFoodButton.UseVisualStyleBackColor = true;
            this.removeFoodButton.Click += new System.EventHandler(this.RemoveFoodButton_Click);
            // 
            // saveRecipeButton
            // 
            this.saveRecipeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveRecipeButton.Enabled = false;
            this.saveRecipeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveRecipeButton.Location = new System.Drawing.Point(477, 693);
            this.saveRecipeButton.Name = "saveRecipeButton";
            this.saveRecipeButton.Size = new System.Drawing.Size(168, 47);
            this.saveRecipeButton.TabIndex = 14;
            this.saveRecipeButton.Text = "Save";
            this.saveRecipeButton.UseVisualStyleBackColor = true;
            this.saveRecipeButton.Click += new System.EventHandler(this.SaveRecipeButton_Click);
            // 
            // addFoodComboBox
            // 
            this.addFoodComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.addFoodComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.addFoodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addFoodComboBox.FormattingEnabled = true;
            this.addFoodComboBox.Location = new System.Drawing.Point(152, 133);
            this.addFoodComboBox.Name = "addFoodComboBox";
            this.addFoodComboBox.Size = new System.Drawing.Size(329, 23);
            this.addFoodComboBox.TabIndex = 15;
            // 
            // NC_CreateRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.addFoodComboBox);
            this.Controls.Add(this.saveRecipeButton);
            this.Controls.Add(this.removeFoodButton);
            this.Controls.Add(this.foodDataGridView);
            this.Controls.Add(this.addFoodButton);
            this.Controls.Add(this.cancelRecipeButton);
            this.Controls.Add(this.createRecipeButton);
            this.Controls.Add(this.recipeNameTextBox);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NC_CreateRecipe";
            this.Text = "NC_CreateRecipe";
            ((System.ComponentModel.ISupportInitialize)(this.foodDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelRecipeButton;
        private System.Windows.Forms.Button createRecipeButton;
        private System.Windows.Forms.TextBox recipeNameTextBox;
        private System.Windows.Forms.Button addFoodButton;
        private System.Windows.Forms.DataGridView foodDataGridView;
        private System.Windows.Forms.Button removeFoodButton;
        private System.Windows.Forms.Button saveRecipeButton;
        private System.Windows.Forms.ComboBox addFoodComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Per100g;
    }
}