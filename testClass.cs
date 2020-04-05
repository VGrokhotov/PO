using System;
using Xunit;

namespace PO{
    public class PersonTests{

        [Fact]
        public void ConstructorTest(){
            Person andreyI = new Person("Andrey", "Ivanov", new DateTime(1900, 1, 1), Gender.male);
            Assert.Equal("Andrey Ivanov, birthday: 01.01.1900", andreyI.ToString());
        }

        [Fact]
        public void AddChildMethodTest(){
            Person andreyI = new Person("Andrey", "Ivanov", new DateTime(1900, 1, 1), Gender.male);
            Person ivanI = new Person("Ivan", "Ivanov", new DateTime(1940, 1, 1), Gender.male);
            andreyI.AddChild(ivanI);

            Assert.Equal(true, andreyI.GetChildren.Count > 0);
        }

        [Fact]
        public void GetChildrenMethodTest(){
            Person andreyI = new Person("Andrey", "Ivanov", new DateTime(1900, 1, 1), Gender.male);
            Person ivanI = new Person("Ivan", "Ivanov", new DateTime(1940, 1, 1), Gender.male);
            andreyI.AddChild(ivanI);

            Assert.Equal(ivanI, andreyI.GetChildren[0]);
        }

        [Fact]
        public void GetParentsMethodTest(){
            Person andreyI = new Person("Andrey", "Ivanov", new DateTime(1900, 1, 1), Gender.male);
            Person ivanI = new Person("Ivan", "Ivanov", new DateTime(1940, 1, 1), Gender.male);
            andreyI.AddChild(ivanI);

            Assert.Equal(andreyI, ivanI.GetParents[0]);
        }

        [Fact]
        public void RelationshipBetweenGenerationsTest(){
            Person andreyI = new Person("Andrey", "Ivanov", new DateTime(1900, 1, 1), Gender.male);
            Person ivanI = new Person("Ivan", "Ivanov", new DateTime(1940, 1, 1), Gender.male);
            Person petrI = new Person("Petr", "Ivanov", new DateTime(1960, 1, 1), Gender.male);
            andreyI.AddChild(ivanI);
            ivanI.AddChild(petrI);

            Assert.Equal(andreyI, petrI.GetParents[0].GetParents[0]);
        }
    }

    public class TreeTests{

        [Fact]
        public void treeTest(){
            Person person = new Person("Vlad", "Grokhotov",  new DateTime(1900, 1, 1), Gender.male );
            Person secondPerson = new Person("Genadi", "Grokhotov",  new DateTime(1900, 1, 1), Gender.male );
            secondPerson.AddChild(person);
            Tree tree = new Tree(person, "Grokhotov");
            Assert.Equal(tree.ToString(), "Grokhotov tree:\nfather: Genadi Grokhotov, birthday: 01.01.1900 \nfather: Vlad Grokhotov, birthday: 01.01.1900 \n");
        }

    }
}