using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;


namespace BUS
{
    public class QuyDinhTienKhamBUS
    {
        public static float LayGiaCu()
        {
            return QuyDinhTienKhamDAO.LayGiaCu();
        }

        public static bool Sua(float TienKham)
        {
            return QuyDinhTienKhamDAO.Sua(TienKham);
        }
    }
}
