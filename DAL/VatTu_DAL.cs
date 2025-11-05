using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO;
using System.Data;

namespace DAL
{
    public class VatTu_DAL
    {
        private static QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();
        public List<VatTu_DTO> GetAllMaterials()
        {
            var list = (from vt in db.VatTus
                        select new VatTu_DTO
                        {
                            VatTuID = vt.VatTuID,
                            TenVatTu = vt.TenVatTu,
                            DonViTinh = vt.DonViTinh,
                            SoLuongTon = vt.SoLuongTon,
                            NhaCungCapID = vt.NhaCungCapID,
                            HinhAnhVatTu = vt.HinhAnhVatTu
                        }).ToList();
            return list;
        }

        public VatTu_DTO GetMaterialById(int id)
        {
            var vt = db.VatTus.FirstOrDefault(x => x.VatTuID == id);
            if (vt == null) return null;
            return new VatTu_DTO
            {
                VatTuID = vt.VatTuID,
                TenVatTu = vt.TenVatTu,
                DonViTinh = vt.DonViTinh,
                SoLuongTon = vt.SoLuongTon,
                NhaCungCapID = vt.NhaCungCapID,
                HinhAnhVatTu = vt.HinhAnhVatTu
            };
        }

        public void AddMaterial(VatTu vatTu)
        {
            db.VatTus.Add(vatTu);
            db.SaveChanges();
        }

        public void UpdateMaterial(VatTu_DTO vatTuDto)
        {
            var existing = db.VatTus.FirstOrDefault(x => x.VatTuID == vatTuDto.VatTuID);
            if (existing == null) return; // or throw if you prefer
            existing.TenVatTu = vatTuDto.TenVatTu;
            existing.DonViTinh = vatTuDto.DonViTinh;
            existing.SoLuongTon = vatTuDto.SoLuongTon;
            existing.NhaCungCapID = vatTuDto.NhaCungCapID;
            existing.HinhAnhVatTu = vatTuDto.HinhAnhVatTu;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var vt = db.VatTus.FirstOrDefault(x => x.VatTuID == id);
            if (vt == null) return; // or throw if you prefer
            db.VatTus.Remove(vt);
            db.SaveChanges();
        }

        public List<VatTu_DTO> SearchMaterials(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAllMaterials();

            string lower = keyword.Trim().ToLower();
            var list = (from vt in db.VatTus
                        where (vt.TenVatTu != null && vt.TenVatTu.ToLower().Contains(lower))
                           || (vt.DonViTinh != null && vt.DonViTinh.ToLower().Contains(lower))
                        select new VatTu_DTO
                        {
                            VatTuID = vt.VatTuID,
                            TenVatTu = vt.TenVatTu,
                            DonViTinh = vt.DonViTinh,
                            SoLuongTon = vt.SoLuongTon,
                            NhaCungCapID = vt.NhaCungCapID,
                            HinhAnhVatTu = vt.HinhAnhVatTu
                        }).ToList();
            return list;
        }

        public DataTable GetMaterialsInRP(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return GetAllMaterialstoRP();

            var list = (from kh in db.VatTus
                        where (kh.TenVatTu != null && kh.TenVatTu.Contains(text))
                          || (kh.DonViTinh != null && kh.DonViTinh.Contains(text))
                          || (kh.NhaCungCap != null && kh.NhaCungCap.TenNCC.Contains(text))
                        select new VatTu_DTO
                        {
                            VatTuID = kh.VatTuID,
                            TenVatTu = kh.TenVatTu,
                            DonViTinh = kh.DonViTinh,
                            SoLuongTon = kh.SoLuongTon,
                            NhaCungCapID = kh.NhaCungCapID,
                            HinhAnhVatTu = kh.HinhAnhVatTu
                        }).ToList();

            var dt = ConvertToDataTable(list);
            dt.TableName = "VatTu"; // đảm bảo trùng tên bảng trong DataSet/report
            return dt;
        }

        public DataTable GetAllMaterialstoRP()
        {
            var list = (from vt in db.VatTus
                        select new VatTu_DTO
                        {
                            VatTuID = vt.VatTuID,
                            TenVatTu = vt.TenVatTu,
                            DonViTinh = vt.DonViTinh,
                            SoLuongTon = vt.SoLuongTon,
                            NhaCungCapID = vt.NhaCungCapID,
                            HinhAnhVatTu = vt.HinhAnhVatTu,
                            TenNhaCungCap = vt.NhaCungCap != null ? vt.NhaCungCap.TenNCC : null

                        }).ToList();

            var dt = ConvertToDataTable(list);
            dt.TableName = "VatTu"; // đảm bảo trùng tên bảng trong DataSet/report
            return dt;
        }

        public DataTable ConvertToDataTable<T>(List<T> list)
        {
            var props = typeof(T).GetProperties();
            DataTable dt = new DataTable("VatTu"); // report DataSet table name

            foreach (var prop in props)
            {
                var colType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                dt.Columns.Add(prop.Name, colType);
            }

            foreach (var item in list)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    var val = props[i].GetValue(item, null);
                    values[i] = val ?? DBNull.Value;
                }
                dt.Rows.Add(values);
            }
            return dt;
        }
    }
}
