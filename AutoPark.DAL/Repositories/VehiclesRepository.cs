using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoPark.DAL.Entities;
using AutoPark.DAL.Interfaces;
using Dapper;

namespace AutoPark.DAL.Repositories
{
    public class VehiclesRepository : ConnectionRepository, IRepository<Vehicle> 
    {
        public VehiclesRepository(string connectionString) : base(connectionString)
        {
        }
        
        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await connection.QueryAsync<Vehicle>("select * from vehicles");
        }

        public async Task<Vehicle> Get(int id)
        {
            return await connection.QueryFirstAsync<Vehicle>("select * from vehicles where id = @id ", new {id});
        }

        public async Task Create(Vehicle vehicle)
        {
            await connection.ExecuteAsync(
                    "insert into vehicles(model_name, registration_number, weight, manufacture_year, mileage, color, volume, vehicle_type_id)" +
                    "values(@Model_Name, @Registration_Number, @Weight, @Manufacture_Year, @Mileage, @Color, @Volume, @Vehicle_Type_Id)", vehicle);
        }

        public async Task Update(Vehicle vehicle)
        {
            await connection.ExecuteAsync(
                    "update vehicles set model_name=@Model_name, registration_number=@Registration_Number, weight=@Weight, manufacture_year=@Manufacture_Year, " +
                    "mileage=@Mileage, color=@Color, volume=@Volume, vehicle_type_id=@Vehicle_Type_Id where id = @Id", vehicle);
        }

        public async Task Delete(int id)
        {
            await connection.ExecuteAsync("delete from vehicles where id = @Id", new {id});
        }
    }
}