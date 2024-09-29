using System;
using Server;

namespace Server.Items
{
	public abstract class BaseDecorationArtifact : Item
	{
		public override bool ForceShowProperties{ get{ return true; } }

		public BaseDecorationArtifact( int itemID ) : base( itemID )
		{
			Weight = 10.0;
			SetVals( this );
		}

		public BaseDecorationArtifact( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
			SetVals( this );
		}

		public static void SetVals( Item item )
		{
			item.CoinPrice = 2000;

			if ( item is RockArtifact || item is SkullCandleArtifact || item is BottleArtifact || item is DamagedBooksArtifact ){ item.CoinPrice = 1250; }
			else if ( item is StretchedHideArtifact || item is BrazierArtifact ){ item.CoinPrice = 1500; }
			else if ( item is LampPostArtifact || item is BooksNorthArtifact || item is BooksWestArtifact || item is BooksFaceDownArtifact ){ item.CoinPrice = 1750; }
			else if ( item is StuddedTunicArtifact || item is CocoonArtifact ){ item.CoinPrice = 2250; }
			else if ( item is SkinnedDeerArtifact ){ item.CoinPrice = 2500; }
			else if ( item is SaddleArtifact || item is LeatherTunicArtifact ){ item.CoinPrice = 2750; }
			else if ( item is RuinedPaintingArtifact ){ item.CoinPrice = 3000; }

			item.CoinPrice = (int)( (MyServerSettings.QuestRewardModifier() * 0.01) * item.CoinPrice ) + item.CoinPrice;
		}
	}

	public abstract class BaseDecorationContainerArtifact : BaseContainer
	{
		public override bool ForceShowProperties{ get{ return true; } }

		public BaseDecorationContainerArtifact( int itemID ) : base( itemID )
		{
			Weight = 10.0;
			BaseDecorationArtifact.SetVals( this );
		}

		public BaseDecorationContainerArtifact( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
			BaseDecorationArtifact.SetVals( this );
		}
	}
}