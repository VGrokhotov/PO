using System;
using System.IO;

namespace PO{
    class Writer {

        public static void write(Tree tree){
            StreamWriter f = new StreamWriter("test.txt", false);
            f.WriteLine(tree);
        }
    }
}