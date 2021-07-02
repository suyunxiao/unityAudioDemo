//======================================================================================
/**
 *  时间：2021/7/1 14:05:01
 *  功能：自定义按钮
 */
//======================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ChatAudio
{
    class LongButtom : Button,IPointerDownHandler, IPointerUpHandler
    {

        /// <summary>
        /// 按下或者抬起响应
        /// </summary>
        public UnityAction<bool> touchCall;

        private bool touchState = false;

        /// <summary>
        /// 按下
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnPointerDown(PointerEventData eventData)
        {
            setTouchCallState(true);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            setTouchCallState(false);
        }

        //public override void OnPointerExit(PointerEventData eventData)
        //{
        //    setTouchCallState(false);
        //}

        private void setTouchCallState(bool state)
        {
            if(touchState == state)
            {
                return;
            }
            touchState = state;
            if (touchCall != null)
            {
                touchCall(state);
            }
        }
    }
}
