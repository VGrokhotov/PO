using System;
using System.Collections.Generic;

namespace PO{
    public class Person{

        private string name;

        private string surname;

        private Gender gender;

        private DateTime birthday;

        private Person father;

        private Person mother;

        private List<Person> children = new List<Person>();

        public int level { get; set; }

        public Person(string name, string surname, DateTime birthday, Gender gender){
            this.name = name;
            this.birthday = birthday;
            this.surname = surname;
            this.gender = gender;
        }

        public void AddChild(Person child){
            if (this.gender == Gender.male){
                child.father = this;
            } else {
                child.mother = this;
            }
            
            this.children.Add(child);
        }

        public void AddChild(List<Person> children){
            foreach (var child in children)
            {
                this.AddChild(child);
            }
        }

        public void SetLevel(int level){
            this.level = level;
            foreach (var parent in this.GetParents)
            {
                parent.SetLevel(this.level + 1);
            }
        }

        public List<Person> GetParents{
            get {
                List<Person> parents = new List<Person>();
                if (this.mother != null){
                    parents.Add(this.mother);
                }

                if (this.father != null){
                    parents.Add(this.father);
                }
                return parents;
            }
        }

        public List<Person> GetChildren{
            get => this.children;
        }

        override public string ToString(){
            return (name + " " + surname + ", birthday: " + birthday.ToString("dd.MM.yyyy"));
        }
    }
}

public enum Gender {
    male,
    female
}