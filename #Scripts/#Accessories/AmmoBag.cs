using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Waist)]
    public class AmmoBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Chance not to consume ammo");
            DisplayName.SetDefault("Ammo Pocket");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = 10000;
            item.rare = 6;
            item.accessory = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.ammoCost75 = true;
            player.ammoCost80 = true;
            player.allDamage += 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
