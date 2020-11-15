using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace OratiumMod.Items.Dusts
{
    public class ArcaneCloud : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.4f;
            dust.scale *= 2.0f;
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.99f;
            float light = 0.55f * dust.scale;
            Lighting.AddLight(dust.position, 1, 1, 1.5f);
            if (dust.scale < 0.9f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}