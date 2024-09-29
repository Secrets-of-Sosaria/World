using Server;
using Server.Network;
using Server.Mobiles;
using Server.Regions;

namespace Felladrin.Automations
{
    public static class PlayMusicOnLogin
    {
        public static class Config
        {
            public static bool Enabled = true;                          // Is this system enabled?
            public static bool PlayRandomMusic = true;                  // Should we play a random music from the list?
            public static MusicName SingleMusic = MusicName.Odyssey;    // Music to be played if PlayRandomMusic = false.
        }

        public static void Initialize()
        {
            if (Config.Enabled)
                EventSink.Login += OnLogin;
        }

        static void OnLogin(LoginEventArgs args)
        {
			Mobile from = args.Mobile;

            MusicName toPlay = Config.SingleMusic;

            if (Config.PlayRandomMusic)
                toPlay = MusicList[Utility.Random(MusicList.Length)];

			if ( from.Region is StartRegion )
			{
				if ( (from.Region).Name == "the Forest" )
					from.Send(PlayMusic.GetInstance(MusicName.City));
				else 
					from.Send(PlayMusic.GetInstance(toPlay));
			}
			else
				from.Send(PlayMusic.GetInstance(toPlay));
        }
        
        public static MusicName[] MusicList = {
            MusicName.Traveling,
            MusicName.Explore,
            MusicName.Adventure,
            MusicName.Searching,
            MusicName.Scouting,
            MusicName.Wrong,
            MusicName.Hunting,
            MusicName.Seeking,
            MusicName.Despise,
            MusicName.Wandering,
            MusicName.Odyssey,
            MusicName.Expedition,
            MusicName.Roaming
        };
    }
}