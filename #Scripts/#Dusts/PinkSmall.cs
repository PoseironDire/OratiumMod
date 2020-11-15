using Terraria;
using Terraria.ModLoader;

namespace OratiumMod.Items.Dusts
{
    public class PinkSmall : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.1f;
            dust.scale *= 0.6f;
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.99f;
            float light = 0.55f * dust.scale;
            Lighting.AddLight(dust.position, 1f, 0.2f, 0.2f);
            if (dust.scale < 0.2f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}