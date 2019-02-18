/****************************************************************************
 * 2019.2 DESKTOP-ORJQHD3
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UniRx;

namespace QFramework.TodoList
{
	public partial class UITodoItem : UIElement
	{
        public TodoItem mModel;

        public void Init(TodoItem model)
        {
            mModel = model;

            mModel.Content.Subscribe((content) =>
            {
                Content.text = content;
            });
            
            Completed.isOn = mModel.Completed.Value;

            Completed.onValueChanged.AddListener(on =>
            {
                if (on)
                {
                    mModel.Completed.Value = on;
                    this.DestroyGameObj();
                }
            });

            AreaClick.onClick.AddListener(() =>
            {
                // todo : UI颜色
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