using System;
using Server;
using Server.Items;

namespace Server.Misc
{
	public class Arty
	{
		public static void ArtySetup( Item item, int points, string extra )
		{
			points = points * 10;
			points = 200 - points;
			if ( points < 50 ){ points = 50; }

			if ( item is BaseGiftArmor )
			{
				((BaseGiftArmor)item).m_Gifter = null;
				((BaseGiftArmor)item).m_How = "Unearthed by";
				((BaseGiftArmor)item).m_Points = points;
			}
			else if ( item is BaseGiftClothing )
			{
				((BaseGiftClothing)item).m_Gifter = null;
				((BaseGiftClothing)item).m_How = "Unearthed by";
				((BaseGiftClothing)item).m_Points = points;
			}
			else if ( item is BaseGiftJewel )
			{
				((BaseGiftJewel)item).m_Gifter = null;
				((BaseGiftJewel)item).m_How = "Unearthed by";
				((BaseGiftJewel)item).m_Points = points;
			}
			else if ( item is BaseGiftShield )
			{
				((BaseGiftShield)item).m_Gifter = null;
				((BaseGiftShield)item).m_How = "Unearthed by";
				((BaseGiftShield)item).m_Points = points;
			}
			else if ( item is BaseGiftAxe )
			{
				((BaseGiftAxe)item).m_Gifter = null;
				((BaseGiftAxe)item).m_How = "Unearthed by";
				((BaseGiftAxe)item).m_Points = points;
			}
			else if ( item is BaseGiftKnife )
			{
				((BaseGiftKnife)item).m_Gifter = null;
				((BaseGiftKnife)item).m_How = "Unearthed by";
				((BaseGiftKnife)item).m_Points = points;
			}
			else if ( item is BaseGiftBashing )
			{
				((BaseGiftBashing)item).m_Gifter = null;
				((BaseGiftBashing)item).m_How = "Unearthed by";
				((BaseGiftBashing)item).m_Points = points;
			}
			else if ( item is BaseGiftWhip )
			{
				((BaseGiftWhip)item).m_Gifter = null;
				((BaseGiftWhip)item).m_How = "Unearthed by";
				((BaseGiftWhip)item).m_Points = points;
			}
			else if ( item is BaseGiftPoleArm )
			{
				((BaseGiftPoleArm)item).m_Gifter = null;
				((BaseGiftPoleArm)item).m_How = "Unearthed by";
				((BaseGiftPoleArm)item).m_Points = points;
			}
			else if ( item is BaseGiftRanged )
			{
				((BaseGiftRanged)item).m_Gifter = null;
				((BaseGiftRanged)item).m_How = "Unearthed by";
				((BaseGiftRanged)item).m_Points = points;
			}
			else if ( item is BaseGiftSpear )
			{
				((BaseGiftSpear)item).m_Gifter = null;
				((BaseGiftSpear)item).m_How = "Unearthed by";
				((BaseGiftSpear)item).m_Points = points;
			}
			else if ( item is BaseGiftStaff )
			{
				((BaseGiftStaff)item).m_Gifter = null;
				((BaseGiftStaff)item).m_How = "Unearthed by";
				((BaseGiftStaff)item).m_Points = points;
			}
			else if ( item is BaseGiftSword )
			{
				((BaseGiftSword)item).m_Gifter = null;
				((BaseGiftSword)item).m_How = "Unearthed by";
				((BaseGiftSword)item).m_Points = points;
			}
		}

		public static void setArtifact( Item item )
		{
			if ( item.ArtifactLevel > 0 )
			{
				Type itemType = item.GetType();
				Item arty = null;

				if ( itemType != null )
				{
					arty = (Item)Activator.CreateInstance(itemType);
					item.Name = arty.Name;
					if ( !(item is BaseQuiver) && !MySettings.S_ChangeArtyLook ){ item.ItemID = arty.ItemID; }
					if ( !MySettings.S_ChangeArtyLook ){ item.Hue = arty.Hue; }

					arty.Delete();
				}
			}
		}
	}
}