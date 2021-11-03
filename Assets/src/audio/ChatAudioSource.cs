//======================================================================================
/**
 *  时间：2021/7/1 11:17:41
 *  功能：聊天的语音频道
 */
//======================================================================================

using Modle;
using UnityEngine;
using UnityEngine.UI;
using static ChatAudio.LongButtom;

namespace ChatAudio
{
    class ChatAudioSource : MonoBehaviour
    {
        /// <summary>
        /// 音频组件
        /// </summary>
        //[AttComInfo ("AudioSource")]
        public AudioSource audioSource;

        /// <summary>
        /// 录音按钮
        /// </summary>
        //[AttComInfo ("DeviceBtn")]
        public LongButtom deviceBtn;

        /// <summary>
        /// 录音状态
        /// </summary>
        public Text audioStateText;


        public AudioClip audioTest;

        /// <summary>
        /// 播放MP3
        /// </summary>
        public Button playMp3;

        /// <summary>
        /// 路径
        /// </summary>
        public Text pathUrl;

        /// <summary>
        /// 录音频率
        /// </summary>
        private int _frequency = 44100;

        /// <summary>
        /// 录音最大时长
        /// </summary>
        private int _maxAudioTime = 15;

        protected void OnEnable()
        {
            addEventList();
            Application.RequestUserAuthorization(UserAuthorization.Microphone);
        }

        protected void OnDisable()
        {
            removeEventList();
        }

        private void addEventList()
        {
            deviceBtn.touchCall = onTouchAudioState;
            deviceBtn.cancelCall = onCancelCallAudio;
            playMp3.onClick.AddListener(onPlayRes);
        }

        private void removeEventList()
        {
            deviceBtn.touchCall = null;
            deviceBtn.cancelCall = null;
            playMp3.onClick.RemoveListener(onPlayRes);
        }

        /// <summary>
        /// 是否存在麦克风设备
        /// </summary>
        public bool GetMicrophoneDevice()
        {
            bool isHave = true;
            string[] mDevice = Microphone.devices;
            if (mDevice.Length == 0)
            {
                isHave = false;
                audioStateText.text = "找不到麦克风设备";
            }
            return isHave;
        }

        private void onTouchAudioState(LongTouchCallType data)
        {
            if (data.state)
            {
                audioStateText.text = "按下";
                beginRecording();
            }
            else
            {
                audioStateText.text = "抬起";
                stopRecording();
                saveAudioFile((int)data.longTouchTime);
            }
        }

        /// <summary>
        /// 取消录音
        /// </summary>
        /// <param name="state"></param>
        private void onCancelCallAudio(bool state)
        {
            audioStateText.text = "取消录音";
            stopRecording();
        }

        private void onPlayRes()
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, new Vector3());
        }

        /// <summary>
        /// 保存录音
        /// </summary>
        /// <param name="url"></param>
        private void saveAudioFile(int time = 1, string url = "/audio/world/Audio2021Uid001.mp3")
        {
            string path = $"{AudioModle.AssetCachesDir}{url}";
            if (audioSource.clip != null)
            {
                int position = time * _frequency;
                Microphone.GetPosition(null);
                AudioClip clip = AudioClip.Create("Audio2021Uid002",
                                        position,
                                        audioSource.clip.channels,
                                        audioSource.clip.frequency,
                                        false);
                float[] data = new float[position * audioSource.clip.channels];
                audioSource.clip.GetData(data, 0);
                clip.SetData(data, 0);
            }
            else
            {
                audioStateText.text = "not find clip ,please touch startAudio bottom";
            }
        }

        private void beginRecording()
        {
            if (!GetMicrophoneDevice())
            {
                return;
            }
            audioSource.Stop();
            audioSource.loop = false;
            audioSource.mute = true;
            audioStateText.text = "开始录音";
            audioSource.clip = Microphone.Start(null, true, _maxAudioTime, _frequency);
            audioSource.Play();
            //audioSource.pitch = 1;
            pathUrl.text = "beginRecording audio:" + audioSource.pitch;
        }

        private void stopRecording()
        {
            if (!Microphone.IsRecording(null))
            {
                return;
            }
            Microphone.End(null);
            audioSource.Stop();
        }

    }
}
