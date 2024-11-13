using System;
using System.Windows.Forms;

namespace Municipality
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenuForm()); // Set MainMenuForm as the startup form
        }
    }
}
