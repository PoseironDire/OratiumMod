using OratiumMod.Items.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Weapons.Swords
{
    public class Fantasmo : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 40;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.value = 10000000;
            item.useTime = 11;
            item.useAnimation = 12;
            item.useStyle = 1;
            item.knockBack = 10;
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 30;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fantasmo");
            Tooltip.SetDefault("???...");
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.damage = 250;
                item.melee = true;
                item.noMelee = true;
                item.noUseGraphic = true;
                item.width = 22;
                item.height = 22;
                item.useTime = 30;
                item.useAnimation = 31;
                item.shootSpeed = 16f;
                item.shoot = mod.ProjectileType("FantasmoProjectile");
                item.useStyle = 3;
                item.knockBack = 10;
                item.UseSound = SoundID.Item1;
                item.autoReuse = true;
                item.crit = 23;
            }
            else if (player.ownedProjectileCounts[item.shoot] < 1)
            {
                item.damage = 40;
                item.melee = true;
                item.noMelee = false;
                item.noUseGraphic = false;
                item.width = 22;
                item.height = 22;
                item.useTime = 11;
                item.useAnimation = 12;
                item.useStyle = 1;
                item.knockBack = 10;
                item.UseSound = SoundID.Item1;
                item.autoReuse = true;
                item.crit = 30;
                item.shoot = ProjectileID.None;
            }
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Blister>());
            }
        }
    }
}