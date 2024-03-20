using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror; 
using Steamworks; 

public class VoiceChatManager : NetworkBehaviour
{

    public AudioSource[] audioSources;  
    public AudioSource audioSource;


    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetVoiceChat(){
        Debug.Log("VoiceChat Manager heeft hem binnen");
    }

    [TargetRpc (channel = 2)]
    public void Target_PlaySound(NetworkConnection conn, byte[] destBuffer, uint bytesWritten, float voiceVolume, int fromWho)
    {
        //if(fromWho == gamePlayer.ConnectionId){return;}
        
        byte[] destBuffer2 = new byte[22050 * 2];
        uint bytesWritten2;
        EVoiceResult ret = SteamUser.DecompressVoice(destBuffer, bytesWritten, destBuffer2, (uint)destBuffer2.Length, out bytesWritten2, 22050);
        if(ret == EVoiceResult.k_EVoiceResultOK && bytesWritten2 > 0)
        {
            audioSources[fromWho].clip = AudioClip.Create(UnityEngine.Random.Range(100, 1000000).ToString(), 22050, 1, 22050, false);
 
            float[] test = new float[22050];
            for (int i = 0; i < test.Length; i++)
            {
                test[i] = (short)(destBuffer2[i * 2] | destBuffer2[i * 2 + 1] << 8) / 32768.0f;
            }
            audioSources[fromWho].clip.SetData(test, 0);
            audioSources[fromWho].volume = voiceVolume;
            
            audioSources[fromWho].Play();
        }
    }
}
