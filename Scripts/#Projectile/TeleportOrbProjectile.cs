using OratiumMod.Items.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Projectiles
{
    public class TeleportOrbProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 15;
            projectile.height = 15;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // This code makes the projectile very bouncy.
            if (projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
            {
                projectile.velocity.X = oldVelocity.X * -0.9f;
            }
            if (projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
            {
                projectile.velocity.Y = oldVelocity.Y * -0.9f;
            }
            return false;

        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Teleportation Orb");
        }
        public override void AI()
        {

            Lighting.AddLight(projectile.position, 0f, 0.6f, 0.5f);

            if (projectile.owner == Main.myPlayer && Main.rand.Next(4) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<ArcaneCloud>());
            }

            projectile.ai[0] += 1f;
            if (projectile.ai[0] > 5f)
            {
                projectile.ai[0] = 10f;
                // Roll speed dampening.
                if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
                {
                    projectile.velocity.X = projectile.velocity.X * 0.97f;
                    //if (projectile.type == 29 || projectile.type == 470 || projectile.type == 637)
                    {
                        projectile.velocity.X = projectile.velocity.X * 0.99f;
                    }
                    if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01)
                    {
                        projectile.velocity.X = 0f;
                        projectile.netUpdate = true;
                    }
                }
                projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            }
            // Rotation increased by velocity.X 
            projectile.rotation += projectile.velocity.X * 0.1f;
            return;
        }
    }
}
