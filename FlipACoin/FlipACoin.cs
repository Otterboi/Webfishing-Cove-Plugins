using Cove.Server;
using Cove.Server.Plugins;

namespace FlipACoin
{
    public class FlipACoin : CovePlugin
    {
        private CoveServer Server { get; set; } // HUH????
        public FlipACoin(CoveServer server) : base(server)
        {
            Server = server;
        }

        public override void onInit()
        {
            base.onInit();

            RegisterCommand("flipcoin", (player, args) =>
            {
                Random random = new Random();
                int result = random.Next(2);

                if(result == 0)
                {
                    SendGlobalChatMessage("Heads");
                }
                else
                {
                    SendGlobalChatMessage("Tails");
                }
            });
            SetCommandDescription("flipcoin", "Returns Heads or Tails.");

            Log("Flip A Coin Plugin loaded!");
        }

        public override void onEnd()
        {
            base.onEnd();
            Log("Flip A Coint Plugin unloaded!");
        }
    }
}
