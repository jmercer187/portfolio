using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables;
using System.Data.SqlClient;
using System.Data;

namespace GuildCars.Data
{
    public class VehicleComponentsRepo : IVehicleComponentsRepo
    {
        public List<BodyStyle> GetAllBodyStyles()
        {
            List<BodyStyle> bodyStyles = new List<BodyStyle>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayBodyStyles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyle currentRow = new BodyStyle();

                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();

                        bodyStyles.Add(currentRow);
                    }
                }
            }
            return bodyStyles;
        }

        public List<Color> GetAllColors()
        {
            List<Color> colors = new List<Color>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayColors", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Color currentRow = new Color();

                        currentRow.ColorId = (int)dr["ColorId"];
                        currentRow.ColorName = dr["ColorName"].ToString();

                        colors.Add(currentRow);
                    }
                }
            }
            return colors;
        }

        public List<Interior> GetAllInteriors()
        {
            List<Interior> interiors = new List<Interior>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayInteriors", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Interior currentRow = new Interior();

                        currentRow.InteriorId = (int)dr["InteriorId"];
                        currentRow.InteriorType = dr["InteriorType"].ToString();

                        interiors.Add(currentRow);
                    }
                }
            }
            return interiors;
        }

        public List<Make> GetAllMakes()
        {
            List<Make> makes = new List<Make>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayMakes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make currentRow = new Make();

                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.UserName = dr["UserName"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];

                        makes.Add(currentRow);
                    }
                }
            }
            return makes;
        }

        public List<Model> GetAllModels()
        {
            List<Model> models = new List<Model>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayModels", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();

                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.UserName = dr["UserName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];

                        models.Add(currentRow);
                    }
                }
            }
            return models;
        }

        public List<Transmission> GetAllTransmissions()
        {
            List<Transmission> transmissions = new List<Transmission>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayTransmissions", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmission currentRow = new Transmission();

                        currentRow.TransmissionId = (int)dr["TransmissionId"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();

                        transmissions.Add(currentRow);
                    }
                }
            }
            return transmissions;
        }

        public BodyStyle GetBodyStyleById(int bodyStyleId)
        {
            throw new NotImplementedException();
        }

        public Color GetColorById(int colorId)
        {
            throw new NotImplementedException();
        }

        public Interior GetInteriorById(int interiorId)
        {
            throw new NotImplementedException();
        }

        public Make GetMakeById(int makeId)
        {
            throw new NotImplementedException();
        }

        public Model GetModelById(int modelId)
        {
            throw new NotImplementedException();
        }

        public void InsertBodyStyle(BodyStyle bodyStyle)
        {
            throw new NotImplementedException();
        }

        public void InsertColor(Color color)
        {
            throw new NotImplementedException();
        }

        public void InsertInterior(Interior interior)
        {
            throw new NotImplementedException();
        }

        public void InsertMake(Make make)
        {
            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("InsertMake", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MakeId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                cmd.Parameters.AddWithValue("@UserName", make.UserName);

                cn.Open();

                cmd.ExecuteNonQuery();

                make.MakeId = (int)param.Value;
            };
        }

        public void InsertModel(Model model)
        {
            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("InsertModel", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ModelId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@MakeName", model.MakeName);
                cmd.Parameters.AddWithValue("@UserName", model.UserName);

                cn.Open();

                cmd.ExecuteNonQuery();

                model.ModelId = (int)param.Value;
            }
        }

        public void UpdateBodyStyle(BodyStyle bodyStyle)
        {
            throw new NotImplementedException();
        }

        public void UpdateColor(Color color)
        {
            throw new NotImplementedException();
        }

        public void UpdateInterior(Interior interior)
        {
            throw new NotImplementedException();
        }

        public void UpdateMake(Make make)
        {
            throw new NotImplementedException();
        }

        public void UpdateModel(Model model)
        {
            throw new NotImplementedException();
        }
    }
}
