using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Tools
{
    public class BlisterPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.melee = true;
            item.damage = 30;
            item.width = 48;
            item.height = 48;
            item.useTime = 1;
            item.useAnimation = 8;
            item.pick = 205;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 180000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Pickaxe");
            Tooltip.SetDefault("'Mines Fast But Not Strong.'");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
