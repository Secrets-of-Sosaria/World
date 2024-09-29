using System;

namespace Server.Items
{
	public class ExecutionersCap : Item
	{
		[Constructable]
		public ExecutionersCap() : base(0xF83)
		{
			Weight = 1.0;
			this.Delete();
		}

		public ExecutionersCap(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
		}

		private void Cleanup( object state )
		{
			((Item)state).Delete();
		}
	}
}