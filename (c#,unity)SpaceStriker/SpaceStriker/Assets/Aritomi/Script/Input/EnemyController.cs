using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    /// <summary>
    /// エネミーコントローラー
    /// 有冨勇帆
    /// </summary>
    public class EnemyController : Controller
    {
        [SerializeField]
        private Sensor sensor;  //! センサー

        /// <summary>
        /// 状態
        /// </summary>
        private enum STEP
        {
            ACTION_WAIT,        //! 待機状態
            ACTION_AVOIDANCE,   //! 回避状態
            ACTION_SHOT,        //! 攻撃状態
        }
        STEP step;

        /// <summary>
        /// 入力情報
        /// </summary>
        private enum TouchButton
        {
            TOUCH_TOP = 0,
            TOUCH_RIGHT,
            TOUCH_LEFT,
            TOUCH_CHAGE,
        }

        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// 撃つ処理
        /// </summary>
        private void Shot()
        {
            int rnd = Random.Range(0, 3);

            switch (rnd)
            {
                case (int)TouchButton.TOUCH_TOP:
                    inputState = InputState.TOUCH_TOP;
                    break;
                case (int)TouchButton.TOUCH_RIGHT:
                    inputState = InputState.TOUCH_RIGHT;
                    break;
                case (int)TouchButton.TOUCH_LEFT:
                    inputState = InputState.TOUCH_LEFT;
                    break;
            }
        }

        /// <summary>
        /// 入力情報更新
        /// </summary>
        protected override void InputStateUpdate()
        {
            switch (step)
            {
                case STEP.ACTION_WAIT:

                    return;

                case STEP.ACTION_AVOIDANCE:

                    return;

                case STEP.ACTION_SHOT:

                    return;
            }
        }
    }
}
