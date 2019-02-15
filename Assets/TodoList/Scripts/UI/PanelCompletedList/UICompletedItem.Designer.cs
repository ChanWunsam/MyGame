/****************************************************************************
 * 2019.2 DESKTOP-ORJQHD3
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TodoList
{
	public partial class UICompletedItem
	{
		[SerializeField] public Text Content;
		[SerializeField] public Toggle Completed;
		[SerializeField] public Button AreaClick;

		public void Clear()
		{
			Content = null;
			Completed = null;
			AreaClick = null;
		}

		public override string ComponentName
		{
			get { return "UICompletedItem";}
		}
	}
}
