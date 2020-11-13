using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Bars
{
    public class DiviniteBar : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.value = 9000;
            item.rare = 4;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divinite Bar");
            Tooltip.SetDefault("'¤Has]Been?Avoid?!'");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DiviniteOre"), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
