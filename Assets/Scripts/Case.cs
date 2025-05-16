using UnityEngine;

public class Case
{
    string firstName = "";
    string lastName = "";
    string email = "";
    string title = "";
    string description = "";
    string createdTime = "";
    int caseId = 0;
    int casePriority = 0;//0 - Urgent; 1 - High; 2 - Standard

    public Case(string firstName, string lastName, string email, string title, string description, string createdTime, int caseId, int casePriority)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.title = title;
        this.description = description;
        this.createdTime = createdTime;
        this.caseId = caseId;
        this.casePriority = casePriority;
    }
    public string GetFirstName()
    {
        return firstName;
    }
    public string GetLastName()
    {
        return lastName;
    }
    public string GetEmail()
    {
        return email;
    }
    public string GetTitle()
    {
        return title;
    }

    public string GetDescription()
    {
        return description;
    }

    public string GetCreatedTime()
    {
        return createdTime;
    }

    public int GetCaseId()
    {
        return caseId;
    }

    public int GetCasePriorityInt()
    {
        return casePriority;
    }
    public string GetCasePriority()
    {
        string output = "";
        if (casePriority == 0) output = "Urgent";
        if (casePriority == 1) output = "High";
        if (casePriority == 2) output = "Standard";

        return output;
    }

}
