using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace OratiumMod.Items.Tiles
{
    public class AdamantiumOreBlock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            mineResist = 3f;
            minPick = 70;
            drop = mod.ItemType("AdamantiumOre");
            AddMapEntry(new Color(255, 255, 20));
        }
    }
}
