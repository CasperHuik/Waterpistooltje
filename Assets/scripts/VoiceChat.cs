using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Steamworks;
using UnityEngine.SceneManagement;
 
public class VoiceChat : NetworkBehaviour
{
    public AudioSource[] audioSource;
    public bool speaking = false;
    float sendVolume = 1;
    float distanceBetweenPlayers; 
    public GamePlayer gamePlayer; 
    public int id;
    
    private void Start()
    {
        id = gamePlayer.ConnectionId;
        if(isLocalPlayer){
            audioSource[id].mute = true; 
        }
    }
 
    private void Update()
    {


        if (isLocalPlayer && Input.GetKey(KeyCode.V))
        {
            SteamUser.StopVoiceRecording();
            Debug.Log("Record Stop");
        }
        else if(isLocalPlayer && !Input.GetKey(KeyCode.V))
        {
            SteamUser.StartVoiceRecording();
            Debug.Log("Record Start");
        }
 
        if (isLocalPlayer)
        {
            uint compressed;
            EVoiceResult ret = SteamUser.GetAvailableVoice(out compressed);
            if(ret == EVoiceResult.k_EVoiceResultOK && compressed > 1024)
            {
                //Debug.Log(compressed);
                byte[] destBuffer = new byte[1024];
                uint bytesWritten;
                ret = SteamUser.GetVoice(true, destBuffer, 1024, out bytesWritten);
                if(ret == EVoiceResult.k_EVoiceResultOK && bytesWritten > 0)
                {
                    Cmd_SendData(destBuffer, bytesWritten);
                }
            }
        }
    }
 
    [Command (channel = 2)]
    void Cmd_SendData(byte[] data, uint size)
    {       
        Debug.Log("Versturen naar voicechat manager");
        VoiceChat[] players = FindObjectsOfType<VoiceChat>();
        if(players.Length >= 1){
            for(int i = 0; i < players.Length; i++)
            {
                Target_PlaySound(players[i].GetComponent<NetworkIdentity>().connectionToClient, data, size, sendVolume, gamePlayer.ConnectionId);
                
            
            
            }
        }   
    }
 
 
 
    [TargetRpc (channel = 2)]
    void Target_PlaySound(NetworkConnection conn, byte[] destBuffer, uint bytesWritten, float voiceVolume, int fromWho)
    {

        if(fromWho == gamePlayer.ConnectionId){Debug.Log("Van mezelf");}
        else{Debug.Log("Van een ander");}
        Debug.Log(fromWho);
        byte[] destBuffer2 = new byte[22050 * 2];
        uint bytesWritten2;
        EVoiceResult ret = SteamUser.DecompressVoice(destBuffer, bytesWritten, destBuffer2, (uint)destBuffer2.Length, out bytesWritten2, 22050);
        if(ret == EVoiceResult.k_EVoiceResultOK && bytesWritten2 > 0)
        {
            audioSource[fromWho].clip = AudioClip.Create(fromWho.ToString(), 22050, 1, 22050, false);
 
            float[] test = new float[22050];
            for (int i = 0; i < test.Length; i++)
            {
                test[i] = (short)(destBuffer2[i * 2] | destBuffer2[i * 2 + 1] << 8) / 32768.0f;
            }
            audioSource[fromWho].clip.SetData(test, 0);
            audioSource[fromWho].volume = voiceVolume;
            
            audioSource[fromWho].Play();
        }
    }
}