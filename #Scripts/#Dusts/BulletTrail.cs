using Terraria;
using Terraria.ModLoader;

namespace OratiumMod.Items.Dusts
{
    public class BulletTrail : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.1f;
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale *= 0.6f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.99f;
            float light = 1.95f * dust.scale;
            Lighting.AddLight(dust.position, 0.7f, 0.9f, 0.7f);
            if (dust.scale < 0.1f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}