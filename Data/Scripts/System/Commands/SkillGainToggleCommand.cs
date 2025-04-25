using System;
using Server;
using Server.Commands;

public class SkillGainToggleCommand
{
    public static void Initialize()
    {
        CommandSystem.Register("ShowSkillGainChance", AccessLevel.Player, new CommandEventHandler(ToggleSkillChance));
    }

    private static void ToggleSkillChance(CommandEventArgs e)
    {
        SkillGainSettings.Toggle(e.Mobile);
    }
}
