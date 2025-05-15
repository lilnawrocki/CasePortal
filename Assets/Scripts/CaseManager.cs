using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;
public class CaseManager : MonoBehaviour
{
    public TMP_InputField CaseTitleTMP;
    public TMP_InputField CaseDescriptionTMP;
    public TMP_Dropdown CasePriorityDropdown;
    public GameObject CreateCasePanel;

    string caseTitle = "";
    string caseDescription = "";
    string createdTime = "";
    int caseId = 0;
    int casePriority = 0;

    public List<Case> CasesList;

    void Awake()
    {
        CasesList = new List<Case>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateCase()
    {
        createdTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        if (CaseTitleTMP) caseTitle = CaseTitleTMP.text;
        if (CaseDescriptionTMP) caseDescription = CaseDescriptionTMP.text;
        if (CasePriorityDropdown) casePriority = CasePriorityDropdown.value;


        Debug.Log($"Case creation time: {createdTime}");
        Debug.Log($"Case title: {caseTitle}");
        Debug.Log($"Case description: {caseDescription}");
        Debug.Log($"Case priority: {casePriority}");

        Case supportCase = new Case(caseTitle, caseDescription, createdTime, caseId, casePriority);
        CasesList.Add(supportCase);
        Debug.Log($"Case created! Case ID: {caseId}");
        caseId = CasesList.Count;
        Debug.Log($"CaseList length: {CasesList.Count}");
    }

    public void ClearFields()
    {
        if (CaseTitleTMP) CaseTitleTMP.text = "";
        if (CaseDescriptionTMP) CaseDescriptionTMP.text = "";
        if (CasePriorityDropdown) CasePriorityDropdown.value = 0;

        Debug.Log("ClearFields() executed");
    }
}
