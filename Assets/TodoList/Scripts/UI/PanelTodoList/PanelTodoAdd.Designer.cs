/****************************************************************************
 * 2019.2 DESKTOP-ORJQHD3
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TodoList
{
	public partial class PanelTodoAdd
	{
		[SerializeField] public InputField InputField;
		[SerializeField] public Button BtnOK;
		[SerializeField] public Button BtnDelete;

		public void Clear()
		{
			InputField = null;
			BtnOK = null;
			BtnDelete = null;
		}

		public override string ComponentName
		{
			get { return "PanelTodoAdd";}
		}
	}
}
