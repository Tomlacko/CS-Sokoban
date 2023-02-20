using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sokoban
{
    public partial class MainForm : Form
    {
        const int TileSize = 32;

        Game game;
        

        public MainForm()
        {
            InitializeComponent();
        }

        private void loadLevelFileBtn_Click(object sender, EventArgs e)
        {
            //let user choose a level file
            if(openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            //load level data from file
            string[] levelData;
            try {
                levelData = File.ReadAllLines(openFileDialog.FileName);
            }
            catch(Exception) {
                MessageBox.Show("Failed to open/read level file!", "Level load failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //try creating game
            try {
                game = new Game(levelData);
            }
            catch(Exception exception) {
                MessageBox.Show(exception.Message, "Level load failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //setup table layout

            gameFieldTable.Controls.Clear();
            gameFieldTable.ColumnStyles.Clear();
            gameFieldTable.RowStyles.Clear();

            gameFieldTable.ColumnCount = game.width;
            gameFieldTable.RowCount = game.height;

            gameFieldTable.Width = gameFieldTable.ColumnCount*TileSize;
            gameFieldTable.Height = gameFieldTable.RowCount*TileSize;

            //set table row/column styles
            for(int i = 0; i<gameFieldTable.ColumnCount; i++)
                gameFieldTable.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.AutoSize });
            for(int i = 0; i<gameFieldTable.RowCount; i++)
                gameFieldTable.RowStyles.Add(new RowStyle() { SizeType = SizeType.AutoSize });


            //populate table with pictureboxes
            for(int y = 0; y<gameFieldTable.RowCount; y++) {
                for(int x = 0; x<gameFieldTable.ColumnCount; x++) {
                    gameFieldTable.Controls.Add(new PictureBox() { Image = Properties.Resources.empty, SizeMode = PictureBoxSizeMode.AutoSize, Margin = new Padding(0) }, x, y);
                }
            }

            //set form size
            this.Size = new Size(this.MinimumSize.Width + Math.Max(gameFieldTable.ColumnCount-4, 0)*TileSize, this.MinimumSize.Height + Math.Max(gameFieldTable.RowCount-10, 0)*TileSize);

            //init game
            game.GameWon += ShowWin;
            game.TileUpdate += SetTile;
            game.ResetAndInit();

            SetMoves(game.MoveCount);
            levelNameLbl.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
            restartBtn.Enabled = true;
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            AskAndRestart();
        }

        private void undoBtn_Click(object sender, EventArgs e)
        {
            if(game.UndoMove())
                SetMoves(game.MoveCount);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(game==null) return;

            bool success = false;

            e.SuppressKeyPress = true;
            e.Handled = true;
            //arrow keys don't work because winforms is stupid and the only workaround I've found is way too hacky and stupid to implement it just for this :kekw:
            if(/*e.KeyCode == Keys.Up ||*/ e.KeyCode == Keys.W)
                success = game.Move(MoveDirection.Up);
            else if(/*e.KeyCode == Keys.Down ||*/ e.KeyCode == Keys.S)
                success = game.Move(MoveDirection.Down);
            else if(/*e.KeyCode == Keys.Left ||*/ e.KeyCode == Keys.A)
                success = game.Move(MoveDirection.Left);
            else if(/*e.KeyCode == Keys.Right ||*/ e.KeyCode == Keys.D)
                success = game.Move(MoveDirection.Right);
            else if(/*e.KeyCode == Keys.RControlKey ||*/ e.KeyCode == Keys.F)
                success = game.UndoMove();
            else if(e.KeyCode == Keys.R)
                AskAndRestart();
            else {
                e.SuppressKeyPress = false;
                e.Handled = false;
            }

            if(success)
                SetMoves(game.MoveCount);
        }


        //custom functions

        private void AskAndRestart()
        {
            if(MessageBox.Show("Are you sure you want to restart this level?", "Confirm restart", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                game.ResetAndInit();
                SetMoves(game.MoveCount);
            }
        }

        private void SetMoves(int num)
        {
            movesLbl.Text = num.ToString();
            undoBtn.Enabled = num!=0;
        }

        private void ShowWin()
        {
            MessageBox.Show("Congratulations, you won!", "You Won!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetTile(int x, int y, Tile tile)
        {
            //((PictureBox)gameFieldTable.GetControlFromPosition(x, y)).Image = (Image)Properties.Resources.ResourceManager.GetObject(tile.ToString());
            
            Image img;
            switch(tile) {
                case Tile.Ground:
                    img = Properties.Resources.ground;
                    break;
                case Tile.Wall:
                    img = Properties.Resources.wall;
                    break;
                case Tile.Crate:
                    img = Properties.Resources.crate;
                    break;
                case Tile.Endpoint:
                    img = Properties.Resources.endpoint;
                    break;
                case Tile.CrateEndpoint:
                    img = Properties.Resources.crate_endpoint;
                    break;
                case Tile.Player:
                    img = Properties.Resources.player;
                    break;
                default:
                    img = Properties.Resources.empty;
                    break;
            }

            ((PictureBox)gameFieldTable.GetControlFromPosition(x, y)).Image = img;
        }
    }
}