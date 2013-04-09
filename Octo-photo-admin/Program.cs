using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octo_photo_library;

namespace Octo_photo_admin
{
    class Program
    {
        static void Main(string[] args)
        {
            /*while (true)
            {
                String line = Console.ReadLine();
            }*/
            ImageInterface im = new ImageInterface();
            im.getImage("1");
        }
    }
}