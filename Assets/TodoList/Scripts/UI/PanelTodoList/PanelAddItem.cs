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
        public PanelInputState State {
            get
            {
                return mState;
            }
            private set
            {
                if (mState != value) {
                    mState = value;
                    OnStateChanged.InvokeGracefully();
                }
            }
        }
        public Action OnStateChanged;

        TodoItem mSelectedItemModel;
        TodoList mTodoModel;

        public void Init(TodoList todoModel)
        {
            mTodoModel = todoModel;
            State = PanelInputState.Create;
        }

        public void ModifyState(TodoItem selectedItemModel)
        {
            mSelectedItemModel = selectedItemModel;
            State = PanelInputState.Modify;

            InputField.text = selectedItemModel.Content;
            BtnUpdate.interactable = false;
            BtnCancel.interactable = true;
        }

        void CreateState()
        {
            State = PanelInputState.Create;
            BtnUpdate.interactable = false;
            BtnCancel.interactable = false;
            InputField.text = string.Empty;
        }

		private void Awake()
		{
            // 点击取消事件
            BtnCancel.onClick.AddListener(CreateState);

            // 监测是否有修改
            InputField.onValueChanged.AddListener((content) =>
            {
                if (State == PanelInputState.Modify)
                {
                    if (content != mSelectedItemModel.Content && !BtnUpdate.interactable)
                    {
                        BtnUpdate.interactable = true;
                    }
                    else if (content == mSelectedItemModel.Content && BtnUpdate.interactable)
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
                mSelectedItemModel.Content = InputField.text;   
                SendMsg(new OnTodoItemUpdateMsg(mSelectedItemModel));  // 修改todo
                CreateState();
            });

            // 回车事件
            InputField.onEndEdit.AddListener((content) =>
            {
                if (State == PanelInputState.Create)    // 添加todo
                {
                    if (content.IsNotNullAndEmpty() && Input.GetKeyDown(KeyCode.Return))
                    {
                        SendMsg(new OnTodoItemAddMsg(new TodoItem()
                        {
                            Completed = false,
                            Content = content,
                        }));
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