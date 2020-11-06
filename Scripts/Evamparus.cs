using OratiumMod.Items.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Weapons.Swords
{
    public class Evamparus : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 100;
            item.melee = true;
            item.width = 22;
            item.height = 22;
            item.value = 10000000;
            item.useTime = 15;
            item.useAnimation = 16;
            item.useStyle = 1;
            item.knockBack = 7;
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 10;
            item.shoot = mod.ProjectileType("EvamparusProjectile");
            item.shootSpeed = 8f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Evamparus");
            Tooltip.SetDefault("???...");
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Sparkle>());
            }
        }
    }
}