using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class AssetLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public AssetReference local;
    public AssetLabelReference remote;
    private List<IResourceLocation> resourceLocations;
    public Transform trnsLocal, trnsRemote;


    void Start()
    {
        LoadAsset();
        Debug.LogError("Location___________" + remote.labelString);
        Addressables.LoadResourceLocationsAsync(remote.labelString).Completed += Onloaded;
    }

    private void LoadAsset()
    {
        local.InstantiateAsync(trnsLocal, false);
    }

    private void Onloaded(AsyncOperationHandle<IList<IResourceLocation>> obj)
    {
        resourceLocations = new List<IResourceLocation>(obj.Result);
        Debug.LogError("Location___________" + resourceLocations.Count);
        StartCoroutine(LoadRemoteResources());
    }

    IEnumerator LoadRemoteResources()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < resourceLocations.Count; i++)
        {
            Addressables.InstantiateAsync(resourceLocations[i], trnsRemote, false);
        }

    }
}
