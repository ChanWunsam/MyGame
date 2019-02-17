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
	public partial class UICompletedItem : UIElement
	{
        public TodoItem mModel;

        public void Init(TodoItem model)
        {
            mModel = model;
            Completed.isOn = model.Completed;
            Content.text = model.Content;

            Completed.onValueChanged.AddListener(on =>
            {
                mModel.Completed = on;
                this.DestroyGameObj();
            });
        }

        private void Awake()
		{
		}

		protected override void OnBeforeDestroy()
		{
		}
	}
}