using System;

namespace Phantasmagoria.Framework
{
	/// <summary>
	/// 
	/// </summary>
	internal static class EventHandlerExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventHandler"></param>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public static void TryRaise(this EventHandler eventHandler, object sender, EventArgs e)
		{
			if ((sender == null) || (e == null))
				throw new ArgumentNullException();

			eventHandler?.Invoke(sender, e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="eventHandler"></param>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public static void TryRaise<T>(this EventHandler<T> eventHandler, object sender, T e)
		{
			if ((sender == null) || (e == null))
				throw new ArgumentNullException();

			eventHandler?.Invoke(sender, e);
		}
	}
}
