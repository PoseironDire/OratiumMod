using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Summons
{
    public class CracklerSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crackler Bait");
            Tooltip.SetDefault("Summons the Crackler");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 30;
            item.value = 0;
            item.useAnimation = 40;
            item.useTime = 45;
            item.consumable = true;
            item.useStyle = 4;
            item.UseSound = SoundID.Item1;
            item.scale = 0.5f;
        }
        public override bool CanUseItem(Player player)
        {
            bool alreadySpawned = NPC.AnyNPCs(mod.NPCType("Crackler"));
            return !alreadySpawned && !Main.dayTime;
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Crackler"));
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlisterBar"), 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
