﻿namespace CocosSharp
{
	public class CCFadeOut : CCActionInterval
	{
		#region Constructors

		public CCFadeOut (float d) : base (d)
		{
		}

		#endregion Constructors

		internal override CCActionState StartAction(CCNode target)
		{
			return new CCFadeOutState (this, target);

		}

		public override CCFiniteTimeAction Reverse ()
		{
			return new CCFadeIn (Duration);
		}
	}

	internal class CCFadeOutState : CCActionIntervalState
	{

		public CCFadeOutState (CCFadeOut action, CCNode target)
			: base (action, target)
		{
		}

		public override void Update (float time)
		{
			var pRGBAProtocol = Target;
			if (pRGBAProtocol != null)
			{
				pRGBAProtocol.Opacity = (byte)(255 * (1 - time));
			}
		}

	}

}