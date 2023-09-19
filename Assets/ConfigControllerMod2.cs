using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigControllerMod2 : MonoBehaviour
{
    [SerializeField] private Dropdown _dropdownSpeed, _dropdownMusic;

    private List<string> _musicList;


    private static ConfigControllerMod2 _instance = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public static ConfigControllerMod2 Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    public Dropdown DropdownMusic
    {
        get { return _dropdownMusic; }
        set { _dropdownMusic = value; }
    }

    public Dropdown DropdownSpeed
    {
        get { return _dropdownSpeed; }
        set { _dropdownSpeed = value; }
    }


    private void Start()
    {
        InitializeLists();
        InitializeDropdown();
        AddListeners();
    }

    private void InitializeLists()
    {
        _musicList = new List<string> { "Cai, Cai Balão", "Barata", "Sapo" };
    }

    private void InitializeDropdown()
    {
        DropdownMusic.AddOptions(_musicList);
    }

    private void AddListeners()
    {
        DropdownMusic.onValueChanged.AddListener((value) => { SetConfig.Instance.SelectMusic(); });
        //DropdownSpeed.onValueChanged.AddListener((value) => { SetConfig.Instance.SelectSpeed(); });
    }
}
