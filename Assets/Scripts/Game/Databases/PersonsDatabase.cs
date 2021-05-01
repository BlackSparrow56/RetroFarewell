using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Lore;

namespace Game.Databases
{
    [CreateAssetMenu(menuName = "Databases/PersonsDatabase", fileName = "PersonsDatabase")]
    public class PersonsDatabase : ScriptableObject
    {
        [SerializeField] private List<Person> persons;

        public Person GetPersonByName(string name)
        {
            return persons.FirstOrDefault(value => value.name == name);
        }
    }
}
