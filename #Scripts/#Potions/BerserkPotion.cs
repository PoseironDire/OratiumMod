using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Potions
{
    public class BerserkPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserk Potion");
            Tooltip.SetDefault("Lose all defence in exchange for doubled damage.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = Item.buyPrice(gold: 1);
            item.buffType = ModContent.BuffType<Buffs.BerserkBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 5400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ItemID.DoubleCod);
            recipe.AddIngredient(ItemID.VileMushroom);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.Fireblossom);
            recipe2.AddIngredient(ItemID.DoubleCod);
            recipe2.AddIngredient(ItemID.ViciousMushroom);
            recipe2.AddTile(TileID.Bottles);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}