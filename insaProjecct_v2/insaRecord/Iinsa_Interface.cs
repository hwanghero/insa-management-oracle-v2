using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insaRecord
{
    public interface Iinsa_Interface
    {
        void DB_Insert();
        void DB_Update();
        void DB_Delete();
        void ShowData();
    }
}
