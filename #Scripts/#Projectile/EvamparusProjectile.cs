using OratiumMod.Items.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Projectiles
{
    public class EvamparusProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 100;
            projectile.extraUpdates = 2;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("EvamparusProjectile");
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times

            projectile.Kill();

            Main.PlaySound(SoundID.Item10, projectile.position);

            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<ArcaneCloud>());

            return false;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            Lighting.AddLight(projectile.position, 0.7f, 0.7f, 0.9f);

            if (projectile.owner == Main.myPlayer && Main.rand.Next(4) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Sparkle>());
            }
        }
    }
}