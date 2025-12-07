using UnityEngine;

public class playerDecision : MonoBehaviour
{
    public compareNPCdata result;
    public newNPC comparisonResult;
    public void Accept()
    {
        // NPC and Mon were equal
        if (result.CompareData() == 1) { comparisonResult.check = 1; }

        // NPC and Mon were NOT equal
        else { comparisonResult.check = 2; }
    }

    public void Deny()
    {
        // NPC and Mon were NOT equal
        if (result.CompareData() == 2) { comparisonResult.check = 1; }

        else { comparisonResult.check = 2; }
    }
}
