using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace OratiumMod.Items.Tiles
{
    public class BlisterOreBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            mineResist = 3f;
            minPick = 70;
            drop = mod.ItemType("BlisterOre");
            AddMapEntry(new Color(30, 255, 20));
        }

    }
}
