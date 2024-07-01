using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkManager : MonoBehaviour
{
    [SerializeField] GameObject trunkPrefab;
    [SerializeField] GameObject branchLeftPrefab;
    [SerializeField] GameObject branchRightPrefab;
    [SerializeField] GameObject speedBoosterPrefab;
    [SerializeField] GameObject doubleScorePrefab;

    private List<GameObject> branches;

    private bool isToCreateEmpty = true;

    void Start()
    {
        branches = new List<GameObject>();

        for (int i = 0; i < 10; i += 2)
        {
            GameObject trunkEmpty = Instantiate(trunkPrefab);
            trunkEmpty.transform.parent = gameObject.transform;
            trunkEmpty.transform.localPosition = new Vector3(0, i * 1.36f, 0);
            branches.Add(trunkEmpty);

            GameObject trunkBranch = Instantiate(getRandomBranch());
            trunkBranch.transform.parent = gameObject.transform;
            trunkBranch.transform.localPosition = new Vector3(0, (i + 1) * 1.36f, 0);
            branches.Add(trunkBranch);
        }

    }

    private GameObject getRandomBranch()
    {
        int random = Random.Range(0, 100);
        if (random <= 10)
        {
            return trunkPrefab;
        }
        else if (random <= 52)
        {
            return branchLeftPrefab;
        }
        else if (random <= 55)
        {
            return speedBoosterPrefab;
        }
        else if (random <= 58)
        {
            return doubleScorePrefab;
        }
        return branchRightPrefab;
    }
    public void cutFirstTrunk(string _directionPlayer)
    {
        GameObject firstBranch = branches[0];
        if (firstBranch.CompareTag("Booster"))
        {
            if (firstBranch.GetComponent<BoosterManager>() != null)
            {
                firstBranch.GetComponent<BoosterManager>().ApplyBoostEffect();
            }
            Destroy(firstBranch);
            branches.RemoveAt(0);
        }
        else
        {
            firstBranch.GetComponent<Trunk>().onAnimateDestroy(_directionPlayer);
            branches.RemoveAt(0);
        }

        int i = 0;
        for (i = 0; i < branches.Count; i++)
        {
            branches[i].transform.localPosition = new Vector3(branches[i].transform.localPosition.x, i * 1.36f, branches[i].transform.localPosition.z);
        }
        GameObject trunkEmpty = Instantiate(isToCreateEmpty ? trunkPrefab : getRandomBranch());
        trunkEmpty.transform.parent = gameObject.transform;
        trunkEmpty.transform.localPosition = new Vector3(0, i * 1.36f, 0);
        branches.Add(trunkEmpty);

        isToCreateEmpty = !isToCreateEmpty;
    }
    public string getDirectionFirstTrunk()
    {
        return branches[0].GetComponent<Trunk>().direction;
    }
    public void reset()
    {
        //remove all branches
        for (int i = 0; i < branches.Count; i++)
        {
            Destroy(branches[i]);
        }
        branches.RemoveRange(0, branches.Count);
        Start();
    }
}