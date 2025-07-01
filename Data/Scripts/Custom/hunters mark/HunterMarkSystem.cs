using System;
using System.Collections;
using Server;
using Server.Mobiles;

public class HunterMarkSystem
{
	private static Hashtable _marks = new Hashtable();

	private class HunterMarkInfo
	{
		public Mobile Tracker;
		public DateTime Expiration;

		public HunterMarkInfo(Mobile tracker, DateTime expiration)
		{
			Tracker = tracker;
			Expiration = expiration;
		}
	}

	public static void MarkTarget(Mobile tracker, Mobile target)
	{
		if (tracker == null || target == null || tracker.Deleted || target.Deleted)
			return;

		_marks[target] = new HunterMarkInfo(tracker, DateTime.Now + TimeSpan.FromSeconds(60));
	}

	public static double GetDamageBonus(Mobile from, Mobile target)
	{
		HunterMarkInfo info = _marks[target] as HunterMarkInfo;

		if (info == null || info.Tracker != from || DateTime.Now > info.Expiration)
		{
			if (info != null)
				_marks.Remove(target);

			return 1.0;
		}

		double tracking = from.Skills[SkillName.Tracking].Value;
		double bonus = tracking / 8.333;
		return bonus > 1.0  ? bonus : 1.0;
	}

	private static Timer _cleanupTimer;

	public static void Initialize()
	{
		_cleanupTimer = new CleanupTimer();
		_cleanupTimer.Start();
	}

	private class CleanupTimer : Timer
	{
		public CleanupTimer() : base(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1)) { Priority = TimerPriority.OneMinute; }

		protected override void OnTick()
		{
			ArrayList toRemove = new ArrayList();

			foreach (DictionaryEntry entry in _marks)
			{
				Mobile target = entry.Key as Mobile;
				HunterMarkInfo info = entry.Value as HunterMarkInfo;

				if (target == null || info == null || DateTime.Now > info.Expiration || target.Deleted)
				{
					toRemove.Add(target);
				}
			}
			foreach (Mobile m in toRemove)
				_marks.Remove(m);
		}
	}
}
