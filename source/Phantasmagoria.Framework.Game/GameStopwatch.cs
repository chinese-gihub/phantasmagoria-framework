using System;
using System.Diagnostics;

namespace Phantasmagoria.Framework
{
	/// <summary>
	/// 
	/// </summary>
	internal sealed class GameStopwatch
	{
		private readonly TimeSpan targetTimeDelta;
		private readonly bool isFixedTimeDelta;

		private Stopwatch stopwatch;
		private TimeSpan previousTime;

		/// <summary>
		/// 
		/// </summary>
		public event EventHandler<GameStopwatchEventArgs> Update;

		/// <summary>
		/// 
		/// </summary>
		public event EventHandler<GameStopwatchEventArgs> Draw;

		/// <summary>
		/// 
		/// </summary>
		public TimeSpan TargetTimeDelta
		{
			get { return this.targetTimeDelta; }
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsFixedTimeDelta
		{
			get { return this.isFixedTimeDelta; }
		}

		/// <summary>
		/// 
		/// </summary>
		public GameStopwatch()
			: this(TimeSpan.Zero) { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="targetTimeDelta"></param>
		public GameStopwatch(TimeSpan targetTimeDelta)
			: this(targetTimeDelta, false) { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="targetTimeDelta"></param>
		/// <param name="isFixedTimeDelta"></param>
		public GameStopwatch(TimeSpan targetTimeDelta, bool isFixedTimeDelta)
		{
			if (targetTimeDelta < TimeSpan.Zero)
				throw new ArgumentOutOfRangeException();

			// Can't have a fixed time delta of zero.
			if ((targetTimeDelta == TimeSpan.Zero) && isFixedTimeDelta)
				throw new ArgumentException();

			this.targetTimeDelta = targetTimeDelta;
			this.isFixedTimeDelta = isFixedTimeDelta;

			Reset();
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tick()
		{
			var time = this.stopwatch.Elapsed;
			var timeDelta = (time - this.previousTime);
			var isRunningSlowly = false;

			while (timeDelta > this.targetTimeDelta)
			{
				if (this.isFixedTimeDelta)
				{
					// Raise the update event.
					var updateArgs = new GameStopwatchEventArgs(
						new GameTime(
							this.targetTimeDelta + this.previousTime,
							this.targetTimeDelta, isRunningSlowly));
					Update.TryRaise(this, updateArgs);

					this.previousTime += this.targetTimeDelta;

					timeDelta -= this.targetTimeDelta;
				}
				else
				{
					// Raise the update event.
					var updateArgs = new GameStopwatchEventArgs(
						new GameTime(time, timeDelta, isRunningSlowly));
					Update.TryRaise(this, updateArgs);

					this.previousTime -= timeDelta;

					timeDelta -= timeDelta;
				}

				isRunningSlowly = true;
			}

			// Raise the draw event.
			var drawArgs = new GameStopwatchEventArgs(
				new GameTime(time, timeDelta));
			Draw.TryRaise(this, drawArgs);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Reset()
		{
			// Create and start a new stopwatch.
			this.stopwatch = Stopwatch.StartNew();
			this.previousTime = TimeSpan.Zero;
		}
	}
}
