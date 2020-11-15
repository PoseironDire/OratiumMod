using System.ComponentModel;
using System.Runtime.CompilerServices;
using OratiumMod.Items.Projectiles;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Weapons.Magic
{
    public class VampiresTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Vampires Tome");
        }

        public override void SetDefaults()
        {
            item.damage = 120;
            item.knockBack = 4; 
            item.crit = 4; 
            item.width = 28;
            item.height = 38;
            item.value = 40000;
            item.rare = 7; 
            item.useStyle = 5;
            item.useTime = 16;
            item.useAnimation = 17;
            item.UseSound = SoundID.Item20;
            item.mana = 4;
            item.shoot = ProjectileID.VampireKnife;
            item.shootSpeed = 14f;
            item.magic = true;
            item.noMelee = true;
            item.autoReuse = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = ProjectileID.VampireKnife;

            int numberProjectiles = 4;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("AdamantiumBar"), 12);
            recipe.AddIngredient(mod.ItemType("SoulofIgnite"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}