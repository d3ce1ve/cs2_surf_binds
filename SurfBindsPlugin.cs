namespace CustomBindsPlugin;

public class CustomBindsPlugin
{
    public string ModuleName => "CustomBindsPlugin";
    public string ModuleVersion => "1.0.0";

    public void Load(bool hotReload)
    {
        // Would register command here
    }

    private object OnPlayerSay(object player, object command)
    {
        string text = "!binds";

        if (text == "!binds" || text == "/binds")
        {
            ApplyBinds(player);
        }
        else if (text == "!unbind" || text == "/unbind")
        {
            RestoreDefaultBinds(player);
        }

        return null!;
    }

    private void ApplyBinds(object player)
    {
        PrintToChat(player, "[Binds] Custom binds applied.");
        SendBind(player, "r", "css_r");
        SendBind(player, "mouse1", "+turnleft");
        SendBind(player, "mouse2", "+turnright");
    }

    private void RestoreDefaultBinds(object player)
    {
        PrintToChat(player, "[Binds] Default binds restored.");
        SendBind(player, "r", "+reload");
        SendBind(player, "mouse1", "+attack");
        SendBind(player, "mouse2", "+attack2");
    }

    private void SendBind(object player, string key, string command)
    {
        // Would be: player.ExecuteClientCommand($"bind {key} \"{command}\"");
    }

    private void PrintToChat(object player, string message)
    {
        // Would be: player.PrintToChat(message);
    }
}
