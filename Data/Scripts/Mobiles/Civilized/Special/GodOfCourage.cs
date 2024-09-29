using System;
using System.Collections;
using Server.ContextMenus;
using System.Collections.Generic;
using Server.Misc;
using Server.Network;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;

namespace Server.Mobiles
{
	public class GodOfLegends : BasePerson
	{
		public override string TalkGumpTitle{ get{ return "Items of Legend"; } }
		public override string TalkGumpSubject{ get{ return "GodOfLegends"; } }

		[Constructable]
		public GodOfLegends() : base( )
		{
			SpeechHue = Utility.RandomTalkHue();
			NameHue = 1154;

			Direction = Direction.South;
			Blessed = true;
			CantWalk = true;
			Body = 76;
			Name = "Arez";
			Title = "the God of Legends";

			SetStr( 200 );
			SetDex( 200 );
			SetInt( 200 );

			SetDamage( 15, 20 );
			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 30 );
			SetResistance( ResistanceType.Cold, 25, 30 );
			SetResistance( ResistanceType.Poison, 10, 20 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.FistFighting, 100 );
			Karma = 10000;
			VirtualArmor = 100;
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( dropped is ILevelable )
			{
				from.AddToBackpack ( dropped );

				ArrayList targets = new ArrayList();
				foreach ( Item item in World.Items.Values )
				{
					if ( item is LegendaryArtifactRename )
					{
						LegendaryArtifactRename brander = (LegendaryArtifactRename)item;
						if ( brander.owner == from )
						{
							targets.Add( item );
						}
					}
				}
				for ( int i = 0; i < targets.Count; ++i )
				{
					Item item = ( Item )targets[ i ];
					item.Delete();
				}

				LegendaryArtifactRename brand = new LegendaryArtifactRename( from );
				from.AddToBackpack ( brand );

				string sMessage = "Mark your legendary artefact so others will tell tales of it one day.";

				this.PrivateOverheadMessage(MessageType.Regular, 1153, false, sMessage, from.NetState);
			}

			return base.OnDragDrop( from, dropped );
		}

		public GodOfLegends( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}