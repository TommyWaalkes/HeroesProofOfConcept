using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept.Map
{
    public class Map
    {
        Tile[,] MainMap { get; set; }
        List<Player> Players { get; set; }

        public Map(int Size, List<Player> Players)
        {
            MainMap = new Tile[Size,Size];
            this.Players = Players;
        }


    }
}
