using UnityEngine;

namespace Assets.Scripts.Models
{
    
    public class Item : ScriptableObject
    {
    }

    [CreateAssetMenu(fileName = "RecordItem", menuName = "ExVivo/Record", order = 1)]
    public class RecordItem : Item
    {
        [Header("Recorded clip")]
        public AudioClip clip;

        [Header("Recorder name")]
        public string recorder;

        [Header("Date recorded")]
        public string recordDate;
    }












}


