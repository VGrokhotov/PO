using System;
using System.Collections.Generic;

namespace PO{
    /// <summary>
    /// Person class
    /// </summary>
    public class Person{

        /// <summary>
        /// Person name
        /// </summary>
        private string name;

        /// <summary>
        /// Person surname
        /// </summary>
        private string surname;

        /// <summary>
        /// Person Gender
        /// </summary>
        private Gender gender;

        /// <summary>
        /// Person birthday
        /// </summary>
        private DateTime birthday;

        /// <summary>
        /// Person parents list
        /// </summary>
        /// <typeparam name="Person"></typeparam>
        /// <returns>Person parents list</returns>
        private List<Person> parents = new List<Person>();

        /// <summary>
        /// Person children list
        /// </summary>
        /// <typeparam name="Person"></typeparam>
        /// <returns>Person children list</returns>
        private List<Person> children = new List<Person>();

        /// <summary>
        /// Level of generation number
        /// </summary>
        /// <remarks>
        /// The last child have level 0
        /// </remarks>
        /// <value></value>
        public int level { get; set; }

        /// <summary>
        /// Person constructor
        /// </summary>
        /// <param name="name">Name of Person</param>
        /// <param name="surname">Surname of Person</param>
        /// <param name="birthday">Birthday of Person</param>
        /// <param name="gender">Gender of Person</param>
        public Person(string name, string surname, DateTime birthday, Gender gender){
            this.name = name;
            this.birthday = birthday;
            this.surname = surname;
            this.gender = gender;
        }

        /// <summary>
        /// Add child to Person children list
        /// </summary>
        /// <param name="child">Child who is added</param>
        public void AddChild(Person child){
            child.parents.Add(this);
            this.children.Add(child);
        }

        /// <summary>
        /// Add children to Person children list
        /// </summary>
        /// <param name="children">List of childrens which are added </param>
        public void AddChild(List<Person> children){
            foreach (var child in children)
            {
                this.AddChild(child);
            }
        }

        /// <summary>
        /// Recursively sets levels of generation for Person and all his/her parents
        /// </summary>
        /// <param name="level">Setting level</param>
        public void SetLevel(int level){
            this.level = level;
            foreach (var parent in this.parents)
            {
                parent.SetLevel(this.level + 1);
            }
        }
        /// <summary>
        /// Getter for parents list 
        /// </summary>
        /// <value>Parents list</value>
        public List<Person> GetParents{
            get => this.parents;
        }

        /// <summary>
        /// Getter for children list
        /// </summary>
        /// <value>Children list</value>
        public List<Person> GetChildren{
            get => this.children;
        }

        /// <summary>
        /// Covert Person to string format
        /// </summary>
        /// <returns></returns>
        override public string ToString(){
            return (name + " " + surname + ", birthday: " + birthday.ToString("dd.MM.yyyy"));
        }
    }
}

/// <summary>
/// Gender enum, male or female
/// </summary>
public enum Gender {
    male,
    female
}