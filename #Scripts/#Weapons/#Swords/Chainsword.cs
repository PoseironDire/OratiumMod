using OratiumMod.Items.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Weapons.Swords
{
    public class Chainsword : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 180;
            item.melee = true;
            item.axe = 25;
            item.width = 40;
            item.height = 40;
            item.value = 10000000;
            item.useTime = 31;
            item.useAnimation = 32;
            item.useStyle = 1;
            item.knockBack = 10;
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 30;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chainsword");
            Tooltip.SetDefault("A tool, for slaughter..");
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Lighting.AddLight(player.position, 0.5f, 0.5f, 0.1f);

                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Sparkle>());
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, +1);
        }

           public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}