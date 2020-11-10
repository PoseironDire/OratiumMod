
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Weapons.Throwing
{
    internal class TeleportOrb : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Teleportation Orb");
            ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<Projectiles.TeleportOrbProjectile>();
            item.width = 8;
            item.height = 28;
            item.maxStack = 30;
            item.consumable = true;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 40;
            item.useTime = 40;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.value = Item.buyPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterOre"), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}