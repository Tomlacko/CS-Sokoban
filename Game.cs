using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public delegate void Trigger();
    public delegate void TileChange(int x, int y, Tile tile);

    class Game
    {
        readonly string[] originalLevelData;
        Tile[,] tiles;
        public readonly int width;
        public readonly int height;

        int playerX;
        int playerY;

        readonly int totalCrates;
        int completedCrates;

        Stack<Move> moveHistory;


        public int MoveCount { get { return moveHistory.Count; } }


        public event Trigger GameWon;
        public event TileChange TileUpdate;


        //--------------------------------

        public Game(string[] levelData)
        {
            //figure out level dimensions and do basic level data validation
            int height = 0;
            int width = 0;
            int playersFound = 0;
            int cratesFound = 0;
            int endpointsFound = 0;
            foreach(string line in levelData) {
                height++;
                width = Math.Max(width, line.Length);
                playersFound += line.Count(f => f == '@');
                cratesFound += line.Count(f => f == '$');
                endpointsFound += line.Count(f => f == '.');
                cratesFound += line.Count(f => f == '*');
                endpointsFound += line.Count(f => f == '*');
            }

            //raise exceptions
            if(height < 4 || width < 4) throw new Exception("Invalid level format - playing field is too small!");
            else if(playersFound != 1) throw new Exception("Invalid level - level needs to contain exactly 1 player tile! (Marked as @)");
            else if(cratesFound < 1) throw new Exception("Invalid level - level needs to contain at least one crate tile! (Marked as $)");
            else if(cratesFound != endpointsFound) throw new Exception("Invalid level - level needs to contain the same amount of crates and endpoints! (Marked as $ and .)");

            //initialize values
            originalLevelData = levelData;
            tiles = new Tile[width, height];
            totalCrates = cratesFound;
            this.width = width;
            this.height = height;
        }

        public void ResetAndInit()
        {
            moveHistory = new Stack<Move>();
            completedCrates = 0;

            /*int offset = 0;
            if(height<10) offset = (10-height)/2;*/

            for(int y = 0; y<height; y++) {
                int x = 0;
                foreach(char ch in originalLevelData[y]) {
                    if(ch=='#')
                        SetTile(x, y, Tile.Wall);
                    else if(ch=='@') {
                        playerX = x;
                        playerY = y;
                        SetTile(x, y, Tile.Player);
                        tiles[x, y] = Tile.Ground;
                    }
                    else if(ch=='$') {
                        SetTile(x, y, Tile.Crate);
                    }
                    else if(ch=='.')
                        SetTile(x, y, Tile.Endpoint);
                    else if(ch=='*') {
                        SetTile(x, y, Tile.CrateEndpoint);
                        completedCrates++;
                    }
                    else SetTile(x, y, Tile.Empty);

                    x++;
                }
                /*for(int i = x; i<width; i++)
                    SetTile(i, y, Tile.empty);*/
            }

            bool[] floodFillVisited = new bool[width*height];
            FloodFillGround(playerX, playerY, floodFillVisited);

            if(completedCrates>=totalCrates) OnGameWon();
        }

        public bool Move(MoveDirection dir)
        {
            if(completedCrates>=totalCrates)
                return false;

            int nextX = playerX;
            int nextY = playerY;
            ChangePosByDir(ref nextX, ref nextY, dir);

            if(tiles[nextX, nextY] == Tile.Ground || tiles[nextX, nextY] == Tile.Endpoint) {
                OnTileUpdate(playerX, playerY, tiles[playerX, playerY]);
                OnTileUpdate(nextX, nextY, Tile.Player);
                playerX = nextX;
                playerY = nextY;

                moveHistory.Push(new Move(dir, false));
            }
            else if(tiles[nextX, nextY] == Tile.Crate || tiles[nextX, nextY] == Tile.CrateEndpoint) {
                int crateNextX = nextX;
                int crateNextY = nextY;
                ChangePosByDir(ref crateNextX, ref crateNextY, dir);

                if(tiles[crateNextX, crateNextY] == Tile.Wall || tiles[crateNextX, crateNextY] == Tile.Crate || tiles[crateNextX, crateNextY] == Tile.CrateEndpoint) {
                    return false;
                }
                else if(tiles[crateNextX, crateNextY] == Tile.Ground) {
                    SetTile(crateNextX, crateNextY, Tile.Crate);
                }
                else if(tiles[crateNextX, crateNextY] == Tile.Endpoint) {
                    SetTile(crateNextX, crateNextY, Tile.CrateEndpoint);
                    completedCrates++;
                }

                if(tiles[nextX, nextY] == Tile.CrateEndpoint) {
                    tiles[nextX, nextY] = Tile.Endpoint;
                    completedCrates--;
                }
                else tiles[nextX, nextY] = Tile.Ground;

                OnTileUpdate(playerX, playerY, tiles[playerX, playerY]);
                OnTileUpdate(nextX, nextY, Tile.Player);


                playerX = nextX;
                playerY = nextY;

                moveHistory.Push(new Move(dir, true));
            }
            else return false;

            if(completedCrates>=totalCrates) OnGameWon();

            return true;
        }

        public bool UndoMove()
        {
            if(moveHistory == null || moveHistory.Count == 0)
                return false;

            Move move = moveHistory.Pop();

            int prevX = playerX;
            int prevY = playerY;
            ChangePosByDir(ref prevX, ref prevY, move.GetOppositeDirection());

            OnTileUpdate(prevX, prevY, Tile.Player);
            if(move.pushedCrate) {
                int crateX = playerX;
                int crateY = playerY;
                ChangePosByDir(ref crateX, ref crateY, move.direction);

                if(tiles[crateX, crateY]==Tile.CrateEndpoint) {
                    completedCrates--;
                    SetTile(crateX, crateY, Tile.Endpoint);
                }
                else SetTile(crateX, crateY, Tile.Ground);

                if(tiles[playerX, playerY]==Tile.Endpoint) {
                    completedCrates++;
                    SetTile(playerX, playerY, Tile.CrateEndpoint);
                }
                else SetTile(playerX, playerY, Tile.Crate);

            }
            else OnTileUpdate(playerX, playerY, tiles[playerX, playerY]);

            playerX = prevX;
            playerY = prevY;

            return true;
        }

        private void FloodFillGround(int x, int y, bool[] visited)
        {
            if(x < 0 || x >= width || y < 0 || y >= height || visited[y*width+x] || tiles[x, y]==Tile.Wall) return;
            
            visited[y*width+x] = true;
            
            if(tiles[x, y] == Tile.Empty)
                SetTile(x, y, Tile.Ground);

            FloodFillGround(x+1, y, visited);
            FloodFillGround(x-1, y, visited);
            FloodFillGround(x, y+1, visited);
            FloodFillGround(x, y-1, visited);
        }

        private void ChangePosByDir(ref int x, ref int y, MoveDirection dir)
        {
            if(dir == MoveDirection.Down) y++;
            else if(dir == MoveDirection.Up) y--;
            else if(dir == MoveDirection.Right) x++;
            else if(dir == MoveDirection.Left) x--;
        }

        private void SetTile(int x, int y, Tile tile)
        {
            if(tile != Tile.Player) tiles[x, y] = tile;
            OnTileUpdate(x, y, tile);
        }

        protected virtual void OnTileUpdate(int x, int y, Tile tile)
        {
            TileUpdate?.Invoke(x, y, tile);
        }

        protected virtual void OnGameWon()
        {
            GameWon?.Invoke();
        }
    }
}
