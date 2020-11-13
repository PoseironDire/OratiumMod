using OratiumMod.Items.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Projectiles
{
    public class BlisterThrowingScytheProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blister Throwing Scythe");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 1000;
            projectile.extraUpdates = 2;
        }
        
        public override void AI()
        {
            Lighting.AddLight(projectile.position, 0.5f, 1f, 0.5f);

            if (projectile.owner == Main.myPlayer && Main.rand.Next(4) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Blister>());
            }
        }
    }
}
