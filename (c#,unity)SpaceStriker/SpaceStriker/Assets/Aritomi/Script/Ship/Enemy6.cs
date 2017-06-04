﻿using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    /// <summary>
    /// エネミー６
    /// </summary>
    public class Enemy6 : Enemy
    {
        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            //ステータス初期化
            hp              = Status.ENEMY_SHIP_6_HP;
            offensivePower  = Status.ENEMY_SHIP_6_OFFENSIVE_POWER;
            AILevel         = Status.ENEMY_SHIP_6_AI;

            base.Initialize();
        }
    }
}