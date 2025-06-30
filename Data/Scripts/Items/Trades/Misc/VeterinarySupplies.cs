using System;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
    public class VeterinarySupplies : Item
    {
        public override int LabelNumber { get { return 1152729; } }
        public override double DefaultWeight { get { return 5.0; } }
        private static readonly TimeSpan MaxCooldown = TimeSpan.FromSeconds(9.0);
        private static readonly TimeSpan MinCooldown = TimeSpan.FromSeconds(4.5);

        public override string DefaultDescription{ get{ return "Veterinary supplies require a both Veterinary and Druidism skills. When you use them on someone, it will begin the attempt to heal some damage on all of your followers. If your skills are high enough, you can cure most poisons or even bring the dead back to life."; } }
        private static Dictionary<Mobile, DateTime> m_LastUse = new Dictionary<Mobile, DateTime>();
        
        private int m_UsesRemaining = 200;

        [CommandProperty(AccessLevel.Player)]
        public int UsesRemaining
        {
            get { return m_UsesRemaining; }
            set { m_UsesRemaining = value; InvalidateProperties(); }
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            list.Add("Veterinary Supplies");
            list.Add("Uses Remaining: " + m_UsesRemaining.ToString());
        }

        [Constructable]
        public VeterinarySupplies() : base(0xE21)
        {
            Name = "Veterinary Supplies";
            ItemID = 0x1E21;
            Hue = 0x3A;
        }

        public VeterinarySupplies(Serial serial) : base(serial) { }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendMessage("You must have the Veterinary Supplies in your backpack to use them.");
                return;
            }

            if (from.Followers == 0)
            {
                from.SendMessage("You have no followers to tend to.");
                return;
            }
          
            if (HealingCooldownTracker.IsOnBandageCooldown(from))
            {
                from.SendMessage("You cannot use veterinary supplies while bandages are in use.");
                return;
            }
           
            DateTime last;
            if (!m_LastUse.TryGetValue(from, out last))
                last = DateTime.MinValue;

            double dex = from.Dex;
            if (dex < 10.0)
                dex = 10.0;
            else if (dex > 150.0)
                dex = 150.0;

            double t = 1.0 - ((dex - 10.0) / 140.0);
            TimeSpan cooldown = TimeSpan.FromSeconds(4.5 + (4.5 * t));

            if (DateTime.UtcNow < last + cooldown)
            {
                TimeSpan remaining = (last + cooldown) - DateTime.UtcNow;
                from.SendMessage("You must wait {0:F1} more seconds to use the Veterinary Supplies again.", remaining.TotalSeconds);
                return;
            }

            m_LastUse[from] = DateTime.UtcNow;
          
            double vet = from.Skills[SkillName.Veterinary].Value;
            double druid = from.Skills[SkillName.Druidism].Value;
            double skillAvg = (vet + druid) / 2;

            double successChance = skillAvg / 125.0; // 125 skill = 100% success
            if(successChance > 1.0) {
                successChance = 1.0;
            }

            if (Utility.RandomDouble() <= successChance)
            {
                from.SendMessage("You begin tending to your followers... ({0:F1}s)", cooldown.TotalSeconds);
                from.PublicOverheadMessage(MessageType.Regular, 0x22, false, String.Format("You begin tending to your followers... ({0}s)", cooldown.TotalSeconds));
                Timer.DelayCall(cooldown, new TimerStateCallback(ApplyVetSupplies), from);
            }
            else
            {
                from.SendMessage("You fumble with your supplies and fail to use them properly.");
                from.FixedParticles(0x3735, 1, 30, 9502, EffectLayer.Waist);
                from.PlaySound(0x5C); 
            }
            HealingCooldownTracker.SetVetSupplyCooldown(from, cooldown);
        }

        private void ApplyVetSupplies(object state)
        {
            Mobile from = state as Mobile;
            if (from == null || from.Deleted)
                return;

            double vet = from.Skills[SkillName.Veterinary].Value;
            double druid = from.Skills[SkillName.Druidism].Value;

            double skillAvg = (vet + druid) / 2;

            bool anyAffected = false;

            IPooledEnumerable eable = from.GetMobilesInRange(2);
            foreach (Mobile m in eable)
            {
                BaseCreature pet = m as BaseCreature;

                if (pet != null && pet.Controlled && pet.ControlMaster == from)
                {
                    bool didSomething = false;

                    if (pet.IsDeadPet && pet.IsBonded && vet > 80.0 && druid > 80.0)
                    {
                        double resChance = skillAvg / 200.0;
                        if (Utility.RandomDouble() <= resChance)
                        {
                            if (from.CanSee(pet) && from.InLOS(pet) && pet.Map != null && pet.Map.CanFit(pet.Location, 16, false, false))
                            {
                                pet.ResurrectPet();
                                pet.FixedEffect(0x376A, 10, 16);
                                from.SendMessage("You have resurrected {0}.", pet.Name != null ? pet.Name : "your pet");
                                anyAffected = true;
                                continue;
                            }
                        }
                    }

                    if (pet.Alive && from.InRange(pet.Location, 2))
                    {
                        int healed = 0;

                        if (pet.Poisoned && vet > 60.0 && druid > 60.0)
                        {
                            double cureChance = skillAvg / 150.0;
                            if (Utility.RandomDouble() <= cureChance)
                            {
                                pet.CurePoison(from);
                                didSomething = true;
                            }
                        }

                        if (pet.Hits < pet.HitsMax)
                        {
                            double healChance = skillAvg / 100.0;
                            if (Utility.RandomDouble() <= healChance)
                            {
                                double min = (druid / 2) + (vet / 2) + 25.0;
					            double max = (druid / 2) + (vet / 2) + 50.0;
                                double toHeal = min + (Utility.RandomDouble() * (max - min));

                                pet.Heal((int)toHeal, from, false );
                                healed = (int)toHeal;
                                Effects.SendTargetParticles(pet, 0x376A, 10, 16, 5030, EffectLayer.Waist);
                                didSomething = true;
                            }
                        }

                        if (didSomething)
                        {
                            m_UsesRemaining--;
                            from.SendMessage("{0} has been tended to.{1}", pet.Name != null ? pet.Name : "A pet", healed > 0 ? String.Format(" Healed for {0}.", healed) : "");
                            anyAffected = true;
                            if (m_UsesRemaining <= 0)
                            {
                                from.SendMessage("Your veterinary supplies have been used up.");
                                Delete();
                            }
                            else
                            {
                                InvalidateProperties(); // update tooltip
                            }
                            from.CheckSkill( SkillName.Veterinary, 0.0, 120.0 );
				            from.CheckSkill( SkillName.Druidism, 0.0, 120.0 );
                        }
                    }
                }
            }

            eable.Free();

            if (!anyAffected)
            {
                from.SendMessage("None of your followers needed attention.");
            }
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
            writer.Write((int)m_UsesRemaining);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_UsesRemaining = reader.ReadInt();
        }

    }
}
