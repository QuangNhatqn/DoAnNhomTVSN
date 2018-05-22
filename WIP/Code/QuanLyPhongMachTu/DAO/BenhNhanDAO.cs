using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DAO;
namespace DAO
{
    public  class BenhNhanDAO
    {

        // khoi tao bien ket noi
        static SqlConnection Con;
        //Load benhnhan
        public static List<BENHNHAN> LoadBenhNhan()
        {
            // khai bao truy van sql
            string sTruyVan = "select * from BENHNHAN";
            // Mo ket noi
            Con = DataProvider_1.KetNoi();
            // Tien hanh truy van
            DataTable dt = DataProvider_1.LayDataTable(sTruyVan, Con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // tao List BenhNhan_DTO
            List<BENHNHAN> listbn = new List<BENHNHAN>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BENHNHAN bn = new BENHNHAN();
                bn.MaBN1 = dt.Rows[i]["MaBN"].ToString();
                bn.TenBN1 = dt.Rows[i]["TenBN"].ToString();
                bn.NgaySinh1 = DateTime.Parse(dt.Rows[i]["NgaySinh"].ToString());
                bn.DiaChi1 = dt.Rows[i]["DiaChi"].ToString();
                bn.DienThoai1 = dt.Rows[i]["DienThoai"].ToString();
                bn.GioiTinh1 = dt.Rows[i]["GioiTinh"].ToString();
                listbn.Add(bn);
            }
            DataProvider_1.DongKetNoi(Con);
            return listbn;
        }
        // Them BenhNhan
        public static bool ThemBenhNhan(BENHNHAN bnDTO)
        {
            // tao cau truy van
            // string sTruyVan = @"insert into BENHNHAN(MaBN,TenBN) value"; -- them mot vai thanh phan vao bang
            string sTruyVan = string.Format("insert into BENHNHAN values ('{0}',N'{1}','{2}',N'{3}',{4},N'{5}')", bnDTO.MaBN1, bnDTO.TenBN1, bnDTO.NgaySinh1, bnDTO.DiaChi1, bnDTO.DienThoai1, bnDTO.GioiTinh1);// them day du thong tin cua bang
            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);
                // dong ket noi
                DataProvider_1.DongKetNoi(Con);
                return true;
            }
            catch (Exception ex)
            {

                DataProvider_1.DongKetNoi(Con);
                return false;
            }
            // DataProvider_1.DongKetNoi(Con);


        }

        // sua benh nhan

        public static bool SuaBenhNhan(BENHNHAN bnDTO)
        {
            string sTruyVan = string.Format("update BENHNHAN set TenBN=N'{0}',NgaySinh='{1}',DiaChi=N'{2}',DienThoai='{3}',GioiTinh=N'{4}' where MaBN='{5}'", bnDTO.TenBN1, bnDTO.NgaySinh1, bnDTO.DiaChi1, bnDTO.DienThoai1, bnDTO.GioiTinh1, bnDTO.MaBN1);
            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);
                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                return true;
            }
            catch (Exception ex)
            {
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }

        // xoa benh nhan
        public static DataTable TaoBang(BENHNHAN bnDTO)
        {

            string x = "BN003";
            //string query = "select pk.MaPK from BENHNHAN bn , PHIEUKHAM pk where bn.MaBN = pk.MaBN and bn.MaBN ='BN001'";
            //string query = "select pk.MaPK from BENHNHAN bn , PHIEUKHAM pk where bn.MaBN = pk.MaBN and bn.MaBN ='"+bnDTO.MaBN1+"' ";
            string query = string.Format("select pk.MaPK from BENHNHAN bn , PHIEUKHAM pk where bn.MaBN = pk.MaBN and bn.MaBN ='{0}'", x);

            // string query = string.Format("select PHIEUKHAM.MaPK from BENHNHAN , PHIEUKHAM  where BENHNHAN.MaBN = PHIEUKHAM.MaBN and BENHNHAN.MaBN =N'{0}'", bnDTO.MaBN1);
            //string query = string.Format("select PHIEUKHAM.MaPK from PHIEUKHAM  where  PHIEUKHAM.MaBN =N'{0}'", bnDTO.MaBN1);
            //string query = "select *from PHIEUKHAM";
            Con = DataProvider_1.KetNoi();

            DataTable dt = DataProvider_1.LayDataTable(query, Con);

            DataProvider_1.DongKetNoi(Con);

            return dt;
        }

        public static bool XoaCTTT(string x)
        {
            String sTruyVan = string.Format("delete from CTTT where MaPK ='{0}'", x);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                return true;
            }
            catch (Exception ex)
            {
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }

        public static  bool XoaHoaDon(string x)
        {
            String sTruyVan = string.Format("delete from HOADON where MaPK ='{0}'", x);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                return true;
            }
            catch (Exception ex)
            {
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }

        public static bool XoaPhieKham(string x)
        {
            String sTruyVan = string.Format("delete from PHIEUKHAM where MaPK ='{0}'", x);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                return true;
            }
            catch (Exception ex)
            {
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }
        public static void DuyetBang(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return;
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                //foreach (DataRow row in dt.Rows) // Duyệt từng dòng (DataRow) trong DataTable
                //{

                //foreach (var item in row.ItemArray) // Duyệt từng cột của dòng hiện tại
                //{
                string x = dt.Rows.ToString();
                //num = Convert.ToInt32(ds.Table["DSTinh"].Rows[i].Item["columnName"].ToString());
                
                if (XoaCTTT(x) == true)
                        {
                            if (XoaHoaDon(x) == true)
                            {
                                if(XoaPhieKham(x) == true)
                                {

                                }
                            }
                        }
                 else
                            return;

                //    }
                //}
                // Pause.

            }
        }

        public  static bool XoaBenhNhan(BENHNHAN bnDTO)
        {
            DataTable dt = TaoBang(bnDTO);
            DuyetBang(dt);
            
            String sTruyVan = string.Format("delete from BENHNHAN where MaBN ='{0}'", bnDTO.MaBN1);

            Con = DataProvider_1.KetNoi();
            try
            {
                // thuc thi truy van
                DataProvider_1.ThucThiTruyVanNonQuery(sTruyVan, Con);

                // dong truy van
                DataProvider_1.DongKetNoi(Con);
                return true;
            }
            catch (Exception ex)
            {
                DataProvider_1.DongKetNoi(Con);
                return false;
            }
        }
    }
}

