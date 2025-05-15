using UnityEngine;

public class Case
{
    string title = "";
    string description = "";
    string createdTime = "";
    int caseId = 0;
    int casePriority = 0;//0 - Urgent; 1 - High; 2 - Standard

    public Case(string title, string description, string createdTime, int caseId, int casePriority)
    {
        this.title = title;
        this.description = description;
        this.createdTime = createdTime;
        this.caseId = caseId;
        this.casePriority = casePriority;
    }

}
