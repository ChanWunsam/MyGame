/****************************************************************************
 * 2019.2 DESKTOP-ORJQHD3
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System.Linq;

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

        public void AddTodoItem(UITodoItem itemPrefab, TodoItem item)
        {
            itemPrefab.Instantiate()
                    .Parent(this)
                    .LocalIdentity()
                    .ApplySelfTo(self => self.Init(item))
                    .ApplySelfTo(self => mItemDataForView.Add(item, self))
                    .Show();
        }

        Dictionary<TodoItem, UITodoItem> mItemDataForView = new Dictionary<TodoItem, UITodoItem>();

        public void UpdateTodoItem(TodoItem itemData)
        {
            mItemDataForView[itemData].UpdateView();
        }

        public void ModifyTodoItem(UITodoItem itemPrefab, TodoItem item)
        {

        }

        public void GenerateTodoItem(TodoList model, UITodoItem itemPrefab)
        {
            this.DestroyAllChild();
            mItemDataForView.Clear();

            if (model.mTodoItems.IsNotNull())
            {
                model.mTodoItems.Where(item => !item.Completed).ForEach(item =>
                {
                    AddTodoItem(itemPrefab, item);
                });
            }
        }
	}
}