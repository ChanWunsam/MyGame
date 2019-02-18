/****************************************************************************
 * 2019.2 DESKTOP-ORJQHD3
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System.Linq;
using UniRx;

namespace QFramework.TodoList
{
	public partial class UIListCtrl : UIElement
	{

		private void Awake()
		{
		}

		protected override void OnBeforeDestroy()
		{
		}

        public ReactiveProperty<TodoItem> mSelectedModel = new ReactiveProperty<TodoItem>();

        public void AddTodoItem(UITodoItem itemPrefab, TodoItem item)
        {
            itemPrefab.Instantiate()
                    .Parent(this)
                    .LocalIdentity()
                    .ApplySelfTo(self => self.Init(item))
                    .ApplySelfTo(self => self.mSelectedModel.Skip(1).Subscribe(model => mSelectedModel.Value = model))
                    .Show();
        }


        public void GenerateTodoItem(TodoList model, UITodoItem itemPrefab)
        {
            this.DestroyAllChild();

            if (model.TodoItems.IsNotNull())
            {
                model.TodoItems.Where(item => !item.Completed.Value).ForEach(item =>
                {
                    AddTodoItem(itemPrefab, item);
                });
            }
        }
	}
}