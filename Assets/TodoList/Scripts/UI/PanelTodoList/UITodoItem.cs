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

            Content.text = model.Content;
            Completed.isOn = model.Completed;

            Completed.onValueChanged.AddListener(on =>
            {
                mModel.Completed = on;
                SendEvent(PanelTodoListEvent.OnDataChange);
            });

            AreaClick.onClick.AddListener(() =>
            {
                // todo : UIÑÕÉ«±ä»¯
                SendMsg(new OnTodoItemSelectMsg(mModel));
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