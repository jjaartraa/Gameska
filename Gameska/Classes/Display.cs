using System;
using System.Collections.Generic;
using System.Text;

namespace Gameska.Classes
{
    class Display
    {
        private char[,] View;
        private char[,] Map;
        private int Resolution;
        private int centerPosX;
        private int centerPosY;
        private int PlayerPosX;
        private int PlayerPosY;

        public Display(char[,] map, int res, int PPX, int PPY)
        {
            if (res % 2 == 0)                   //If the resolution is even number, we can't center the player effectively.
            {
                res++;
            }

            this.Map = map;
            this.Resolution = res;
            this.PlayerPosX = PPX;
            this.PlayerPosY = PPY;

        }

        public string Refresh()
        {
            GetCenterPos();
            string View = "";
            int ViewX = centerPosX - Resolution / 2;    // Set top left coordinates of view to load the map
            int ViewY = centerPosY - Resolution / 4;

            for (int Y = 0; Y < Resolution/2; Y++)
            {
                for (int X = 0; X < Resolution; X++)
                {
                    View += Map[ViewX + X, ViewY + Y];
                }
                View += '\n';
            }
            return View;
        }

        private void GetCenterPos()     // Center the position of view on the player if he is far away from edge of map, or set it so player can't see out of map boundaries.
        {
            if (PlayerPosX >= Resolution / 2)
            {
                centerPosX = PlayerPosX;
            }
            else
            {
                centerPosX = Resolution / 2;
            }

            if (PlayerPosY >= Resolution / 4)   // Height of view is halved because characters height and width is not the same. X + Y/2 creates approx square view, X + Y is more like rectangle (not proportional and not pretty to look at).
            {
                centerPosY = PlayerPosY;
            }
            else
            {
                centerPosY = Resolution / 4;
            }
        }

        public void PlayerMove(string dir)
        {
            switch (dir)
            {
                case "W":
                    if (Map[PlayerPosX,PlayerPosY-1] != '▓')
                    {
                        ClearPlayerPos();
                        PlayerPosY--;
                        SetNewPlayerPos();
                    }
                    break;

                case "A":
                    if (Map[PlayerPosX-1, PlayerPosY] != '▓')
                    {
                        ClearPlayerPos();
                        PlayerPosX--;
                        SetNewPlayerPos();
                    }
                    break;

                case "S":
                    if (Map[PlayerPosX, PlayerPosY + 1] != '▓')
                    {
                        ClearPlayerPos();
                        PlayerPosY++;
                        SetNewPlayerPos();
                    }
                    break;

                case "D":
                    if (Map[PlayerPosX + 1, PlayerPosY] != '▓')
                    {
                        ClearPlayerPos();
                        PlayerPosX++;
                        SetNewPlayerPos();
                    }
                    break;
                default:
                    break;
            }
        }

        private void ClearPlayerPos()
        {
            Map[PlayerPosX, PlayerPosY] = ' ';
        }

        private void SetNewPlayerPos()
        {
            Map[PlayerPosX, PlayerPosY] = '@';
        }
    }
}
