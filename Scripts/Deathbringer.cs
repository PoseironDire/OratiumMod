using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Weapons.Swords
{
    public class Deathbringer : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 931;
            item.melee = true;
            item.width = 20;
            item.height = 20;
            item.value = 100000;
            item.useTime = 7;
            item.useAnimation = 8;
            item.rare = 10;
            item.useStyle = 1;
            item.knockBack = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 200;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deathbringer");
            Tooltip.SetDefault("Bringer of Death, what can i say..");
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