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

    public enum PanelInputState
    {
        Create,
        Modify,
    }

    public partial class PanelAddItem : UIElement
	{
        public ReactiveProperty<PanelInputState> State = new ReactiveProperty<PanelInputState>(PanelInputState.Create);

        TodoItem mSelectedItemModel;
        TodoList mTodoModel;

        public void Init(TodoList todoModel)
        {
            mTodoModel = todoModel;
            State.Value = PanelInputState.Create;
        }

        public void ModifyState(TodoItem selectedItemModel)
        {
            mSelectedItemModel = selectedItemModel;
            InputField.text = selectedItemModel.Content.Value;
            State.Value = PanelInputState.Modify;
        }

        void CreateState()
        {
            State.Value = PanelInputState.Create;
        }

		private void Awake()
		{
            // 注册状态更改的委托
            State.Subscribe((state) => 
            {
                if (state == PanelInputState.Create)
                {
                    BtnUpdate.interactable = false;
                    BtnCancel.interactable = false;
                    InputField.text = string.Empty;
                }
                else
                {
                    BtnUpdate.interactable = false;
                    BtnCancel.interactable = true;
                }
            });


            // 点击取消事件
            BtnCancel.onClick.AddListener(CreateState);

            // 修改事件
            InputField.onValueChanged.AddListener((content) =>
            {
                if (State.Value == PanelInputState.Modify)
                {
                    if (content != mSelectedItemModel.Content.Value && !BtnUpdate.interactable)
                    {
                        BtnUpdate.interactable = true;
                    }
                    else if (content == mSelectedItemModel.Content.Value && BtnUpdate.interactable)
                    {
                        BtnUpdate.interactable = false;
                    }
                }
                else
                {
                    if (content.IsNotNullAndEmpty())
                    {
                        BtnCancel.interactable = true;
                    }
                    else
                    {
                        BtnCancel.interactable = false;
                    }
                }
            });

            // 点击更新事件
            BtnUpdate.onClick.AddListener(() =>
            {
                mSelectedItemModel.Content.Value = InputField.text;   
                CreateState();
            });

            // 回车事件
            InputField.onEndEdit.AddListener((content) =>
            {
                if (State.Value == PanelInputState.Create)
                {
                    if (content.IsNotNullAndEmpty() && Input.GetKeyDown(KeyCode.Return))
                    {
                        // 对 model 层更新
                        var item = new TodoItem();
                        item.Content.Value = content;

                        mTodoModel.TodoItems.Add(item);
                    }
                    InputField.text = string.Empty; 
                }
            });
        }

		protected override void OnBeforeDestroy()
		{
		}
	}
}