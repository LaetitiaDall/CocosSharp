namespace CocosSharp
{
	public class CCMoveTo : CCMoveBy
	{
		protected CCPoint EndPosition;

		#region Constructors

		public CCMoveTo (float duration, CCPoint position) : base (duration, position)
		{
			EndPosition = position;
		}

		#endregion Constructors

		public CCPoint PositionEnd {
			get { return EndPosition; }
		}

		internal override CCActionState StartAction(CCNode target)
		{
			return new CCMoveToState (this, target);

		}
	}

	internal class CCMoveToState : CCMoveByState
	{

		public CCMoveToState (CCMoveTo action, CCNode target)
			: base (action, target)
		{ 
			StartPosition = target.Position;
			PositionDelta = action.PositionEnd - target.Position;
		}

		public override void Update (float time)
		{
			if (Target != null)
			{
				CCPoint currentPos = Target.Position;

				CCPoint newPos = StartPosition + PositionDelta * time;
				Target.Position = newPos;
				PreviousPosition = newPos;
			}
		}
	}

}