/****************************************************************************
 * 2019.2 DESKTOP-UFLMNH7
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.MyGame
{
	public partial class UIUsrMsg
	{
		[SerializeField] public Text HP;
		[SerializeField] public Text MP;

		public void Clear()
		{
			HP = null;
			MP = null;
		}

		public override string ComponentName
		{
			get { return "UIUsrMsg";}
		}
	}
}
