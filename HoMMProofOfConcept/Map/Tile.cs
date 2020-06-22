using System;
using System.Collections.Generic;
using System.Text;

namespace HoMMProofOfConcept.Map
{
    public enum TerrainEnum
    {
        grass, 
        dirt, 
        desert, 
        water,
        swamp,
        lava, 
        rough
    }
    class Tile
    {
        public TerrainEnum Terrain { get; set; }
        public Hero Guard { get; set; } = null;
        public Tile(TerrainEnum Terrain)
        {
            this.Terrain = Terrain;
        }
        public static Tile GetTileRandom()
        {
            Random r = new Random();
            
            r.Next(0, 10);

            return new Tile(TerrainEnum.desert);
        }
    }
}
