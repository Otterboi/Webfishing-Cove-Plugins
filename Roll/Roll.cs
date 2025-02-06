using Cove.Server;
using Cove.Server.Plugins;

namespace Roll
{
    public class Roll : CovePlugin
    {
        private CoveServer Server { get; set; } // HUH????
        public Roll(CoveServer server) : base(server)
        {
            Server = server;
        }

        public override void onInit()
        {
            base.onInit();

            RegisterCommand("roll", (player, args) =>
            {
                if (args.Length == 0 || !int.TryParse(args[0], out _))
                {
                    SendPlayerChatMessage(player, "An integer is required as an argument!");
                    return;
                }
                else
                {
                    Random random = new Random();
                    int result = random.Next(int.Parse(args[0]));
                    SendGlobalChatMessage($"{player.Username} rolled a {result}");
                }
            });
            SetCommandDescription("roll", "Rolls a number between 0 and the inputed value.");

            Log("Roll Plugin loaded!");
        }

        public override void onEnd()
        {
            base.onEnd();
            Log("Roll Plugin unloaded!");
        }
    }
}
