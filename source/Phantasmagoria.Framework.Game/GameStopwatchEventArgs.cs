using System;

namespace Phantasmagoria.Framework
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	internal class GameStopwatchEventArgs
		: EventArgs
	{
		private readonly GameTime gameTime;

		/// <summary>
		/// 
		/// </summary>
		public GameTime GameTime
		{
			get { return this.gameTime; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="gameTime"></param>
		public GameStopwatchEventArgs(GameTime gameTime)
			: base()
		{
			this.gameTime = gameTime;
		}
	}
}
