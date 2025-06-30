using System;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using System.Collections.Generic;
using Server.Misc;
using System.Collections;
using Server.Targeting;

namespace Server.Items
{
	public class ItemIdentification
	{
		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.Mercantile].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse( Mobile from )
		{
			from.SendLocalizedMessage( 500343 ); // What do you wish to appraise and identify?
			from.Target = new InternalTarget();

			return TimeSpan.FromSeconds( 1.0 );
		}

		[PlayerVendorTarget]
		private class InternalTarget : Target
		{
			public InternalTarget() :  base ( 8, false, TargetFlags.None )
			{
				AllowNonlocal = true;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
			    if (targeted is Item)
			    {
			        Item examine = (Item)targeted;
			        int identified = RelicIDHelper.TryRecursiveIdentify(from, examine, IDSkill.Mercantile, SkillName.Mercantile);

			        if (examine is Container)
			        {
			            if (identified == 0)
			                from.SendMessage("There is nothing in this container that requires Mercantile to identify.");
			            else
			                from.SendMessage("You examine the goods using your Mercantile knowledge.");
			        }
			        else
			        {
			            if (identified == 0)
			                from.SendMessage("That item cannot be identified with Mercantile.");
			        }
			    }
			}
		}
	}
}