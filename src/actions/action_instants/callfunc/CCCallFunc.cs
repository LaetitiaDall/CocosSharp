﻿using System;

namespace CocosSharp
{
    public class CCCallFunc : CCActionInstant
    {
		public Action CallFunction { get; private set;}
		public string ScriptFuncName { get; private set; }

        #region Constructors

        public CCCallFunc()
        {
			ScriptFuncName = "";
			CallFunction = null;
        }

        public CCCallFunc(Action selector) : base()
        {
			CallFunction = selector;
        }

        #endregion Constructors

		/// <summary>
		/// Start the Call Function operation on the given target.
		/// </summary>
		/// <param name="target"></param>
		internal override CCActionState StartAction(CCNode target)
		{
			return new CCCallFuncState (this, target);

		}

    }

	internal class CCCallFuncState : CCActionInstantState
	{

		protected Action CallFunction { get; set;}
		protected string ScriptFuncName { get; set; }

		public CCCallFuncState (CCCallFunc action, CCNode target)
			: base(action, target)
		{	
			CallFunction = action.CallFunction;
			ScriptFuncName = action.ScriptFuncName;
		}

		public virtual void Execute()
		{
			if (null != CallFunction)
			{
				CallFunction();
			}
		}

		public override void Update (float time)
		{
			Execute();
		}
	}
}