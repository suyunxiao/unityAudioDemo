
using UnityEngine;
using DG.Tweening;

public class UseMicrophone : MonoBehaviour
{
    public GameObject obj;
    public static float volume;
    private AudioClip micRecord;
    string device;
    void Start()
    {
        device = Microphone.devices[0];//获取设备麦克风
        micRecord = Microphone.Start(device, true, 999, 44100);//44100音频采样率   固定格式
    }

    private int index = 1;

    void Update()
    {
        index++;
        if (index % 2 != 0)
        {
            return;
        }
        volume = GetMaxVolume();
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    float GetMaxVolume()
    {
        int scanXY = 5;
        int maxSum = obj.transform.childCount * scanXY;
        float maxVolume = 0f;
        //剪切音频
        float[] volumeData = new float[maxSum];
        int offset = Microphone.GetPosition(device) - maxSum;
        if (offset < 0)
        {
            return 0;
        }
        micRecord.GetData(volumeData, offset);

        for (int i = 0; i < volumeData.Length; i++)
        {
            if (i % scanXY == 0)
            {
                float sum = 0;
                for (int y = 0; y < scanXY; ++y)
                {
                    sum += volumeData[y + i];
                }
                float tempMax = sum;//修改音量的敏感值
                if (tempMax < 0.02)
                {
                    tempMax = 0.02f;
                }
                int f = i / scanXY;
                obj.transform.GetChild(f).transform.DOScaleY(tempMax + 0.1f, 0.5f);
            }
        }
        
        return maxVolume;
    }
}