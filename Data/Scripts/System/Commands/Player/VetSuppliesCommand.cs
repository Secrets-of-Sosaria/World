using Server;
using Server.Commands;
using Server.Mobiles;
using Server.Items;

namespace Server.Commands
{
	public class VetSuppliesCommand
	{
		public static void Initialize()
		{
			CommandSystem.Register("VetSupplies", AccessLevel.Player, new CommandEventHandler(Vet_OnCommand));
		}

		[Usage("VetSupplies")]
		[Description("Uses veterinary supplies from your backpack if available.")]
		private static void Vet_OnCommand(CommandEventArgs e)
		{
			Mobile from = e.Mobile;

			Container pack = from.Backpack;
			if (pack == null) return;

			foreach (Item item in pack.Items)
			{
				if (item is VeterinarySupplies)
				{
					((VeterinarySupplies)item).OnDoubleClick(from);
					return;
				}
			}

			from.SendMessage("You do not have any veterinary supplies in your backpack.");
		}
	}
}
