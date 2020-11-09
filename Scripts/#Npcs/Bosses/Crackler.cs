using OratiumMod.Items.Dusts;
using OratiumMod.Items.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OratiumMod.Items.Npcs.Bosses
{
    [AutoloadBossHead]
    public class Crackler : ModNPC
    {
        // private static int hellLayer => Main.maxTilesY - 200;

        // private const int sphereRadius = 300;

        private float attackCool
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }

        private float moveCool
        {
            get => npc.ai[1];
            set => npc.ai[1] = value;
        }

        private float rotationSpeed
        {
            get => npc.ai[2];
            set => npc.ai[2] = value;
        }

        private float captiveRotation
        {
            get => npc.ai[3];
            set => npc.ai[3] = value;
        }

        private int moveTime = 300;
        private int moveTimer = 60;
        internal int laserTimer;
        internal int laser1 = -1;
        internal int laser2 = -1;
        private bool dontDamage;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crackler");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 40000;
            npc.damage = 100;
            npc.defense = 55;
            npc.knockBackResist = 0f;
            npc.width = 100;
            npc.height = 100;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.npcSlots = 15f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
            music = MusicID.Boss2;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }

        public override void AI()
        {

        }

        private void ExpertLaser()
        {

        }

        public override void SendExtraAI(BinaryWriter writer)
        {

        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {

        }

        public override void FindFrame(int frameHeight)
        {

        }

        public override void HitEffect(int hitDirection, double damage)
        {

        }

        // We use this hook to prevent any loot from dropping. We do this because this is a multistage npc and it shouldn't drop anything until the final form is dead.
        public override bool PreNPCLoot()
        {
            return false;
        }

        // We use this method to inflict a debuff on a player on contact. OnFire is inflicted 100% of the time in expert, and 50% of the time on non-expert mode.
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {

        }

        public override void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {

        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {

        }

        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            if (dontDamage)
            {
                damage = 0;
                crit = true;
                dontDamage = false;
                Main.PlaySound(npc.HitSound, npc.position);
                return false;
            }
            return true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
    }
}