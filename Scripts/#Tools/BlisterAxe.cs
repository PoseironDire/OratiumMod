using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Tools
{
    public class BlisterAxe : ModItem
    {
        public override void SetDefaults()
        {
            item.melee = true;
            item.damage = 32;
            item.width = 48;
            item.height = 48;
            item.useTime = 12;
            item.useAnimation = 12;
            item.axe = 115;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 90000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Axe");
            Tooltip.SetDefault("Faster Than Something...");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 9);
            recipe.AddIngredient(mod.ItemType("SoulofIgnite"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
