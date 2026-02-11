using DVLD_Buisness;

namespace DVLD.GlobalClasses
{
    public class clsGlobal
    {
        public static clsUser User;
        // Define the path to the text file where you want to save the data
        public static string RememberMeFilePath = System.IO.Directory.GetCurrentDirectory() + "\\data.txt";
    }
}
