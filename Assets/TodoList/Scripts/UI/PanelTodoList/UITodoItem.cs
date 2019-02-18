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

        public ReactiveProperty<TodoItem> mSelectedModel = new ReactiveProperty<TodoItem>();

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
                Debug.Log("Click Todo Item");
                // bug: 由于只改动一次值，导致只能点击修改一次
                mSelectedModel.Value = mModel;  
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