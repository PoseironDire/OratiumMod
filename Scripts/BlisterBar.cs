using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Bars
{
    public class BlisterBar : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 99;
            item.value = 9000;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Bar");
            Tooltip.SetDefault("'Shiny! Or Is It Glowing?'");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterOre"), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
