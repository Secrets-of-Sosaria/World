using System;
using Server;
using System.Collections;
using Server.Network;
using System.Text;
using Server.Mobiles;
using Server.Regions;

namespace Server.Items
{
	public enum SpyglassEffect
	{
	}

    public class Spyglass : Item
	{
		public override void ResourceChanged( CraftResource resource )
		{
			if ( !ResourceCanChange() )
				return;

			ResourceMods.Modify( this, true );
			m_Resource = resource;
			Hue = CraftResources.GetHue(m_Resource);
			Name = CraftResources.GetTradeItemFullName( this, m_Resource, false, false, "spyglass" );
			ResourceMods.Modify( this, false );
			InvalidateProperties();
		}

		public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }

		public override string DefaultDescription
		{
			get
			{
				if ( Technology )
					return "Using these binoculars will give you a bonus to tracking for a short time, allowing you to search for your targets much easier.";

				return "Using this spyglass will give you a bonus to tracking for a short time, allowing you to search for your targets much easier.";
			}
		}

		private SpyglassEffect m_SpyglassEffect;

		[CommandProperty( AccessLevel.GameMaster )]
		public SpyglassEffect Effect
		{
			get{ return m_SpyglassEffect; }
			set{ m_SpyglassEffect = value; InvalidateProperties(); }
		}

        [Constructable]
        public Spyglass() : base(0x14F5)
		{
            Name = "spyglass";
			LimitsMax = 20;
			Limits = 20;
			LimitsName = "Uses";
			LimitsDelete = true;
			Weight = 1.0;
			InfoText1 = "+25 Tracking Skill For 2 Minutes";
		}

		private static Hashtable m_Table = new Hashtable();

		public static bool HasEffect( Mobile m )
		{
			return ( m_Table[m] != null );
		}
		
		public static void RemoveEffect( Mobile m )
		{
			object[] mods = (object[])m_Table[m];
			
			if ( mods != null )
			{
				m.RemoveSkillMod( (SkillMod)mods[0] );
			}
			
			m_Table.Remove( m );
			m.EndAction( typeof( Spyglass ) );
		}

        public override void OnDoubleClick( Mobile m )
		{
		    if ( !m.CanBeginAction( typeof( Spyglass ) ) )
		    {
				m.SendMessage( "You are already using the this." );
		    }
			else if (	!Server.Misc.Worlds.IsMainRegion( Server.Misc.Worlds.GetRegionName( m.Map, m.Location ) ) && 
						!m.Region.IsPartOf( typeof( OutDoorRegion ) ) && 
						!m.Region.IsPartOf( typeof( OutDoorBadRegion ) ) && 
						!m.Region.IsPartOf( typeof( VillageRegion ) ) )
			{
				m.SendMessage( "You can only use this outdoors." ); 
				return;
			}
			else if ( Limits > 0 )
			{
				ConsumeLimits( 1 );
				int bonus = 25 + CraftResources.GetXtra( Resource );
				double minutes = 2.0 + CraftResources.GetXtra( Resource );

				object[] mods = new object[]
				{
					new DefaultSkillMod( SkillName.Tracking, true, bonus ),
				};

				m_Table[m] = mods;

				m.AddSkillMod( (SkillMod)mods[0] );
				BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.Spyglass, 1064168, TimeSpan.FromMinutes( minutes ), m, bonus.ToString() ) );

				new InternalTimer( m, TimeSpan.FromMinutes( minutes ) ).Start();

				m.BeginAction( typeof( Spyglass ) );
			}
		}

		private class InternalTimer : Timer
		{
			private Mobile m_m;
			private DateTime m_Expire;
			
			public InternalTimer( Mobile m, TimeSpan duration ) : base( TimeSpan.Zero, TimeSpan.FromSeconds( 0.1 ) )
			{
				m_m = m;
				m_Expire = DateTime.Now + duration;
			}
			
			protected override void OnTick()
			{
				if ( DateTime.Now >= m_Expire )
				{
					Spyglass.RemoveEffect( m_m );
					Stop();
				}
			}
		}

        public Spyglass( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
			writer.Write( (int) m_SpyglassEffect );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			m_SpyglassEffect = (SpyglassEffect)reader.ReadInt();

			if ( version < 1 )
			{
				LimitsMax = (int)reader.ReadInt();
				Limits = LimitsMax;
				LimitsName = "Uses";
				LimitsDelete = true;
				InfoText1 = "+25 Tracking Skill";
				InfoText2 = "For 2 Minutes";
			}
	    }
    }
}