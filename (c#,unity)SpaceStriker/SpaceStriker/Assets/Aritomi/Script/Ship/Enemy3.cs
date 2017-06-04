﻿using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    /// <summary>
    /// エネミー３
    /// 有冨勇帆
    /// </summary>
    public class Enemy3 : Enemy
    {
        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            //ステータス初期化
            hp              = Status.ENEMY_SHIP_3_HP;
            offensivePower  = Status.ENEMY_SHIP_3_OFFENSIVE_POWER;
            AILevel         = Status.ENEMY_SHIP_3_AI;

            base.Initialize();
        }
    }
}