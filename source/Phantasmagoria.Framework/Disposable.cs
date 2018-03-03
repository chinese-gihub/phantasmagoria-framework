using System;

namespace Phantasmagoria.Framework
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class Disposable
		: IDisposable
	{
		private bool isDisposed;

		/// <summary>
		/// 
		/// </summary>
		public event EventHandler<DisposableEventArgs> Disposing;

		/// <summary>
		/// 
		/// </summary>
		public bool IsDisposed
		{
			get { return this.isDisposed; }
		}

		/// <summary>
		/// 
		/// </summary>
		protected Disposable()
		{
			this.isDisposed = false;
		}

		/// <summary>
		/// 
		/// </summary>
		public void Dispose()
		{
			TryDispose(true);
		}

		/// <summary>
		/// 
		/// </summary>
		protected void ThrowIfDisposed()
		{
			if (this.isDisposed)
			{
				// Get the name for the object.
				var objectName = GetType().Name;

				throw new ObjectDisposedException(objectName);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disposing"></param>
		protected virtual void Dispose(bool disposing) { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disposing"></param>
		private void TryDispose(bool disposing)
		{
			if (this.isDisposed)
				return;

			// Raise the disposing event.
			var args = new DisposableEventArgs(disposing);
			Disposing.TryRaise(this, args);

			Dispose(disposing);
			GC.SuppressFinalize(this);

			this.isDisposed = true;
		}

		/// <summary>
		/// 
		/// </summary>
		~Disposable()
		{
			TryDispose(false);
		}
	}
}
