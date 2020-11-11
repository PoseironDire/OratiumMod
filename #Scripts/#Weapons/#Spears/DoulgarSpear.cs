using OratiumMod.Items.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Weapons.Spears
{
    public class DoulgarSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Doulgar Spear");
            Tooltip.SetDefault("A faster variant of the Spear");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 24;
            item.useTime = 34;
            item.shootSpeed = 2.7f;
            item.knockBack = 3f;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.rare = 3;
            item.value = Item.sellPrice(gold: 1);

            item.melee = true;
            item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
            item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
            item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

            item.UseSound = SoundID.Item1;
            item.shoot = ModContent.ProjectileType<DoulgarSpearProjectile>();
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Spear);
            recipe.AddIngredient(ItemID.PlatinumBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.Spear);
            recipe2.AddIngredient(ItemID.GoldBar, 12);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}