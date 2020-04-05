using System;
using System.Collections.Generic;
using System.Linq;


namespace PO{
    public class Parser{

        private List<Person> persons = new List<Person>();

        private Tree tree;

        public Parser(){}

        public void StartParsing(){
            bool flag = true;
            System.Console.WriteLine("Welcome to Family Tree Maker app!\nTo continue chose one of the following commands:");
            while (flag){
                
                System.Console.WriteLine("[1] Enter person\n[2] Show all entering persons\n[3] Add relationships\n[4] Show the Tree\n[5] Quit\n");
                string command = System.Console.ReadLine();
                switch (command){
                    case "1":
                        System.Console.Clear();
                        System.Console.WriteLine("Enter in one line person Name, Surname, Burthday (in dd.mm.yyyy format) and Gender (male or female) with \" \" separator.");
                        persons.Add(this.Parse(System.Console.ReadLine()));
                        System.Console.WriteLine("Press enter to continue..");
                        System.Console.ReadLine();
                        System.Console.Clear();
                        break;
                    case "2":
                        System.Console.WriteLine("Showing of all persons");
                        foreach (var person in this.persons)
                        {
                            System.Console.WriteLine(person);
                        }
                        System.Console.WriteLine("Press enter to continue..");
                        System.Console.ReadLine();
                        System.Console.Clear();
                        break;
                    case "3":
                        System.Console.WriteLine("Adding relationships");
                        System.Console.WriteLine("All persons:");
                        int i = 1;
                        foreach (var person in this.persons)
                        {
                            System.Console.WriteLine($"[{i}] " + person);
                            i++;
                        }

                        System.Console.WriteLine("\nEnter index of parent:");
                        int parentIndex;
                        while (true){
                            var stringParentIndex = Console.ReadLine();
                            if (!int.TryParse(stringParentIndex, out int index))
                                Console.WriteLine("Incorrect input, try again");
                            else
                            {
                                if (index < 1 || index > persons.Count)
                                    Console.WriteLine("Incorrect input, try again");
                                else
                                {
                                    parentIndex = index;
                                    break;
                                }
                            }
                        }

                        System.Console.WriteLine("\nEnter index of child:");
                        int childIndex;

                        while (true){
                            var stringChildIndex = Console.ReadLine();
                            if (!int.TryParse(stringChildIndex, out int index))
                                Console.WriteLine("Incorrect input, try again");
                            else
                            {
                                if (index < 1 || index > persons.Count)
                                    Console.WriteLine("Incorrect input, try again");
                                else
                                {
                                    childIndex = index;
                                    break;
                                }
                            }
                        }


                        persons[parentIndex-1].AddChild(persons[childIndex-1]);

                        System.Console.WriteLine("Press enter to continue..");
                        System.Console.ReadLine();
                        System.Console.Clear();
                        break;
                    case "4":
                        System.Console.WriteLine("Showing family tree.\nEnter tree name:");
                        string treeName = System.Console.ReadLine();

                        System.Console.WriteLine("\nAll persons:");
                        int j = 1;
                        foreach (var person in this.persons)
                        {
                            System.Console.WriteLine($"[{j}] " + person);
                            j++;
                        }

                        System.Console.WriteLine("Please, enter the index of root person (last child):");
                        int rootIndex;
                        while (true){
                            var stringParentIndex = Console.ReadLine();
                            if (!int.TryParse(stringParentIndex, out int index))
                                Console.WriteLine("Incorrect input, try again");
                            else
                            {
                                if (index < 1 || index > persons.Count)
                                    Console.WriteLine("Incorrect input, try again");
                                else
                                {
                                    rootIndex = index;
                                    break;
                                }
                            }
                        }

                        this.tree = new Tree(this.persons[rootIndex-1], treeName);
                        System.Console.WriteLine("\n\n" + tree.ToString());
                        
                        System.Console.WriteLine("Press enter to continue..");
                        System.Console.ReadLine();
                        System.Console.Clear();
                        break;
                    case "5":
                        System.Console.WriteLine("You are leaving:((\nGoodbye!");
                        flag = false;
                        break;
                    default:
                        System.Console.WriteLine("Incorrect command, try again");
                        System.Console.WriteLine("Press enter to continue..");
                        System.Console.ReadLine();
                        System.Console.Clear();
                        break;

                }
            }
        }

        public Person Parse(string parsingString){
            string[] personSpecifications = parsingString.Split(" ");
            string name = personSpecifications[0];
            string surname = personSpecifications[1];
            List<int> burthdayParts = (from part in personSpecifications[2].Split(".") 
                                select int.Parse(part) ).ToList<int>();
            DateTime burthday = new DateTime(burthdayParts[2], burthdayParts[1], burthdayParts[0]);
            Gender gender;
            gender = personSpecifications[3] == Gender.male.ToString() ? Gender.male : Gender.female;
            return new Person(name, surname, burthday, gender);
        }
    }
}