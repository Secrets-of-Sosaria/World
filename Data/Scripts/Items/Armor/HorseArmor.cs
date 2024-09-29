using Server;
using System;
using System.Collections;
using Server.Network;
using Server.Targeting;
using Server.Prompts;
using Server.Misc;
using Server.Mobiles;

namespace Server.Items
{
	public class HorseArmor : Item
	{
		public override void ResourceChanged( CraftResource resource )
		{
			if ( !ResourceCanChange() )
				return;

			ResourceMods.Modify( this, true );
			m_Resource = resource;
			Hue = CraftResources.GetHue(m_Resource);
			Name = CraftResources.GetTradeItemFullName( this, m_Resource, false, false, "horse barding" );
			ResourceMods.Modify( this, false );
			InvalidateProperties();
		}

		public int ArmorMod;
		[CommandProperty(AccessLevel.Owner)]
		public int Armor_Mod { get { return ArmorMod; } set { ArmorMod = value; InvalidateProperties(); } }

		[Constructable]
		public HorseArmor() : base( 0x040A )
		{
			Weight = 25.0;
			Name = "horse barding";
			ArmorMod = 5;

            int chance = 0;
            double chancetest = Utility.RandomDouble();
            
            if (chancetest < 0.50 )
                chance = 3;
            else if (chancetest < 0.70)
                chance = 7;
            else if (chancetest < 0.85)
                chance = 9;
            else if (chancetest < 0.95)
                chance = 11;
            else if (chancetest >= 0.95)
                chance = 14;
            
            switch ( Utility.Random( chance ) )
            {
				case 1: Resource = CraftResource.DullCopper; break;
				case 2: Resource = CraftResource.ShadowIron; break;
				case 3: Resource = CraftResource.Copper; break;
				case 4: Resource = CraftResource.Bronze; break;
				case 5: Resource = CraftResource.Gold; break;
				case 6: Resource = CraftResource.Agapite; break;
				case 7: Resource = CraftResource.Verite; break;
				case 8: Resource = CraftResource.Valorite; break;
				case 9: Resource = CraftResource.Nepturite; break;
				case 10: Resource = CraftResource.Obsidian; break;
				case 11: Resource = CraftResource.Steel; break;
				case 12: Resource = CraftResource.Brass; break;
				case 13: Resource = CraftResource.Mithril; break;
            }
		}

		public override void OnDoubleClick( Mobile from )
		{
			Target t;

			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1060640 ); // The item must be in your backpack to use it.
			}
			else
			{
				from.SendMessage( "Which horse do you want to use this on?" );
				t = new HorseTarget( this );
				from.Target = t;
			}
		}

		private class HorseTarget : Target
		{
			private HorseArmor m_Horse;

			public HorseTarget( HorseArmor armor ) : base( 8, false, TargetFlags.None )
			{
				m_Horse = armor;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Mobile )
				{
					Mobile iArmor = targeted as Mobile;

					if ( iArmor is BaseCreature )
					{
						BaseCreature xArmor = (BaseCreature)iArmor;

						if ( ( xArmor is Horse || xArmor is ZebraRiding ) && xArmor.ControlMaster == from && xArmor is BaseMount )
						{
							BaseMount mArmor = (BaseMount)xArmor;

							mArmor.Body = 587;
							mArmor.ItemID = 587;

							mArmor.Hue = CraftResources.GetClr(m_Horse.Resource);
							mArmor.Resource = m_Horse.Resource;
							int mod = m_Horse.ArmorMod;

							xArmor.SetStr( xArmor.RawStr+mod );
							xArmor.SetDex( xArmor.RawDex+mod );
							xArmor.SetInt( xArmor.RawInt+mod );

							xArmor.SetHits( xArmor.HitsMax+mod );

							xArmor.SetDamage( xArmor.DamageMin+mod, xArmor.DamageMax+mod );

							xArmor.SetResistance( ResistanceType.Physical, xArmor.PhysicalResistance+mod );

							xArmor.SetSkill( SkillName.MagicResist, xArmor.Skills[SkillName.MagicResist].Base+mod );
							xArmor.SetSkill( SkillName.Tactics, xArmor.Skills[SkillName.Tactics].Base+mod );
							xArmor.SetSkill( SkillName.FistFighting, xArmor.Skills[SkillName.FistFighting].Base+mod );

							from.RevealingAction();
							from.PlaySound( 0x0AA );

							m_Horse.Consume();
						}
						else
						{
							from.SendMessage( "This armor is only for horses you own." );
						}
					}
					else
					{
						from.SendMessage( "This armor is only for horses you own." );
					}
				}
			}
		}

		public static void DropArmor( BaseCreature bc )
		{
			if ( bc.Resource != CraftResource.None )
			{
				HorseArmor armor = new HorseArmor();
				armor.Resource = bc.Resource;
				bc.AddItem( armor );
			}
		}

		public HorseArmor( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer ); 
			writer.Write( (int) 2 ); // version
            writer.Write( ArmorMod );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); 
			int version = reader.ReadInt();
			ArmorMod = reader.ReadInt();

			string ArmorMaterial = null;

			if ( version < 2 )
				ArmorMaterial = reader.ReadString();

			if ( ArmorMaterial != null && version < 2 )
			{
				if ( ArmorMaterial == "Dull Copper" ){ 			Resource = CraftResource.DullCopper; }
				else if ( ArmorMaterial == "Shadow Iron" ){ 	Resource = CraftResource.ShadowIron; }
				else if ( ArmorMaterial == "Copper" ){ 			Resource = CraftResource.Copper; }
				else if ( ArmorMaterial == "Bronze" ){ 			Resource = CraftResource.Bronze; }
				else if ( ArmorMaterial == "Gold" ){ 			Resource = CraftResource.Gold; }
				else if ( ArmorMaterial == "Agapite" ){ 		Resource = CraftResource.Agapite; }
				else if ( ArmorMaterial == "Verite" ){ 			Resource = CraftResource.Verite; }
				else if ( ArmorMaterial == "Valorite" ){ 		Resource = CraftResource.Valorite; }
				else if ( ArmorMaterial == "Nepturite" ){ 		Resource = CraftResource.Nepturite; }
				else if ( ArmorMaterial == "Obsidian" ){ 		Resource = CraftResource.Obsidian; }
				else if ( ArmorMaterial == "Steel" ){ 			Resource = CraftResource.Steel; }
				else if ( ArmorMaterial == "Brass" ){ 			Resource = CraftResource.Brass; }
				else if ( ArmorMaterial == "Mithril" ){ 		Resource = CraftResource.Mithril; }
				else if ( ArmorMaterial == "Xormite" ){ 		Resource = CraftResource.Xormite; }
				else if ( ArmorMaterial == "Dwarven" ){ 		Resource = CraftResource.Dwarven; }
				else {											Resource = CraftResource.Iron; }
				ArmorMaterial = null;
			}
		}
	}
}