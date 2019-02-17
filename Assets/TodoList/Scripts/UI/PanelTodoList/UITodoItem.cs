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
	public partial class UITodoItem : UIElement
	{
        public TodoItem mModel;

        public void Init(TodoItem model)
        {
            mModel = model;
            UpdateView();

            Completed.onValueChanged.AddListener(on =>
            {
                mModel.Completed = on;
                this.DestroyGameObj();
            });

            AreaClick.onClick.AddListener(() =>
            {
                // todo : UIÑÕÉ«±ä»¯
                SendMsg(new OnTodoItemSelectMsg(mModel));
            });

        }

        public void UpdateView()
        {
            Content.text = mModel.Content;
            Completed.isOn = mModel.Completed;
        }

        private void Awake()
		{
		}

		protected override void OnBeforeDestroy()
		{
		}
	}

}