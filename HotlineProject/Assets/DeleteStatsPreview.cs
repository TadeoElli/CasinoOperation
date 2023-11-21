using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeleteStatsPreview : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button deleteStats;
    [SerializeField] private StaminaSistem staminaSistem;
    void Start()
    {
        staminaSistem = FindObjectOfType<StaminaSistem>();
        deleteStats.onClick.AddListener(staminaSistem.RestartStats);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
