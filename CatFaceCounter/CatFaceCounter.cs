using Cove.Server;
using Cove.Server.Actor;
using Cove.Server.Plugins;
using System.Text.RegularExpressions;

namespace CatFaceCounter
{
    public class CatFaceCounter : CovePlugin
    {
        private CoveServer Server {get; set;} // HUH????
        private int Counter;

        public CatFaceCounter(CoveServer server) : base(server)
        {
            Server = server;
            Counter = 0;
        }

        public override void onInit()
        {
            base.onInit();

            RegisterCommand("catcount", (player, args) =>
            {
                SendGlobalChatMessage($"Server :3 counter is at {Counter}");
            });
            SetCommandDescription("catcount", "Counts the number of times :3 was typed.");

            Log("Word Counter plugin loaded!");
        }

        public override void onEnd()
        {
            base.onEnd();
            Log("Word Counter plugin unloaded!");
        }

        public override void onChatMessage(WFPlayer sender, string message)
        {
            base.onChatMessage(sender, message);

            string pattern = @"\:3";
            Regex rg = new Regex(pattern);

            if (rg.IsMatch(message))
            {
                Counter += rg.Matches(message).Count;
            }
        }
    }
}
