using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



internal class Program
{
 
   static void Main(string[] args)
    {
        var c = new Test();

        try
        {
            c.OpenFile("example.txt");
        }

        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        finally
        {
            c.Dispose();
        }
         
           
    }

}

    internal  class Test : IDisposable
    {
        private StreamContent? streamContent = null;

        public void OpenFile(string filename)
        {
            streamContent= new StreamContent(File.Open("example.txt", FileMode.Open)); // unmaged Ressources
        }
        public void Dispose()
        {
            streamContent?.Dispose(); // Here we dispose of the unmanaged resource
            GC.SuppressFinalize(this); // Preventing a redundant garbage collector finalize call
        }
    }




