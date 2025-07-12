using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;

namespace CustomBindsPlugin;

public class CustomBindsPlugin : BasePlugin
{
    public override string ModuleName => "CustomBindsPlugin";
    public override string ModuleVersion => "1.0.0";

    public override void Load(bool hotReload)
    {
        AddCommand("say", "Handles chat commands", OnPlayerSay);
    }

    private void OnPlayerSay(CCSPlayerController player, CommandInfo command)
    {
        var text = command.ArgString.Trim();

        if (text == "!binds" || text == "/binds")
        {
            ApplyBinds(player);
        }
        else if (text == "!unbind" || text == "/unbind")
        {
            RestoreDefaultBinds(player);
        }
    }

    private void ApplyBinds(CCSPlayerController player)
    {
        PrintToChat(player, "[Binds] Custom binds applied.");
        SendBind(player, "r", "css_r");
        SendBind(player, "mouse1", "+turnleft");
        SendBind(player, "mouse2", "+turnright");
    }

    private void RestoreDefaultBinds(CCSPlayerController player)
    {
        PrintToChat(player, "[Binds] Default binds restored.");
        SendBind(player, "r", "+reload");
        SendBind(player, "mouse1", "+attack");
        SendBind(player, "mouse2", "+attack2");
    }

    private void SendBind(CCSPlayerController player, string key, string bindCommand)
    {
        player.ExecuteClientCommand($"bind {key} \"{bindCommand}\"");
    }

    private void PrintToChat(CCSPlayerController player, string message)
    {
        player.PrintToChat(message);
    }
}