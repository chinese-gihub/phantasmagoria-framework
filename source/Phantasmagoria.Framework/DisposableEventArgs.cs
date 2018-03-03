using System;

namespace Phantasmagoria.Framework
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
    public class DisposableEventArgs
		: EventArgs
    {
		private readonly bool disposing;

		/// <summary>
		/// 
		/// </summary>
		public bool Disposing
		{
			get { return this.disposing; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disposing"></param>
		public DisposableEventArgs(bool disposing)
			: base()
		{
			this.disposing = disposing;
		}
    }
}
