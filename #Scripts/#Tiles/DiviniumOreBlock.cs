using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace OratiumMod.Items.Tiles
{
    public class DiviniteOreBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            mineResist = 3f;
            minPick = 70;
            drop = mod.ItemType("DiviniteOre");
            AddMapEntry(new Color(30, 25, 255));
        }

    }
}
