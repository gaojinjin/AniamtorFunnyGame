using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSlider : MonoBehaviour
{
    Animator anim;
    public Slider slider;
    private Vector3 tempPos;
    public float speed;
    public Button animNameBut;
    private string strName= "Anim_0";
    private bool nameSwitch;
    private AudioSource source;
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        anim.speed = 0.001f;
        slider.onValueChanged.AddListener((arg)=> {
            anim.Play(strName, -1, slider.normalizedValue);
            if (!source.isPlaying&& slider.normalizedValue>=0.2f)
            {
                source.Play();
            }
        });
        animNameBut.onClick.AddListener(()=> {
            nameSwitch = !nameSwitch;
            strName = nameSwitch ? "Anim_1" : "Anim_0";
        });
    }

    // Update is called once per frame
    void Update()
    {
        float tempValue = (Input.mousePosition - tempPos).x;
        slider.normalizedValue += tempValue / Screen.width * speed;
        tempPos = Input.mousePosition;
    }
}
