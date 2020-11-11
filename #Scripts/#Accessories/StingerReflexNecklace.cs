using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class StningerReflexNecklace : ModItem
	{

		public override void SetStaticDefaults() 
        {
			Tooltip.SetDefault("Increases armor penetration by 5 Releases bees and douses the user in honey when damaged it also increases movement speed after taking damage");
            DisplayName.SetDefault("Stninger Reflex Necklace");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 60;
			item.rare = 4;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
        {
			player.allDamage+=2;
		}


		public override void AddRecipes() 
        {
			 ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PanicNecklace);
            recipe.AddIngredient(ItemID.HoneyComb);
            //recipe.AddIngredient(ItemID.SharktoothNecklace);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}
