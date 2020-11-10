using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Bars
{
    public class AdamantiumBar : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 99;
            item.value = 9000;
            item.rare = 4;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantium Bar");
            Tooltip.SetDefault("'Heavy & strong!'");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("AdamantiumOre"), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
