using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Entities;
using CounterStrikeSharp.API.Modules.Utils;

namespace CustomBindsPlugin;

public class CustomBindsPlugin : BasePlugin
{
    public override string ModuleName => "CustomBindsPlugin";
    public override string ModuleVersion => "1.0.0";

    public override void Load(bool hotReload)
    {
        RegisterCommand("say", OnPlayerSay);
    }

    private HookResult OnPlayerSay(CCSPlayerController? player, CommandInfo command)
    {
        if (player == null || !player.IsValid || player.IsBot)
            return HookResult.Continue;

        string text = command.ArgString.Trim().ToLower();

        if (text == "!binds" || text == "/binds")
        {
            ApplyBinds(player);
        }
        else if (text == "!unbind" || text == "/unbind")
        {
            RestoreDefaultBinds(player);
        }

        return HookResult.Continue;
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

    private void SendBind(CCSPlayerController player, string key, string command)
    {
        player.ExecuteClientCommand($"bind {key} \"{command}\"");
    }

    private void PrintToChat(CCSPlayerController player, string message)
    {
        player.PrintToChat($" \x01{message}");
    }
}
