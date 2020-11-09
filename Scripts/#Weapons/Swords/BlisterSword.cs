using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Weapons.Swords
{
    public class BlisterSword : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 31;
            item.melee = true;
            item.width = 20;
            item.height = 20;
            item.value = 90000;
            item.useTime = 12;
            item.useAnimation = 13;
            item.rare = 4;
            item.useStyle = 1;
            item.knockBack = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 20;
            item.shoot = mod.ProjectileType("BlisterSwordProjectile");
            item.shootSpeed = 10f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Sword");
            Tooltip.SetDefault("Minor Upgrade For The Katana, Maybe.");
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
