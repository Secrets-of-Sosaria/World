using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	public class EerieGhost : BaseLight
	{
		public override int LitItemID{ get { if ( ItemID == 0x5754 ){ return 0x5755; } else { return 0x575B; } } }
		public override int UnlitItemID{ get { if ( ItemID == 0x5755 ){ return 0x5754; } else { return 0x575A; } } }
		public override int LitSound{ get { return 0x182; } }
		public override int UnlitSound{ get { return 0x17F; } }
		public override int BurntOutSound{ get { return 0x17E; } }

		[Constructable]
		public EerieGhost() : base( 0x5754 )
		{
			Name = "eerie ghost";
			Duration = TimeSpan.Zero;
			BurntOut = false;
			Burning = false;
			Light = LightType.Circle150;
			Weight = 10.0;
		}

		private static int[] m_Sounds = new int[] { 0x17E, 0x17F, 0x180, 0x181, 0x182 };

		public static int[] Sounds
		{
			get{ return m_Sounds; }
		}

		public override bool HandlesOnMovement{ get{ return ((ItemID>=0x5755 && ItemID<=0x5759) || (ItemID>=0x575B && ItemID<=0x575F)) && IsLockedDown; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( ((ItemID>=0x5755 && ItemID<=0x5759) || (ItemID>=0x575B && ItemID<=0x575F)) && IsLockedDown && (!m.Hidden || m.AccessLevel == AccessLevel.Player) && Utility.InRange( m.Location, this.Location, 2 ) && !Utility.InRange( oldLocation, this.Location, 2 ) )
				Effects.PlaySound( this.Location, this.Map, m_Sounds[Utility.Random( m_Sounds.Length )] );

			base.OnMovement( m, oldLocation );
		}

		public EerieGhost( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}