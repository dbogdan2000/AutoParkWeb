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
            await using (connection)
            {
                var types = await connection.QueryAsync<VehicleType>("select * from vehicle_types");
                return types;
            }
        }

        public async Task<VehicleType> Get(int id)
        {
            await using (connection)
            {
                return await connection.QueryFirstAsync<VehicleType>("select * from vehicle_types where id = @id", new {id});
            }
        }

        public async void Create(VehicleType item)
        {
            await using (connection)
            {
                await connection.ExecuteAsync(
                    "insert into vehicle_types(type_name, tax_coefficient) values(@TypeName, @TaxCoefficient)", item);
            }
        }

        public async void Delete(int id)
        {
            await using (connection)
            {
                await connection.ExecuteAsync("delete from vehicle_types where id = @id", new {id});
            }
        }
    }
}