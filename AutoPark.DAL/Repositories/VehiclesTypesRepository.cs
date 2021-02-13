using System;
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
    public class VehiclesTypesRepository :  ConnectionRepository, IRepository<VehicleType>
    {
        public VehiclesTypesRepository(string connectionString) : base(connectionString)
        {
        }
        
        public async Task<IEnumerable<VehicleType>> GetAll()
        {
            return await connection.QueryAsync<VehicleType>("select * from vehicle_types");;
        }

        public async Task<VehicleType> Get(int id)
        {
            return await connection.QueryFirstAsync<VehicleType>("select * from vehicle_types where id = @id", new {id});
        }

        public async Task Create(VehicleType type)
        {
            await connection.ExecuteAsync(
                    "insert into vehicle_types(type_name, tax_coefficient) values(@Type_Name, @Tax_Coefficient)", type);
        }

        public async Task Update(VehicleType type)
        {
            await connection.ExecuteAsync(
                    "update vehicle_types set type_name = @Type_Name, tax_coefficient = @Tax_Coefficient where id = @Id", type);
        }

        public async Task Delete(int id)
        {
            await connection.ExecuteAsync("delete from vehicle_types where id = @id", new {id});
        }
    }
}