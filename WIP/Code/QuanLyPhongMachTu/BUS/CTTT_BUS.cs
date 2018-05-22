using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class CTTT_BUS
    {
        public static List<CTTT> LoadCTTT()
        {
            return CTTT_DAO.LoadCTTT();
        }

        public static bool XoaCTTT(CTTT CTTTDTO)
        {
            return CTTT_DAO.XoaCTTT(CTTTDTO);
        }
    }
}
