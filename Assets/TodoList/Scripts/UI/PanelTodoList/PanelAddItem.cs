/****************************************************************************
 * 2019.2 DESKTOP-ORJQHD3
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TodoList
{

    public enum PanelInputState
    {
        Create,
        Modify,
    }

    public partial class PanelAddItem : UIElement
	{
        private PanelInputState mState;

        public PanelInputState State
        {
            get
            {
                return mState;
            }
            set
            {
                if (mState != value)
                {
                    mState = value;
                }
            }
        }

		private void Awake()
		{
		}

		protected override void OnBeforeDestroy()
		{
		}
	}
}