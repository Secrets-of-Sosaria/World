using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using Server;
using System.Collections.Generic;
using Server.Targeting;
using Server.Multis;

namespace Server.Mobiles
{
	public class BaseSailor : BaseCreature
	{
        private BaseBoat boat;
        private bool boatspawn;
		public int level;

		[Constructable]
		public BaseSailor() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			SpeechHue = Utility.RandomTalkHue();
			Female = Utility.RandomBool();

			level = Utility.RandomMinMax( 150, 400 );

			SetDamage( ((int)level/20), ((int)level/10) );

			SetSkill( SkillName.Marksmanship, (level/3) );
			SetSkill( SkillName.FistFighting, (level/3) );
			SetSkill( SkillName.MagicResist, (level/3) );
			SetSkill( SkillName.Tactics, (level/3) );
			SetSkill( SkillName.Psychology, (level/3) );
			SetSkill( SkillName.Magery, (level/3) );
			SetSkill( SkillName.Musicianship, (level/3) );

			Fame = (int)(level*10);
			Karma = -(int)(level*10);

			if ( Female )
			{
				Body = 0x191;
				Name = NameList.RandomName( "female" );
				AddItem( new Skirt( Utility.RandomColor(0) ) );
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName( "male" );
				AddItem( new ShortPants( Utility.RandomColor(0) ) );
			}

			Hue = Utility.RandomSkinColor();
			HairHue = Utility.RandomHairHue();
			FacialHairHue = HairHue;

            AddItem( new ElvenBoots( 0x6F8 ) );
			AddItem( new FancyShirt( Utility.RandomColor(0) ) );	

            switch ( Utility.Random( 2 ))
			{
				case 0: AddItem( new LongPants ( 0xBB4 ) ); break;
				case 1: AddItem( new ShortPants ( 0xBB4 ) ); break;
			}

			switch ( Utility.Random( 2 ))
			{
				case 0: AddItem( new Bandana ( 0x846 ) ); break;
				case 1: AddItem( new SkullCap ( 0x846 ) ); break;
			}

			Harpoon spear = new Harpoon();
			spear.LootType = LootType.Blessed;
			spear.Attributes.SpellChanneling = 1;
			AddItem( spear );
		}

		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override int TreasureMapLevel{ get{ return Utility.RandomMinMax( 1, 3 ); } }
		public override bool AlwaysAttackable{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override bool DeleteCorpseOnDeath{ get{ return true; } }

		public override void OnThink()
		{
  			if( boatspawn == false )
  			{
				Map map = this.Map;
				
  				if ( map == null )
  					return;
  					
				boat = new TinyBoat();
				EmoteHue = boat.Serial;
				Point3D loc = this.Location;
				Point3D loccrew = this.Location;
				loc = new Point3D( this.X, this.Y-1, this.Z );
				this.Z = 0;
				boat.MoveToWorld(loc, map);
				boatspawn = true;
				if ( Server.Multis.BaseBoat.IsNearOtherShip( this ) ){ this.Delete(); }
				else if ( Worlds.TestShore( Map, X, Y, 8 ) ){ this.Delete(); }
			}

        	if ( boat == null )
			{
				return;
			} 

			if ( DateTime.Now >= NextPickup && ( this is BoatSailorBard || this is BoatPirateBard || this is ElfBoatSailorBard || this is ElfBoatPirateBard ) )
			{
				switch( Utility.RandomMinMax( 0, 3 ) )
				{
					case 0:	Peace( Combatant ); break;
					case 1:	Undress( Combatant ); break;
					case 2:	Suppress( Combatant ); break;
					case 3:	Provoke( Combatant ); break;
				}
			}
			base.OnThink();
		}
		
		public override void OnDelete()
		{
			Server.Multis.BaseBoat.SinkShip( boat, this );
			base.OnDelete();
		}

		public override bool OnBeforeDeath()
		{
			Server.Multis.BaseBoat.SinkShip( boat, this );
			Point3D wreck = new Point3D((this.X+3), (this.Y+3), 0);
			SunkenShip ShipWreck = Server.Multis.BaseBoat.CreateSunkenShip( this, this.LastKiller );
			ShipWreck.DropItem( new HarpoonRope( Utility.RandomMinMax( 10, 30 ) ) );

			return base.OnBeforeDeath();   
		}

		public BaseSailor( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( (Item)boat );
			writer.Write( (bool)boatspawn );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            boat = reader.ReadItem() as BaseBoat;
            boatspawn = reader.ReadBool();
		}
	}
}