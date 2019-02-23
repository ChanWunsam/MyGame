/****************************************************************************
 * 2019.2 DESKTOP-UFLMNH7
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UniRx;

namespace QFramework.MyGame
{
    public enum GameState
    {
        OwnerTime,
        EnemyTime,
    }

	public partial class Timer : UIElement
	{
        public ReactiveProperty<GameState> State = new ReactiveProperty<GameState>(GameState.OwnerTime);

		public void Init()
		{
            InvokeRepeating("ChangeGameState", 10, 10);

            State.Subscribe((state) =>
            {
                SendEvent(GameMgrEvent.OnPopCardClear);
                if (state == GameState.OwnerTime)
                {
                    Log.I("Owner Time");
                    SendEvent(GameMgrEvent.OnOwnerTime);
                }
                else
                {
                    Log.I("Enemy Time");
                    SendEvent(GameMgrEvent.OnEnemyTime);
                }
            });
		}

        void ChangeGameState()
        {
            State.Value = (State.Value == GameState.OwnerTime) ? GameState.EnemyTime : GameState.OwnerTime;
        }

        protected override void OnBeforeDestroy()
		{
		}
	}
}