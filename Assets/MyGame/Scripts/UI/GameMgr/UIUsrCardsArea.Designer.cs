/****************************************************************************
 * 2019.2 sysu_wuzh’s Mac mini
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.MyGame
{
	public partial class UIUsrCardsArea
	{
		[SerializeField] public RectTransform Container;

		public void Clear()
		{
			Container = null;
		}

		public override string ComponentName
		{
			get { return "UIUsrCardsArea";}
		}
	}
}
