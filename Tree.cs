using System;
using System.Collections.Generic;

namespace PO{

    public class Tree{

        private string treeName; 

        public Person root { get; }

        public Tree(Person root, string treeName){
            this.root = root;
            this.treeName = treeName;
            this.SetLevels();
        }

        override public string ToString(){

            List<string> result = new List<string>();
            result.Add($"{this.treeName} tree:");

            Person currentPerson = root;
            int currentLevel = -1;
            Queue<Person> queue = new Queue<Person>();
            queue.Enqueue(currentPerson);

            while (queue.Count != 0){
                currentPerson = queue.Dequeue();
                if ( currentLevel != currentPerson.level){
                    result[result.Count - 1] += "\n";
                    currentLevel = currentPerson.level;
                    result.Add("");
                }
                result[result.Count - 1] += currentPerson + " ";
                foreach (var parent in currentPerson.GetParents)
                {
                    queue.Enqueue(parent);
                }

            }
            string resultString = result[0];
            result[result.Count - 1] += "\n";
            for (int i = result.Count - 1; i > 0; i--)
            {
                resultString += result[i];
            }
            return resultString;
        }
        
        public void SetLevels(){
            this.root.SetLevel(0);
        }
    }
}