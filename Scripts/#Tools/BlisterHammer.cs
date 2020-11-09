using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Tools
{
    public class BlisterHammer : ModItem
    {
        public override void SetDefaults()
        {
            item.melee = true;
            item.damage = 20;
            item.width = 48;
            item.height = 48;
            item.useTime = 5;
            item.useAnimation = 9;
            item.crit = 4;
            item.hammer = 85;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Hammer");
            Tooltip.SetDefault("Fastet hammer out there!");
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
