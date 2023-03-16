using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolovovStroy
{
    public static class Extensions
    {
        public static void OpenNewForm(this Form form, Form newForm, bool closeThis)
        {
            newForm.Show();

            if (closeThis)
            {
                form.Hide();
            }
        }
    }
}
