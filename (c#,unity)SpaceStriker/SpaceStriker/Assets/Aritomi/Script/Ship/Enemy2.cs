using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    /// <summary>
    /// エネミー２
    /// 有冨勇帆
    /// </summary>
    public class Enemy2 : Enemy
    {
        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            //ステータス初期化
            hp              = Status.ENEMY_SHIP_2_HP;
            offensivePower  = Status.ENEMY_SHIP_2_OFFENSIVE_POWER;
            AILevel         = Status.ENEMY_SHIP_2_AI;

            base.Initialize();
        }
    }
}