
namespace Sokoban
{
    partial class MainForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.loadLevelFileBtn = new System.Windows.Forms.Button();
            this.restartBtn = new System.Windows.Forms.Button();
            this.hr1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.levelNameLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.movesLbl = new System.Windows.Forms.Label();
            this.undoBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.gameFieldTable = new System.Windows.Forms.TableLayoutPanel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // loadLevelFileBtn
            // 
            this.loadLevelFileBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.loadLevelFileBtn, "loadLevelFileBtn");
            this.loadLevelFileBtn.Name = "loadLevelFileBtn";
            this.loadLevelFileBtn.UseVisualStyleBackColor = true;
            this.loadLevelFileBtn.Click += new System.EventHandler(this.loadLevelFileBtn_Click);
            // 
            // restartBtn
            // 
            resources.ApplyResources(this.restartBtn, "restartBtn");
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.UseVisualStyleBackColor = true;
            this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
            // 
            // hr1
            // 
            this.hr1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.hr1, "hr1");
            this.hr1.Name = "hr1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // levelNameLbl
            // 
            resources.ApplyResources(this.levelNameLbl, "levelNameLbl");
            this.levelNameLbl.Name = "levelNameLbl";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // movesLbl
            // 
            resources.ApplyResources(this.movesLbl, "movesLbl");
            this.movesLbl.Name = "movesLbl";
            // 
            // undoBtn
            // 
            resources.ApplyResources(this.undoBtn, "undoBtn");
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.UseVisualStyleBackColor = true;
            this.undoBtn.Click += new System.EventHandler(this.undoBtn_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // gameFieldTable
            // 
            resources.ApplyResources(this.gameFieldTable, "gameFieldTable");
            this.gameFieldTable.Name = "gameFieldTable";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gameFieldTable);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.undoBtn);
            this.Controls.Add(this.movesLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.levelNameLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hr1);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.loadLevelFileBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadLevelFileBtn;
        private System.Windows.Forms.Button restartBtn;
        private System.Windows.Forms.Label hr1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label levelNameLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label movesLbl;
        private System.Windows.Forms.Button undoBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel gameFieldTable;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

