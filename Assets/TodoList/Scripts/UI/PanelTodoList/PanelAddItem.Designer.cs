/****************************************************************************
 * 2019.2 DESKTOP-ORJQHD3
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TodoList
{
	public partial class PanelAddItem
	{
		[SerializeField] public InputField InputField;
		[SerializeField] public Button BtnUpdate;
		[SerializeField] public Button BtnCancel;

		public void Clear()
		{
			InputField = null;
			BtnUpdate = null;
			BtnCancel = null;
		}

		public override string ComponentName
		{
			get { return "PanelAddItem";}
		}
	}
}
