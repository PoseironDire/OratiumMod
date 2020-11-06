using OratiumMod.Items.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Projectiles
{
    public class FantasmoProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 1000;
            projectile.extraUpdates = 1;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fantasmo");
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.PlaySound(SoundID.Item12);
            Lighting.AddLight(projectile.position, 1.0f, 0.0f, 2.0f);

            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<Blister>());

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
