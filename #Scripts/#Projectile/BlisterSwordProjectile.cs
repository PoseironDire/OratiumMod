using OratiumMod.Items.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Projectiles
{
    public class BlisterSwordProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            DisplayName.SetDefault("Blister Sword");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 2;
            projectile.alpha = 200;
            projectile.timeLeft = 360;
            projectile.extraUpdates = 2;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //If collide with tile, reduce the penetrate.
            //So the projectile can reflect at most 5 times

            Main.PlaySound(SoundID.Item10, projectile.position);

            projectile.velocity *= 0.0f;
            projectile.timeLeft = 100;

            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<ArcaneCloud>());
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Blister>());

            return false;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            Lighting.AddLight(projectile.position, 0f, 1f, 0f);

            if (projectile.owner == Main.myPlayer && Main.rand.Next(4) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Blister>());
            }
            projectile.ai[0] += 1f;
            if (projectile.ai[0] > 50f)
            {
                // Fade out
                projectile.alpha += 10;
                if (projectile.alpha > 255)
                {
                    projectile.alpha = 255;
                }
            }
            else
            {
                // Fade in
                projectile.alpha -= 25;
                if (projectile.alpha < 100)
                {
                    projectile.alpha = 100;
                }
            }
            // Slow down
            projectile.velocity *= 0.98f;
            // Loop through the 4 animation frames, spending 5 ticks on each.
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }
    }
}
