﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour {


    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI perSecondText;
    public TextMeshProUGUI currencyName;
    public MiningControllerTemplate myMiningController;

    public Animator sideMenuAnimator;
    public Animator rigsMenuAnimator;
    public bool sideMenuShown;

    public delegate void OnAuxMenuOpened(int rackGroupID);
    public OnAuxMenuOpened openedAuxMenu;

    public delegate void OnAuxMenuClosed();
    public OnAuxMenuClosed closedAuxMenu;


    private void Awake()
    {
        if (myMiningController.currencyName.Length < 3)
        {
            myMiningController.currencyName = "Sweetcoins";
        } 

    }


    // Use this for initializations
    void Start () {
        currencyName.text = myMiningController.currencyName;

	}
    public void ShowRacksSideMenu(int rackGroupOrderNumber = 0)
    {
        if (!sideMenuShown)
        {
            rigsMenuAnimator.gameObject.SetActive(true);
            sideMenuShown = true;
            rigsMenuAnimator.SetBool("SlideOnMenu", false);
            sideMenuAnimator.SetBool("ShowMenu", true);

            // Should call a delegate to make sure that will trigger the aux menu to show the right amount of racks
            openedAuxMenu(rackGroupOrderNumber);

            return;
        }

        HideRackSideMenu();
    }

    public void HideRackSideMenu()
    {
        sideMenuShown = false;
        rigsMenuAnimator.SetBool("SlideOnMenu", true);
        //sideMenuAnimator.SetBool("ShowMenu", false);

        closedAuxMenu();


        return;

    }

    public void HideJustSideRackMenu()
    {
        sideMenuShown = false;

        //sideMenuAnimator.SetBool("ShowMenu", false);

        return;
    }

	// Update is called once per frame
	void Update ()
    {
        balanceText.text = NumberConverter.ConvertNumber(myMiningController.currentBalance);
        perSecondText.text = NumberConverter.ConvertNumber(myMiningController.coinsPerSec) + "/s"; 
	}
}
