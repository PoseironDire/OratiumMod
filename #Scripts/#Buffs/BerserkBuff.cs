using OratiumMod.Items.Npcs;
using Terraria;
using Terraria.ModLoader;

namespace OratiumMod.Items.Buffs
{
    // Ethereal Flames is an example of a buff that causes constant loss of life.
    // See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
    public class BerserkBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Berserk");
            Description.SetDefault("Lose all defence in exchange for doubled damage.");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 100; //Grant a +4 defense boost to the player while the buff is active.
            player.allDamage *= 2;
        }
    }
}