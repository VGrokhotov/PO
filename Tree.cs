using System;
using System.Collections.Generic;

namespace PO{

    /// <summary>
    /// Family Tree Class
    /// </summary>
    public class Tree{


        /// <summary>
        /// Name of Tree
        /// </summary>
        private string treeName; 

        /// <summary>
        /// Getter of all Persons list
        /// </summary>
        /// <value>
        /// List of Persons of family tree
        /// </value>
        public Person root { get; }

        /// <summary>
        /// Tree class constructor
        /// </summary>
        /// <param name="root"> Last child of Tree</param>
        /// <param name="treeName">Name of Tree</param>
        public Tree(Person root, string treeName){
            this.root = root;
            this.treeName = treeName;
            this.SetLevels();
        }

        /// <summary>
        /// Tree string representation
        /// </summary>
        /// <returns>
        /// Returns the entire family Tree as a string, arranging Person on an equal footing
        /// </returns>
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

        /// <summary>
        /// Sets affinity levels in a tree, invoking a SetLevel function of the root
        /// </summary>
        
        public void SetLevels(){
            this.root.SetLevel(0);
        }
    }
}