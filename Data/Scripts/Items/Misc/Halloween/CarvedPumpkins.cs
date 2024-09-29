using System;
using Server.Network;
using Server.Gumps;
using Server.Multis;
using System.Collections.Generic;
using Server.ContextMenus; 

namespace Server.Items
{
	public class CarvedPumpkin : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x4691; } }
		public override int UnlitItemID{ get { return 0x4694; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin() : base( 0x4694 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin( Serial serial ) : base( serial )
		{
		}
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin2 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x4695; } }
		public override int UnlitItemID{ get { return 0x4698; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin2() : base( 0x4698 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin2( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin3 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x549A; } }
		public override int UnlitItemID{ get { return 0x5499; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin3() : base( 0x5499 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin3( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin4 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x549E; } }
		public override int UnlitItemID{ get { return 0x549D; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin4() : base( 0x549D )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin4( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin5 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54A2; } }
		public override int UnlitItemID{ get { return 0x54A1; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin5() : base( 0x54A1 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin5( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin6 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54A6; } }
		public override int UnlitItemID{ get { return 0x54A5; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin6() : base( 0x54A5 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin6( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin7 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54AA; } }
		public override int UnlitItemID{ get { return 0x54A9; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin7() : base( 0x54A9 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin7( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin8 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54AE; } }
		public override int UnlitItemID{ get { return 0x54AD; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin8() : base( 0x54AD )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin8( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin9 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54B2; } }
		public override int UnlitItemID{ get { return 0x54B1; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin9() : base( 0x54B1 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin9( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin10 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54B6; } }
		public override int UnlitItemID{ get { return 0x54B5; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin10() : base( 0x54B5 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin10( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin11 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54BA; } }
		public override int UnlitItemID{ get { return 0x54B9; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin11() : base( 0x54B9 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin11( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin12 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54BE; } }
		public override int UnlitItemID{ get { return 0x54BD; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin12() : base( 0x54BD )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin12( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin13 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54C2; } }
		public override int UnlitItemID{ get { return 0x54C1; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin13() : base( 0x54C1 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin13( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin14 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54C5; } }
		public override int UnlitItemID{ get { return 0x54E0; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin14() : base( 0x54E0 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin14( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin15 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54CD; } }
		public override int UnlitItemID{ get { return 0x54E0; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin15() : base( 0x54E0 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin15( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin16 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54CF; } }
		public override int UnlitItemID{ get { return 0x54CE; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin16() : base( 0x54CE )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin16( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin17 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54D3; } }
		public override int UnlitItemID{ get { return 0x54D2; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin17() : base( 0x54D2 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin17( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin18 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54D7; } }
		public override int UnlitItemID{ get { return 0x54D6; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin18() : base( 0x54D6 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin18( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin19 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x54DB; } }
		public override int UnlitItemID{ get { return 0x54DA; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin19() : base( 0x54DA )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin19( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
	public class CarvedPumpkin20 : BaseLight, ISecurable
	{
		public override int LitItemID{ get { return 0x5482; } }
		public override int UnlitItemID{ get { return 0x5481; } }
		private SecureLevel m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public SecureLevel Level
		{
			get{ return m_Level; }
			set{ m_Level = value; }
		}

		[Constructable]
		public CarvedPumpkin20() : base( 0x5481 )
		{
			Name = "Jack-O-Lantern";
			Duration = TimeSpan.Zero; // Never burnt out
			Weight = 10;
			Light = LightType.Circle150;
			Burning = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 1 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else
				base.OnDoubleClick( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			SetSecureLevelEntry.AddTo( from, this, list );
		}

		public CarvedPumpkin20( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.WriteEncodedInt( (int) m_Level );
		}
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Level = (SecureLevel) reader.ReadEncodedInt();
		}
	}
}