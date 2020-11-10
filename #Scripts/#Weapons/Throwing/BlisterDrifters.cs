using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Weapons.Throwing
{
    public class BlisterDrifters : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 30;
            item.width = 20;
            item.height = 20;
            item.noMelee = true;
            item.ranged = true;
            item.noUseGraphic = true;
            item.shootSpeed = 10;
            item.shoot = mod.ProjectileType("BlisterDriftersProjectile");
            item.value = 135000;
            item.useTime = 10;
            item.useAnimation = 21;
            item.rare = 4;
            item.useStyle = 1;
            item.knockBack = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 23;

        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Drifters");
            Tooltip.SetDefault("Two Really Fast Throwable Daggers.");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}