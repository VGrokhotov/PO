# Family tree
It is project for creating the Family tree and saving it to local file.

## Usage

To make Tree just write in you project after installing of dependences:

```
    Parser parser = new Parser();
    parser.StartParsing();
```
After you run this code you can choose one of following command:
1. Enter Person
2. Show all entered Persons
3. Add relationships
4. Show the Tree
5. Write tree to `txt` file
6. Quit

### Enter Person
Enter in one line person Name, Surname, Burthday (in dd.mm.yyyy format) and Gender (male or female) with " " separator.

### Show all entered Persons
This command will show all `Person`s you has entered.

### Add relationships
After you call this command you will see all entering persons. You should at first choose the parent and then a child to make relationship. Relation sister-brother will be added automaticly.

### Show the Tree
After entering tree name you will see the person list and enter the index of root person (last child). Then you will see the string representation of your tree.

### Write tree to `txt` file
Same logic as `Show the Tree` but will create `tree.txt` file in project derectory.
