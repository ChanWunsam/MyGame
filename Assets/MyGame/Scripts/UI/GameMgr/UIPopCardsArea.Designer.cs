/****************************************************************************
 * 2019.2 DESKTOP-UFLMNH7
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.MyGame
{
	public partial class UIPopCardsArea
	{
        [SerializeField] public Button AreaClick;

        public void Clear()
		{
            AreaClick = null;
        }

		public override string ComponentName
		{
			get { return "UIPopCardsArea";}
		}
	}
}
