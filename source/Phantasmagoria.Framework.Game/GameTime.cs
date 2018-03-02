using System;

namespace Phantasmagoria.Framework
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public sealed class GameTime
		: IEquatable<GameTime>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="valueA"></param>
		/// <param name="valueB"></param>
		/// <returns></returns>
		public static bool Equals(GameTime valueA, GameTime valueB)
		{
			if (ReferenceEquals(valueA, valueB))
				return true;

			if (ReferenceEquals(valueA, null) || ReferenceEquals(valueB, null))
				return false;

			return
				(valueA.time == valueB.time) &&
				(valueA.timeDelta == valueB.timeDelta) &&
				(valueA.isRunningSlowly == valueB.isRunningSlowly);
		}

		private readonly TimeSpan time, timeDelta;
		private readonly bool isRunningSlowly;

		/// <summary>
		/// 
		/// </summary>
		public TimeSpan Time
		{
			get { return this.time; }
		}

		/// <summary>
		/// 
		/// </summary>
		public TimeSpan TimeDelta
		{
			get { return this.timeDelta; }
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsRunningSlowly
		{
			get { return this.isRunningSlowly; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="time"></param>
		/// <param name="timeDelta"></param>
		public GameTime(TimeSpan time, TimeSpan timeDelta)
			: this(time, timeDelta, false) { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="time"></param>
		/// <param name="timeDelta"></param>
		/// <param name="isRunningSlowly"></param>
		public GameTime(TimeSpan time, TimeSpan timeDelta, bool isRunningSlowly)
		{
			if ((time < TimeSpan.Zero) || (timeDelta < TimeSpan.Zero))
				throw new ArgumentOutOfRangeException();

			this.time = time;
			this.timeDelta = timeDelta;
			this.isRunningSlowly = isRunningSlowly;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Equals(GameTime other)
		{
			return Equals(this, other);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (obj is GameTime)
			{
				var other = (GameTime)obj;
				return Equals(this, other);
			}

			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			var result = 13;

			result = (result * 397) ^ this.time.GetHashCode();
			result = (result * 397) ^ this.timeDelta.GetHashCode();
			result = (result * 397) ^ this.isRunningSlowly.GetHashCode();

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static bool operator ==(GameTime left, GameTime right)
		{
			return Equals(left, right);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static bool operator !=(GameTime left, GameTime right)
		{
			return !Equals(left, right);
		}
	}
}
