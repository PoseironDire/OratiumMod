using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Ores
{
    public class DiviniteOre : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.value = 3000;
            item.width = 40;
            item.rare = 4;
            item.height = 40;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("DiviniteOreBlock");
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divinite Ore");
            Tooltip.SetDefault("'¤Has]Been?Avoid?!'");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
