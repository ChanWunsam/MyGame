using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace QFramework.TodoList
{
    public class App : MonoBehaviour
    {
        //public TodoList Model = new TodoList();
        TodoList mModel;

        // Use this for initialization
        void Start()
        {
            ResMgr.Init();
            UIMgr.SetResolution(640, 1136, 0);
            mModel = TodoList.Load();
            UIMgr.OpenPanel<PanelTodoList>(new PanelTodoListData()
            {
                Model = mModel,
            });
        }

        private void OnApplicationQuit()
        {
            mModel.Save();
        }
    }


    public class TodoList
    {
        public ReactiveCollection<TodoItem> TodoItems = new ReactiveCollection<TodoItem>();

        public static TodoList Load()
        {
            var jsonContent = PlayerPrefs.GetString("mTodoListData", string.Empty);
            return jsonContent.IsNotNullAndEmpty() ? jsonContent.FromJson<TodoList>() : new TodoList();
        }

        public void Save()
        {
            PlayerPrefs.SetString("mTodoListData", this.ToJson());
        }
    }

    public class TodoItem
    {
        public BoolReactiveProperty Completed = new BoolReactiveProperty(false);

        public StringReactiveProperty Content = new StringReactiveProperty(string.Empty);
    }
}
