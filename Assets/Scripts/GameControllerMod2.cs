using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControllerMod2 : MonoBehaviour
{
    private static GameControllerMod2 _instance = null;
    // private float timeLevel;
    // public static bool stopTime = false ;
    //public Text timeLevel_txt;
    public GameState gameState;

    public float speed;

    public int[] caicai, barata, sapo; //<- Partitura

    public Color[] cor;
    public GameObject[] botoes;


    public List<int> coresSeq;
    public int idResposta, tamanhoSeq,
               rodada;

    private AudioSource fonteAudio;
    public AudioClip[] sons;
    public AudioClip[] caicaiNotas100, caicaiNotas80, caicaiNotas60;
    public AudioClip[] barataNotas60, barataNotas50, barataNotas40;
    public AudioClip[] sapoNotas100, sapoNotas80, sapoNotas60;


    public bool verificar;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public static GameControllerMod2 Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    void Start()
    {

        InitializeIndex();

    }

    public void InitializeIndex()
    {
        fonteAudio = GetComponent<AudioSource>();
        speed = 0.5f;
        tamanhoSeq = Mathf.FloorToInt(SetConfig.Instance.SequenceSize);
        //SondSelect();
    }

    int musicSelect(int c)
    {
        if(SetConfig.Instance.Music == 0)
        {
            return caicai[c];
        }
        else if (SetConfig.Instance.Music == 1)
        {
            return barata[c];
        }
        else
        {
            return sapo[c];
        }
    }

    void SondPlay(int c)
    {
        Debug.Log(c);
        if (SetConfig.Instance.MusicSpeed == 2)
        {
            if (SetConfig.Instance.Music == 0)
            {
                fonteAudio.PlayOneShot(caicaiNotas60[c]);
               /* speed = 0.7f;
                if (SetConfig.Instance.Sonds == 0)
                {
                    
                }
                else if (SetConfig.Instance.Sonds == 0)
                {

                }
                else
                {

                }*/
                Debug.Log("Lento");
            }
            else if (SetConfig.Instance.Music == 1)
            {
                speed = 0.7f;
                fonteAudio.PlayOneShot(barataNotas40[c]);
                Debug.Log("Lento");
            }
            else
            {
                speed = 0.7f;
                fonteAudio.PlayOneShot(sapoNotas60[c]);
                Debug.Log("Lento");
            }
        }
        else if(SetConfig.Instance.MusicSpeed == 1)
        {
            if (SetConfig.Instance.Music == 0)
            {
                speed = 0.6f;
                fonteAudio.PlayOneShot(caicaiNotas80[c]);
                Debug.Log("medio");
            }
            else if (SetConfig.Instance.Music == 1)
            {
                speed = 0.6f;
                fonteAudio.PlayOneShot(barataNotas50[c]);
                Debug.Log("medio");
            }
            else
            {
                speed = 0.6f;
                fonteAudio.PlayOneShot(sapoNotas80[c]);
                Debug.Log("medio");
            }
        }
        else
        {
            if (SetConfig.Instance.Music == 0)
            {
                speed = 0.5f;
                fonteAudio.PlayOneShot(caicaiNotas100[c]);
                Debug.Log("rapido");
            }
            else if (SetConfig.Instance.Music == 1)
            {
                speed = 0.5f;
                fonteAudio.PlayOneShot(barataNotas60[c]);
                Debug.Log("rapido");
            }
            else
            {
                speed = 0.5f;
                fonteAudio.PlayOneShot(sapoNotas100[c]);
                Debug.Log("rapido");
            }
            
        }

    }


    public void StartMusic()
    {
        StartCoroutine("Sequencia", GameController.Instance.tamanhoSeq + GameController.Instance.rodada);
    }

    public void NovaRodada()
    {

        foreach (GameObject obj in botoes)
        {
            obj.SetActive(false);
        }

        coresSeq.Clear();

    }

    IEnumerator Sequencia(int qtd)
    {
        //startButton.SetActive(false);
        int c = 0;
        for (int r = qtd; r > 0; r--)
        {
            //Debug.Log("r");
            //Debug.Log(r);
            
            //Debug.Log("qtd");
            //Debug.Log(qtd);

            //Debug.Log(botoes.Length);
            //Debug.Log(Mathf.FloorToInt(SetConfig.Instance.ButtonNumber));

            yield return new WaitForSeconds(speed);
            
            
            int i = musicSelect(c); // caicai[c];

            botoes[i].SetActive(true);
            SondPlay(c);
            //Debug.Log("c");
            //Debug.Log(c);
            //Debug.Log("i");
            //Debug.Log(i);
           // Debug.Log("----------");
            GameController.Instance.coresSeq.Add(i);
            c += 1;

            yield return new WaitForSeconds(speed);
            botoes[i].SetActive(false);
        }

    }

   
}
