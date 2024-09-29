using System;
using Server;

namespace Server.Items
{
	public abstract class BaseSpawner : Item
	{
		public BaseSpawner() : base( 0x6519 )
		{
			Name = "spawn ref";
			Visible = false;
			Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), new TimerStateCallback( Remove ), this );
		}

		public BaseSpawner( Serial serial ) : base( serial )
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
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Remove ), this );
		}

		private void Remove( object state )
		{
			this.Delete();
		}
	}

	public class SpawnAnimals : BaseSpawner
	{
		[Constructable]
		public SpawnAnimals(){} public SpawnAnimals( Serial serial ) : base( serial ){} public override void Serialize( GenericWriter writer ){ base.Serialize( writer ); writer.Write( (int) 0 ); } public override void Deserialize( GenericReader reader ){ base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class SpawnBirds : BaseSpawner
	{
		[Constructable]
		public SpawnBirds(){} public SpawnBirds( Serial serial ) : base( serial ){} public override void Serialize( GenericWriter writer ){ base.Serialize( writer ); writer.Write( (int) 0 ); } public override void Deserialize( GenericReader reader ){ base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class SpawnCritters : BaseSpawner
	{
		[Constructable]
		public SpawnCritters(){} public SpawnCritters( Serial serial ) : base( serial ){} public override void Serialize( GenericWriter writer ){ base.Serialize( writer ); writer.Write( (int) 0 ); } public override void Deserialize( GenericReader reader ){ base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class Spawn_A : BaseSpawner
	{
		[Constructable]
		public Spawn_A(){} public Spawn_A( Serial serial ) : base( serial ){} public override void Serialize( GenericWriter writer ){ base.Serialize( writer ); writer.Write( (int) 0 ); } public override void Deserialize( GenericReader reader ){ base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class Spawn_B : BaseSpawner
	{
		[Constructable]
		public Spawn_B(){} public Spawn_B( Serial serial ) : base( serial ){} public override void Serialize( GenericWriter writer ){ base.Serialize( writer ); writer.Write( (int) 0 ); } public override void Deserialize( GenericReader reader ){ base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class Spawn_C : BaseSpawner
	{
		[Constructable]
		public Spawn_C(){} public Spawn_C( Serial serial ) : base( serial ){} public override void Serialize( GenericWriter writer ){ base.Serialize( writer ); writer.Write( (int) 0 ); } public override void Deserialize( GenericReader reader ){ base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class Spawn_D : BaseSpawner
	{
		[Constructable]
		public Spawn_D(){} public Spawn_D( Serial serial ) : base( serial ){} public override void Serialize( GenericWriter writer ){ base.Serialize( writer ); writer.Write( (int) 0 ); } public override void Deserialize( GenericReader reader ){ base.Deserialize( reader ); int version = reader.ReadInt(); }
	}

	public class Spawn_E : BaseSpawner
	{
		[Constructable]
		public Spawn_E(){} public Spawn_E( Serial serial ) : base( serial ){} public override void Serialize( GenericWriter writer ){ base.Serialize( writer ); writer.Write( (int) 0 ); } public override void Deserialize( GenericReader reader ){ base.Deserialize( reader ); int version = reader.ReadInt(); }
	}
}