using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public static class Constants
    {
        public static int PolynomialOrder = 21;
        public static string DataDirectory = @"C:\git\rouse_data~~";

        // Property to get the solution directory path
        public static string SolutionDirectory
        {
            get
            {
                // Get the full path to the directory of the executing assembly (usually the bin directory)
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Navigate up to the solution directory from the base directory
                // The number of ".." may need to be adjusted depending on the project structure
                DirectoryInfo directoryInfo = new DirectoryInfo(baseDirectory);

                // Assuming the standard structure 'SolutionDir\ProjectDir\bin\Debug' or 'SolutionDir\ProjectDir\bin\Release'
                // Adjust the number of "Parent" calls as necessary for your solution's structure
                DirectoryInfo solutionDirectory = directoryInfo.Parent?.Parent?.Parent;

                // Check if solutionDirectory is not null
                if (solutionDirectory != null)
                {
                    // Return the full path of the solution directory
                    return solutionDirectory.FullName;
                }
                else
                {
                    throw new InvalidOperationException("Solution directory could not be determined.");
                }
            }
        }

        public static string CurrentTime
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMdd_HH_mm_ss");
            }
        }
    }
