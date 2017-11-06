using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using GuildCars.Models.UIModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data
{
    public class VehicleRepo : IVehicleRepo
    {
        public List<VehicleUI> GetVehicles()
        {
            List<VehicleUI> vehicles = new List<VehicleUI>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayAllVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleUI currentRow = new VehicleUI();

                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorName = dr["ColorName"].ToString();
                        currentRow.Featured = (bool)dr["Featured"];
                        currentRow.ImageFilePath = dr["ImageFilePath"].ToString();
                        currentRow.InteriorType = dr["InteriorType"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ModelYear = dr["ModelYear"].ToString();
                        currentRow.New = (bool)dr["New"];
                        currentRow.Sold = (bool)dr["Sold"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.VehicleDescription = dr["VehicleDescription"].ToString();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        
                        if (dr["SalePrice"] != DBNull.Value)
                            currentRow.SalePrice = (decimal)dr["SalePrice"];

                        vehicles.Add(currentRow);
                    }
                }
            }

                return vehicles;
        }

        public VehicleUI GetVehicleById(int vehicleId)
        {
            VehicleUI vehicle = new VehicleUI();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayVehicleById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        VehicleUI currentRow = new VehicleUI();

                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorName = dr["ColorName"].ToString();
                        currentRow.Featured = (bool)dr["Featured"];
                        currentRow.ImageFilePath = dr["ImageFilePath"].ToString();
                        currentRow.InteriorType = dr["InteriorType"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ModelYear = dr["ModelYear"].ToString();
                        currentRow.New = (bool)dr["New"];
                        currentRow.Sold = (bool)dr["Sold"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.VehicleDescription = dr["VehicleDescription"].ToString();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        if (dr["SalePrice"] != DBNull.Value)
                            currentRow.SalePrice = (decimal)dr["SalePrice"];

                        vehicle = currentRow;
                    }
                }
            }

                return vehicle;
        }

        public void InsertVehicle(VehicleUI vehicle)
        {
            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("VehicleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@BodyStyleName", vehicle.BodyStyleName);
                cmd.Parameters.AddWithValue("@ColorName", vehicle.ColorName);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@ImageFilePath", vehicle.ImageFilePath);
                cmd.Parameters.AddWithValue("@InteriorType", vehicle.InteriorType);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@ModelName", vehicle.ModelName);
                cmd.Parameters.AddWithValue("@ModelYear", vehicle.ModelYear);
                cmd.Parameters.AddWithValue("@New", vehicle.New);
                cmd.Parameters.AddWithValue("@Sold", vehicle.Sold);
                cmd.Parameters.AddWithValue("@TransmissionType", vehicle.TransmissionType);
                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.VehicleDescription);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);

                cn.Open();

                cmd.ExecuteNonQuery();

                vehicle.VehicleId = (int)param.Value;
            }

        }

        public void UpdateVehicle(VehicleUI vehicle)
        {
            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("VehicleUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;


            }



        }

        public void DeleteVehicle(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public List<FeaturedVehicle> GetFeaturedVehicles()
        {
            List<FeaturedVehicle> vehicles = new List<FeaturedVehicle>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayFeaturedVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FeaturedVehicle currentRow = new FeaturedVehicle();
                        
                        currentRow.ImageFilePath = dr["ImageFilePath"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Year = dr["ModelYear"].ToString();
                        currentRow.Price = (decimal)dr["Price"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public List<VehicleUI> GetNewVehicles()
        {
            List<VehicleUI> vehicles = new List<VehicleUI>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayNewVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleUI currentRow = new VehicleUI();

                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorName = dr["ColorName"].ToString();
                        currentRow.Featured = (bool)dr["Featured"];
                        currentRow.ImageFilePath = dr["ImageFilePath"].ToString();
                        currentRow.InteriorType = dr["InteriorType"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ModelYear = dr["ModelYear"].ToString();
                        currentRow.New = (bool)dr["New"];
                        currentRow.Sold = (bool)dr["Sold"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.VehicleDescription = dr["VehicleDescription"].ToString();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        if (dr["SalePrice"] != DBNull.Value)
                            currentRow.SalePrice = (decimal)dr["SalePrice"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public List<VehicleUI> GetUsedVehicles()
        {
            List<VehicleUI> vehicles = new List<VehicleUI>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayUsedVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleUI currentRow = new VehicleUI();

                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorName = dr["ColorName"].ToString();
                        currentRow.Featured = (bool)dr["Featured"];
                        currentRow.ImageFilePath = dr["ImageFilePath"].ToString();
                        currentRow.InteriorType = dr["InteriorType"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ModelYear = dr["ModelYear"].ToString();
                        currentRow.New = (bool)dr["New"];
                        currentRow.Sold = (bool)dr["Sold"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.VehicleDescription = dr["VehicleDescription"].ToString();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        if (dr["SalePrice"] != DBNull.Value)
                            currentRow.SalePrice = (decimal)dr["SalePrice"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public List<VehicleUI> GetUnsoldVehicles()
        {
            List<VehicleUI> vehicles = new List<VehicleUI>();

            using (var cn = new SqlConnection("Server=localhost;Database=GuildCars;User Id=sa;Password=sqlserver;"))
            {
                SqlCommand cmd = new SqlCommand("DisplayUnsoldVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleUI currentRow = new VehicleUI();

                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.ColorName = dr["ColorName"].ToString();
                        currentRow.Featured = (bool)dr["Featured"];
                        currentRow.ImageFilePath = dr["ImageFilePath"].ToString();
                        currentRow.InteriorType = dr["InteriorType"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ModelYear = dr["ModelYear"].ToString();
                        currentRow.New = (bool)dr["New"];
                        currentRow.Sold = (bool)dr["Sold"];
                        currentRow.TransmissionType = dr["TransmissionType"].ToString();
                        currentRow.VehicleDescription = dr["VehicleDescription"].ToString();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        if (dr["SalePrice"] != DBNull.Value)
                            currentRow.SalePrice = (decimal)dr["SalePrice"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles; ;
        }
    }
    
 }
